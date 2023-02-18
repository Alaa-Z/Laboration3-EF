using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testEntity.Data;
using testEntity.Models;

namespace testEntity.Controllers
{
    public class UserCdController : Controller
    {
        private readonly MyContext _context;

        public UserCdController(MyContext context)
        {
            _context = context;
        }

        // GET: UserCd
        public async Task<IActionResult> Index()
        {
            var myContext = _context.UserCds.Include(u => u.Cd).Include(u => u.User);
            return View(await myContext.ToListAsync());
        }

        // GET: UserCd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserCds == null)
            {
                return NotFound();
            }

            var userCd = await _context.UserCds
                .Include(u => u.Cd)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (userCd == null)
            {
                return NotFound();
            }

            return View(userCd);
        }

        // GET: UserCd/Create
        public IActionResult Create()
        {
            ViewData["CdId"] = new SelectList(_context.Cds, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UserCd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdId,UserId,BorrowingDate")] UserCd userCd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CdId"] = new SelectList(_context.Cds, "Id", "Name", userCd.CdId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userCd.UserId);
            return View(userCd);
        }

        // GET: UserCd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserCds == null)
            {
                return NotFound();
            }

            var userCd = await _context.UserCds.FindAsync(id);
            if (userCd == null)
            {
                return NotFound();
            }
            ViewData["CdId"] = new SelectList(_context.Cds, "Id", "Name", userCd.CdId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userCd.UserId);
            return View(userCd);
        }

        // POST: UserCd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdId,UserId,BorrowingDate")] UserCd userCd)
        {
            if (id != userCd.CdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCdExists(userCd.CdId))
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
            ViewData["CdId"] = new SelectList(_context.Cds, "Id", "Name", userCd.CdId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userCd.UserId);
            return View(userCd);
        }

        // GET: UserCd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserCds == null)
            {
                return NotFound();
            }

            var userCd = await _context.UserCds
                .Include(u => u.Cd)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (userCd == null)
            {
                return NotFound();
            }

            return View(userCd);
        }

        // POST: UserCd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserCds == null)
            {
                return Problem("Entity set 'MyContext.UserCds'  is null.");
            }
            var userCd = await _context.UserCds.FindAsync(id);
            if (userCd != null)
            {
                _context.UserCds.Remove(userCd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCdExists(int id)
        {
          return (_context.UserCds?.Any(e => e.CdId == id)).GetValueOrDefault();
        }
    }
}
