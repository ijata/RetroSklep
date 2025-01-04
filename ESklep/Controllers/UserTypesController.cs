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
    public class UserTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTypes.ToListAsync());
        }

        // GET: UserTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTypes = await _context.UserTypes
                .FirstOrDefaultAsync(m => m.type_id == id);
            if (userTypes == null)
            {
                return NotFound();
            }

            return View(userTypes);
        }

        // GET: UserTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("type_id,name")] UserTypes userTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTypes);
        }

        // GET: UserTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTypes = await _context.UserTypes.FindAsync(id);
            if (userTypes == null)
            {
                return NotFound();
            }
            return View(userTypes);
        }

        // POST: UserTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("type_id,name")] UserTypes userTypes)
        {
            if (id != userTypes.type_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTypesExists(userTypes.type_id))
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
            return View(userTypes);
        }

        // GET: UserTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTypes = await _context.UserTypes
                .FirstOrDefaultAsync(m => m.type_id == id);
            if (userTypes == null)
            {
                return NotFound();
            }

            return View(userTypes);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTypes = await _context.UserTypes.FindAsync(id);
            if (userTypes != null)
            {
                _context.UserTypes.Remove(userTypes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTypesExists(int id)
        {
            return _context.UserTypes.Any(e => e.type_id == id);
        }
    }
}
