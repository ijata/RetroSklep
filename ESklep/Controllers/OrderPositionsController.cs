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
    public class OrderPositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderPosition.ToListAsync());
        }

        // GET: OrderPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPosition = await _context.OrderPosition
                .FirstOrDefaultAsync(m => m.orderposition_id == id);
            if (orderPosition == null)
            {
                return NotFound();
            }

            return View(orderPosition);
        }

        // GET: OrderPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderposition_id,order_id,product_id,product_name,storehouse_id,quantity,meansure_unit,price_netto,value_netto,tax_id,price_brutto,value_brutto")] OrderPosition orderPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderPosition);
        }

        // GET: OrderPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPosition = await _context.OrderPosition.FindAsync(id);
            if (orderPosition == null)
            {
                return NotFound();
            }
            return View(orderPosition);
        }

        // POST: OrderPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderposition_id,order_id,product_id,product_name,storehouse_id,quantity,meansure_unit,price_netto,value_netto,tax_id,price_brutto,value_brutto")] OrderPosition orderPosition)
        {
            if (id != orderPosition.orderposition_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderPositionExists(orderPosition.orderposition_id))
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
            return View(orderPosition);
        }

        // GET: OrderPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPosition = await _context.OrderPosition
                .FirstOrDefaultAsync(m => m.orderposition_id == id);
            if (orderPosition == null)
            {
                return NotFound();
            }

            return View(orderPosition);
        }

        // POST: OrderPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderPosition = await _context.OrderPosition.FindAsync(id);
            if (orderPosition != null)
            {
                _context.OrderPosition.Remove(orderPosition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderPositionExists(int id)
        {
            return _context.OrderPosition.Any(e => e.orderposition_id == id);
        }
    }
}
