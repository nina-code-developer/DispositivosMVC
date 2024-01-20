using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DispositivosMVC.Models;

namespace DispositivosMVC.Controllers
{
    public class DispositivoController : Controller
    {
        private readonly BdPc1Context _context;

        public DispositivoController(BdPc1Context context)
        {
            _context = context;
        }

        // GET: Dispositivo
        public async Task<IActionResult> Index()
        {
            var bdPc1Context = _context.DispositivoPcs.Include(d => d.IdCtNavigation).Include(d => d.IdFbNavigation);
            return View(await bdPc1Context.ToListAsync());
        }

        // GET: Dispositivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DispositivoPcs == null)
            {
                return NotFound();
            }

            var dispositivoPc = await _context.DispositivoPcs
                .Include(d => d.IdCtNavigation)
                .Include(d => d.IdFbNavigation)
                .FirstOrDefaultAsync(m => m.IdDpc == id);
            if (dispositivoPc == null)
            {
                return NotFound();
            }

            return View(dispositivoPc);
        }

        // GET: Dispositivo/Create
        public IActionResult Create()
        {
            ViewData["IdCt"] = new SelectList(_context.Categoria, "IdCt", "IdCt");
            ViewData["IdFb"] = new SelectList(_context.Fabricantes, "IdFb", "IdFb");
            return View();
        }

        // POST: Dispositivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDpc,SerieDpc,DescripcionDpc,PrecioDpc,EstadoGarantiaDpc,IdFb,IdCt")] DispositivoPc dispositivoPc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispositivoPc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCt"] = new SelectList(_context.Categoria, "IdCt", "IdCt", dispositivoPc.IdCt);
            ViewData["IdFb"] = new SelectList(_context.Fabricantes, "IdFb", "IdFb", dispositivoPc.IdFb);
            return View(dispositivoPc);
        }

        // GET: Dispositivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DispositivoPcs == null)
            {
                return NotFound();
            }

            var dispositivoPc = await _context.DispositivoPcs.FindAsync(id);
            if (dispositivoPc == null)
            {
                return NotFound();
            }
            ViewData["IdCt"] = new SelectList(_context.Categoria, "IdCt", "IdCt", dispositivoPc.IdCt);
            ViewData["IdFb"] = new SelectList(_context.Fabricantes, "IdFb", "IdFb", dispositivoPc.IdFb);
            return View(dispositivoPc);
        }

        // POST: Dispositivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDpc,SerieDpc,DescripcionDpc,PrecioDpc,EstadoGarantiaDpc,IdFb,IdCt")] DispositivoPc dispositivoPc)
        {
            if (id != dispositivoPc.IdDpc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispositivoPc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispositivoPcExists(dispositivoPc.IdDpc))
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
            ViewData["IdCt"] = new SelectList(_context.Categoria, "IdCt", "IdCt", dispositivoPc.IdCt);
            ViewData["IdFb"] = new SelectList(_context.Fabricantes, "IdFb", "IdFb", dispositivoPc.IdFb);
            return View(dispositivoPc);
        }

        // GET: Dispositivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DispositivoPcs == null)
            {
                return NotFound();
            }

            var dispositivoPc = await _context.DispositivoPcs
                .Include(d => d.IdCtNavigation)
                .Include(d => d.IdFbNavigation)
                .FirstOrDefaultAsync(m => m.IdDpc == id);
            if (dispositivoPc == null)
            {
                return NotFound();
            }

            return View(dispositivoPc);
        }

        // POST: Dispositivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DispositivoPcs == null)
            {
                return Problem("Entity set 'BdPc1Context.DispositivoPcs'  is null.");
            }
            var dispositivoPc = await _context.DispositivoPcs.FindAsync(id);
            if (dispositivoPc != null)
            {
                _context.DispositivoPcs.Remove(dispositivoPc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DispositivoPcExists(int id)
        {
          return (_context.DispositivoPcs?.Any(e => e.IdDpc == id)).GetValueOrDefault();
        }
    }
}
