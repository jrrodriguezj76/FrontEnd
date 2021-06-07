using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnunciosWebMVC.DBContext;
using System.IO;
using Anuncios.Servicios.Interfaces;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using AnunciosWebAppMVC.ModelView;
using Microsoft.AspNetCore.Routing;
using AnunciosWebMVC.Anuncios.Servicios.DataTransferO;

namespace AnunciosWebAppMVC.Controllers
{
    public class AnunciosController : Controller
    {
        //private readonly AnuncioDbContext _context;
        private readonly IAnuncio _servicioanuncio;
        private readonly ITipo _serviciotipo;

        //public AnunciosController(AnuncioDbContext context, IAnuncio anuncio)
       public AnunciosController(IAnuncio anuncio, ITipo tipo)
        {
            //_context = context;
            _servicioanuncio = anuncio;
            _serviciotipo = tipo;
        }

               // GET: Anuncios
        public async Task<ActionResult<List<Anuncio>>> Index()
        {
            //List<Anuncio> model = new List<Anuncio>();
            var model = await _servicioanuncio.GetAnunciosAsync();
            return View(model);

        }

        //public async Task<ActionResult<List<Anuncio>>> Lista()
        //{
        //    //List<Anuncio> model = new List<Anuncio>();
        //    var model = await _servicioanuncio.GetAnunciosAsync();

        //   return View(model);

        //}
        public async Task<ActionResult<List<AnuncioView>>> Lista(int pagina = 1)
        {
            //List<Anuncio> model = new List<Anuncio>();
            var model = await _servicioanuncio.GetAnunciosPaginaAsync(pagina);
            var totalmodel = await _servicioanuncio.GetAnunciosAsync();
            var totalRegistros = totalmodel.Count();

            var mpagina = new PaginaModelo();
            //mpagina.AnunciosPagina = model;
            mpagina.PaginaActual = pagina;
            mpagina.TotalDeRegistros = totalRegistros;
            mpagina.RegistrosPorPagina = 10;
            mpagina.ValoresQueryString = new RouteValueDictionary();
            //mpagina.ValoresQueryString["pagina"] = edad
            ViewBag.mipagina = mpagina;

            return View(model);

        }

        // GET: Anuncios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _servicioanuncio.GetAnuncioIdAsync(id);
            //var anuncio = await _context.Anuncios
            //    .FirstOrDefaultAsync(m => m.Id == id);
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
            cattipos = await _serviciotipo.GetTiposAsync();
            ViewBag.tipos = new SelectList(cattipos, "Id_Tipo", "Tipo1");
            //List < ActivoDto > activo = await _iservices.GetActivoAsync();
            //ViewData["Activoid"] = new SelectList(activo, "Idactivo", "Nombre_corto", model.Activoid);
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
                var model = await _servicioanuncio.PostAnuncioInsert(anuncio);
                //_context.Add(anuncio);
                //await _context.SaveChangesAsync();
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

            var model = await _servicioanuncio.GetAnuncioIdAsync(id);
            List<Tipo> cattipos = new List<Tipo>();
            cattipos = await _serviciotipo.GetTiposAsync();
            ViewBag.tipos = new SelectList(cattipos, "Id_Tipo", "Tipo1",model.IdTipo);
            //var anuncio = await _context.Anuncios.FindAsync(id);
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
                    //_context.Update(anuncio);
                    //await _context.SaveChangesAsync();
                    var model = await _servicioanuncio.PostAnuncioUpdate(anuncio);
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
            var model = await _servicioanuncio.GetAnuncioIdAsync(id);
            //var anuncio = await _context.Anuncios
            //    .FirstOrDefaultAsync(m => m.Id == id);
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
            var model = await _servicioanuncio.PostAnuncioDelete(id);
            //var anuncio = await _context.Anuncios.FindAsync(id);
            //_context.Anuncios.Remove(anuncio);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
           
            ////return _context.Anuncios.Any(e => e.Id == id);
            //var model = await _servicioanuncio.GetAnuncioIdAsync(id);
            //if (model == null) {
            //    return false;
            //}
            return true;
                
        }
    }
}
