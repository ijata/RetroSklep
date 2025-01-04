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
    public class OrderHeadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderHeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderHeader.ToListAsync());
        }

        // GET: OrderHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHeader = await _context.OrderHeader
                .FirstOrDefaultAsync(m => m.order_id == id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return View(orderHeader);
        }

        // GET: OrderHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("order_id,number,year,order_date,order_time,status,client_id,value_netto,value_brutto,realization_user_id,realization_date,realization_time")] OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderHeader);
        }

        // GET: OrderHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHeader = await _context.OrderHeader.FindAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }
            return View(orderHeader);
        }

        // POST: OrderHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("order_id,number,year,order_date,order_time,status,client_id,value_netto,value_brutto,realization_user_id,realization_date,realization_time")] OrderHeader orderHeader)
        {
            if (id != orderHeader.order_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHeaderExists(orderHeader.order_id))
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
            return View(orderHeader);
        }

        // GET: OrderHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHeader = await _context.OrderHeader
                .FirstOrDefaultAsync(m => m.order_id == id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return View(orderHeader);
        }

        // POST: OrderHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderHeader = await _context.OrderHeader.FindAsync(id);
            if (orderHeader != null)
            {
                _context.OrderHeader.Remove(orderHeader);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHeaderExists(int id)
        {
            return _context.OrderHeader.Any(e => e.order_id == id);
        }
    }
}
