using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnunciosWebMVC.DBContext;
using AnunciosWebMVC.Anuncios.Servicios.Models;
using Anuncios.Servicios.Interfaces;

namespace AnunciosWebAppMVC.Controllers
{
    public class CorreosController : Controller
    {
        //private readonly AnuncioDbContext _context;
        private readonly ICorreo _serviciocorreo;

        public CorreosController(ICorreo correo)
        {
            //_context = context;
            _serviciocorreo = correo;

        }

        // GET: Correos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Correos.ToListAsync());
        //}

        // GET: Correos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var correo = await _context.Correos
            var model = await _serviciocorreo.GetCorreoIdAsync(id);
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
                var model = await _serviciocorreo.PostCorreoInsert(correo);
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

        // GET: Correos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var correo = await _context.Correos.FindAsync(id);
        //    if (correo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(correo);
        //}

        // POST: Correos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdCorreo,Nombre,Correo1,Mensaje")] Correo correo)
        //{
        //    if (id != correo.IdCorreo)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(correo);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CorreoExists(correo.IdCorreo))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(correo);
        //}

        // GET: Correos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var correo = await _context.Correos
        //        .FirstOrDefaultAsync(m => m.IdCorreo == id);
        //    if (correo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(correo);
        //}

        // POST: Correos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var correo = await _context.Correos.FindAsync(id);
        //    _context.Correos.Remove(correo);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CorreoExists(int id)
        //{
        //    return _context.Correos.Any(e => e.IdCorreo == id);
        //}
    }
}
