using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Anuncios.Servicios.Interfaces;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using Microsoft.AspNetCore.Routing;
using AnunciosWebMVC.Anuncios.Servicios.DataTransferO;
using Microsoft.Extensions.Configuration;

namespace AnunciosWebAppMVC.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncio _servicioanuncio;
        private readonly ITipo _serviciotipo;
        private readonly IConfiguration _config;
        public string _apiurl;
        

        public AnunciosController(IAnuncio anuncio, ITipo tipo, IConfiguration config)
        {
            _servicioanuncio = anuncio;
            _serviciotipo = tipo;
           _config = config;
          _apiurl = _config["ConnectionString:ConexionApi"];
        }

               // GET: Anuncios
        public async Task<ActionResult<List<Anuncio>>> Index()
        {
            var model = await _servicioanuncio.GetAnunciosAsync(_apiurl);
            return View(model);

        }

        public async Task<ActionResult<List<AnuncioView>>> Lista(int pagina = 1)
        {
            //List<Anuncio> model = new List<Anuncio>();
            var model = await _servicioanuncio.GetAnunciosPaginaAsync(pagina, _apiurl);
            var totalmodel = await _servicioanuncio.GetAnunciosAsync(_apiurl);
            var totalRegistros = totalmodel.Count();

            var mpagina = new PaginaModelo();
            //mpagina.AnunciosPagina = model;
            mpagina.PaginaActual = pagina;
            mpagina.TotalDeRegistros = totalRegistros;
            mpagina.RegistrosPorPagina = 10;
            mpagina.ValoresQueryString = new RouteValueDictionary();
            mpagina.ValoresQueryString["pagina"] = pagina;
            ViewBag.mipagina = mpagina;

            List<Tipo> cattipos = new List<Tipo>();
            cattipos = await _serviciotipo.GetTiposAsync(_apiurl);
            //ViewBag.tipos = new SelectList(cattipos, "Id_Tipo", "Tipo1");
            ViewBag.tipos = new SelectList(cattipos, "Tipo1", "Tipo1");

            return View(model);

        }
        //BUSCAR

        public async Task<PartialViewResult> Buscar(string ptext, string pmin, string pmax, string psel)
        {
            //IEnumerable<Anuncio> model = new List<Anuncio>();
            IEnumerable<AnuncioView> filtro = new List<AnuncioView>();
            var model = await _servicioanuncio.GetAnunciosAsync(_apiurl);
            filtro = model;
            if (ptext != null) {
                filtro = filtro.Where(p => (p.Titulo.Contains(ptext)));
            }
            if (pmin != null) {
                filtro = filtro.Where(p => (p.Precio >= Convert.ToDouble(pmin)));
            }
            if (pmax != null)
            {
                filtro = filtro.Where(p => (p.Precio <= Convert.ToDouble(pmax)));
            }
            if (psel != null) { 
                filtro = filtro.Where(p => (p.Tipo.Contains(psel)));
            }

            //filtro = model.Where(p => (p.Precio >= Convert.ToDouble(pmin) && p.Precio <= Convert.ToDouble(pmax) && p.Titulo.Contains(ptext) && p.Tipo.Contains(psel)));
            return PartialView("_Listavista",filtro);
           

        }

        public async Task<PartialViewResult> BuscarPaginado(string ptext, string pmin, string pmax, string psel, int pagina = 1)
        {
            //IEnumerable<Anuncio> model = new List<Anuncio>();
            IEnumerable<AnuncioView> filtro = new List<AnuncioView>();
            var model = await _servicioanuncio.GetAnunciosAsync(_apiurl);
            filtro = model.Where(p => (p.Precio >= Convert.ToDouble(pmin) && p.Precio <= Convert.ToDouble(pmax) && p.Titulo.Contains(ptext) && p.Tipo.Contains(psel)));

            return PartialView("_Listavista", filtro);


        }
        // GET: Anuncios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var apiurl = _config["ConnectionString:ConexionApi"];
            var model = await _servicioanuncio.GetAnuncioIdVistaAsync(id,_apiurl);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Anuncios/Create
        public async Task<IActionResult> Create()
        {
            //List<> cattipos = _serviciotipo.GetTiposAsync();

            List<Tipo> cattipos = new List<Tipo>();
            cattipos = await _serviciotipo.GetTiposAsync(_apiurl);
            ViewBag.tipos = new SelectList(cattipos, "Id_Tipo", "Tipo1");
            return View();
        }

        // POST: Anuncios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,IdTipo,Precio,Imagen")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    anuncio.Imagen = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                }
                var model = await _servicioanuncio.PostAnuncioInsert(anuncio,_apiurl);
                return RedirectToAction(nameof(Index));
            }
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _servicioanuncio.GetAnuncioIdAsync(id,_apiurl);
            List<Tipo> cattipos = new List<Tipo>();
            cattipos = await _serviciotipo.GetTiposAsync(_apiurl);
            ViewBag.tipos = new SelectList(cattipos, "Id_Tipo", "Tipo1",model.IdTipo);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Anuncios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,IdTipo,Precio,Imagen")] Anuncio anuncio)
        {
            if (id != anuncio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var file in Request.Form.Files)
                    {

                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        anuncio.Imagen = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }
                    var model = await _servicioanuncio.PostAnuncioUpdate(anuncio,_apiurl);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioExists(anuncio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _servicioanuncio.GetAnuncioIdVistaAsync(id,_apiurl);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _servicioanuncio.PostAnuncioDelete(id,_apiurl);
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
           
            return true;
                
        }
    }
}
