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
    public class StorehousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StorehousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Storehouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Storehouse.ToListAsync());
        }

        // GET: Storehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouse = await _context.Storehouse
                .FirstOrDefaultAsync(m => m.storehouse_id == id);
            if (storehouse == null)
            {
                return NotFound();
            }

            return View(storehouse);
        }

        // GET: Storehouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Storehouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("storehouse_id,product_id,delivery_id,quantity,price,meansure_unit")] Storehouse storehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storehouse);
        }

        // GET: Storehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouse = await _context.Storehouse.FindAsync(id);
            if (storehouse == null)
            {
                return NotFound();
            }
            return View(storehouse);
        }

        // POST: Storehouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("storehouse_id,product_id,delivery_id,quantity,price,meansure_unit")] Storehouse storehouse)
        {
            if (id != storehouse.storehouse_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorehouseExists(storehouse.storehouse_id))
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
            return View(storehouse);
        }

        // GET: Storehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouse = await _context.Storehouse
                .FirstOrDefaultAsync(m => m.storehouse_id == id);
            if (storehouse == null)
            {
                return NotFound();
            }

            return View(storehouse);
        }

        // POST: Storehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storehouse = await _context.Storehouse.FindAsync(id);
            if (storehouse != null)
            {
                _context.Storehouse.Remove(storehouse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorehouseExists(int id)
        {
            return _context.Storehouse.Any(e => e.storehouse_id == id);
        }
    }
}
