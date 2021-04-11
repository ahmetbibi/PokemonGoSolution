using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonGo.Data;

namespace PokemonGo.Controllers
{
    public class PointTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PointTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PointTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PointType.ToListAsync());
        }

        // GET: PointTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointType = await _context.PointType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointType == null)
            {
                return NotFound();
            }

            return View(pointType);
        }

        // GET: PointTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PointTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PointType pointType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pointType);
        }

        // GET: PointTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointType = await _context.PointType.FindAsync(id);
            if (pointType == null)
            {
                return NotFound();
            }
            return View(pointType);
        }

        // POST: PointTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PointType pointType)
        {
            if (id != pointType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointTypeExists(pointType.Id))
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
            return View(pointType);
        }

        // GET: PointTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointType = await _context.PointType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointType == null)
            {
                return NotFound();
            }

            return View(pointType);
        }

        // POST: PointTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointType = await _context.PointType.FindAsync(id);
            _context.PointType.Remove(pointType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointTypeExists(int id)
        {
            return _context.PointType.Any(e => e.Id == id);
        }
    }
}
