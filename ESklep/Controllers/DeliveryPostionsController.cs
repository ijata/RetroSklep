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
    public class DeliveryPostionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryPostionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryPostions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryPostion.ToListAsync());
        }

        // GET: DeliveryPostions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryPostion = await _context.DeliveryPostion
                .FirstOrDefaultAsync(m => m.deliveryposition_id == id);
            if (deliveryPostion == null)
            {
                return NotFound();
            }

            return View(deliveryPostion);
        }

        // GET: DeliveryPostions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryPostions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("deliveryposition_id,delivery_id,product_id,quantity,meansure_unit,price_netto,value_netto,tax_id,price_brutto,value_brutto")] DeliveryPostion deliveryPostion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryPostion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryPostion);
        }

        // GET: DeliveryPostions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryPostion = await _context.DeliveryPostion.FindAsync(id);
            if (deliveryPostion == null)
            {
                return NotFound();
            }
            return View(deliveryPostion);
        }

        // POST: DeliveryPostions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("deliveryposition_id,delivery_id,product_id,quantity,meansure_unit,price_netto,value_netto,tax_id,price_brutto,value_brutto")] DeliveryPostion deliveryPostion)
        {
            if (id != deliveryPostion.deliveryposition_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryPostion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryPostionExists(deliveryPostion.deliveryposition_id))
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
            return View(deliveryPostion);
        }

        // GET: DeliveryPostions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryPostion = await _context.DeliveryPostion
                .FirstOrDefaultAsync(m => m.deliveryposition_id == id);
            if (deliveryPostion == null)
            {
                return NotFound();
            }

            return View(deliveryPostion);
        }

        // POST: DeliveryPostions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryPostion = await _context.DeliveryPostion.FindAsync(id);
            if (deliveryPostion != null)
            {
                _context.DeliveryPostion.Remove(deliveryPostion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryPostionExists(int id)
        {
            return _context.DeliveryPostion.Any(e => e.deliveryposition_id == id);
        }
    }
}
