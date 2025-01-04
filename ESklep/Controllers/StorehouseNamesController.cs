using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESklep.Data;
using ESklep.Models;

namespace ESklep.Controllers
{
    public class StorehouseNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StorehouseNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StorehouseNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.StorehouseName.ToListAsync());
        }

        // GET: StorehouseNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouseName = await _context.StorehouseName
                .FirstOrDefaultAsync(m => m.storehouse_id == id);
            if (storehouseName == null)
            {
                return NotFound();
            }

            return View(storehouseName);
        }

        // GET: StorehouseNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StorehouseNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("storehouse_id,name")] StorehouseName storehouseName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storehouseName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storehouseName);
        }

        // GET: StorehouseNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouseName = await _context.StorehouseName.FindAsync(id);
            if (storehouseName == null)
            {
                return NotFound();
            }
            return View(storehouseName);
        }

        // POST: StorehouseNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("storehouse_id,name")] StorehouseName storehouseName)
        {
            if (id != storehouseName.storehouse_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storehouseName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorehouseNameExists(storehouseName.storehouse_id))
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
            return View(storehouseName);
        }

        // GET: StorehouseNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouseName = await _context.StorehouseName
                .FirstOrDefaultAsync(m => m.storehouse_id == id);
            if (storehouseName == null)
            {
                return NotFound();
            }

            return View(storehouseName);
        }

        // POST: StorehouseNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storehouseName = await _context.StorehouseName.FindAsync(id);
            if (storehouseName != null)
            {
                _context.StorehouseName.Remove(storehouseName);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorehouseNameExists(int id)
        {
            return _context.StorehouseName.Any(e => e.storehouse_id == id);
        }
    }
}
