using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using Anuncios.Servicios.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AnunciosWebAppMVC.Controllers
{
    public class CorreosController : Controller
    {
        private readonly ICorreo _serviciocorreo;
        private readonly IConfiguration _config;
        public string _apiurl;

        public CorreosController(ICorreo correo, IConfiguration config)
        {
            //_context = context;
            _serviciocorreo = correo;
            _config = config;
            _apiurl = _config["ConnectionString:ConexionApi"];
        }

        // GET: Correos
        public async Task<IActionResult> Index()
        {
            var model = await _serviciocorreo.GetCorreosAsync(_apiurl);
            return View(model);
        }

        // GET: Correos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var correo = await _context.Correos
            var model = await _serviciocorreo.GetCorreoIdAsync(id, _apiurl);
                //.FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Correos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Correos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCorreo,Nombre,Correo1,Mensaje")] Correo correo)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(correo);
                //await _context.SaveChangesAsync();
                //var id = IdCorreo;
                var model = await _serviciocorreo.PostCorreoInsert(correo, _apiurl);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Mensaje");
            }
            //return View(correo);
            return RedirectToAction("Mensaje");
        }

        public IActionResult Mensaje()
        {
            return View();
        }

 
    }
}
