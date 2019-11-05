using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema.Data;
using Sistema.Data.Entities;

namespace Sistema.Controllers
{
    public class OperariosController : Controller
    {
        private readonly DataContext _context;

        public OperariosController(DataContext context)
        {
            _context = context;
        }

        // GET: Operarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Operarios.ToListAsync());
        }

        // GET: Operarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operario = await _context.Operarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operario == null)
            {
                return NotFound();
            }

            return View(operario);
        }

        // GET: Operarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Iniciales,FechaIngreso,SalarioHora,Estado")] Operario operario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operario);
        }

        // GET: Operarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operario = await _context.Operarios.FindAsync(id);
            if (operario == null)
            {
                return NotFound();
            }
            return View(operario);
        }

        // POST: Operarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Iniciales,FechaIngreso,SalarioHora,Estado")] Operario operario)
        {
            if (id != operario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperarioExists(operario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(operario);
        }

        // GET: Operarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operario = await _context.Operarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operario == null)
            {
                return NotFound();
            }

            return View(operario);
        }

        // POST: Operarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operario = await _context.Operarios.FindAsync(id);
            _context.Operarios.Remove(operario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperarioExists(int id)
        {
            return _context.Operarios.Any(e => e.Id == id);
        }
    }
}
