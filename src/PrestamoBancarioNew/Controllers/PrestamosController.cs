using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestamoBancarioNew.Data;
using PrestamoBancarioNew.Models;

namespace PrestamoBancarioNew.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly PrestamoBancarioDbContext _context;

        public PrestamosController(PrestamoBancarioDbContext context)
        {
            _context = context;    
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            var prestamoBancarioDbContext = _context.Prestamos.Include(p => p.Cliente);
            return View(await prestamoBancarioDbContext.ToListAsync());
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.SingleOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Capital,ClienteId,Plazo,Tasa")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", prestamo.ClienteId);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.SingleOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }
           
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", prestamo.ClienteId);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Capital,ClienteId,Plazo,Tasa")] Prestamo prestamo)
        {
            if (id != prestamo.Id)
            {
                return NotFound();
            }
            if (prestamo.Capital <= 0)
            {
                _context.Database.ExecuteSqlCommand("DELETE  FROM  [dbo].[Prestamo] WHERE Id = "+prestamo.Id);
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", prestamo.ClienteId);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.SingleOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
