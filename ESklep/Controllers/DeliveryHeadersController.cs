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
    public class DeliveryHeadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryHeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryHeader.ToListAsync());
        }

        // GET: DeliveryHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryHeader = await _context.DeliveryHeader
                .FirstOrDefaultAsync(m => m.delivery_id == id);
            if (deliveryHeader == null)
            {
                return NotFound();
            }

            return View(deliveryHeader);
        }

        // GET: DeliveryHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("delivery_id,storehouse_id,number,year,delivery_date,delivery_time,value_netto,value_brutto,status")] DeliveryHeader deliveryHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryHeader);
        }

        // GET: DeliveryHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryHeader = await _context.DeliveryHeader.FindAsync(id);
            if (deliveryHeader == null)
            {
                return NotFound();
            }
            return View(deliveryHeader);
        }

        // POST: DeliveryHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("delivery_id,storehouse_id,number,year,delivery_date,delivery_time,value_netto,value_brutto,status")] DeliveryHeader deliveryHeader)
        {
            if (id != deliveryHeader.delivery_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryHeaderExists(deliveryHeader.delivery_id))
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
            return View(deliveryHeader);
        }

        // GET: DeliveryHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryHeader = await _context.DeliveryHeader
                .FirstOrDefaultAsync(m => m.delivery_id == id);
            if (deliveryHeader == null)
            {
                return NotFound();
            }

            return View(deliveryHeader);
        }

        // POST: DeliveryHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryHeader = await _context.DeliveryHeader.FindAsync(id);
            if (deliveryHeader != null)
            {
                _context.DeliveryHeader.Remove(deliveryHeader);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryHeaderExists(int id)
        {
            return _context.DeliveryHeader.Any(e => e.delivery_id == id);
        }
    }
}
