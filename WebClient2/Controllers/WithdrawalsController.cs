using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;

namespace WebClient2.Controllers
{
    public class WithdrawalsController : Controller
    {
        private readonly Web_Trung_GianContext _context;

        public WithdrawalsController(Web_Trung_GianContext context)
        {
            _context = context;
        }

        // GET: Withdrawals
        public async Task<IActionResult> Index()
        {
            var web_Trung_GianContext = _context.Withdrawals.Include(w => w.Wallet);
            return View(await web_Trung_GianContext.ToListAsync());
        }

        // GET: Withdrawals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Withdrawals == null)
            {
                return NotFound();
            }

            var withdrawal = await _context.Withdrawals
                .Include(w => w.Wallet)
                .FirstOrDefaultAsync(m => m.id == id);
            if (withdrawal == null)
            {
                return NotFound();
            }

            return View(withdrawal);
        }

        // GET: Withdrawals/Create
        public IActionResult Create()
        {
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id");
            return View();
        }

        // POST: Withdrawals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,wallet_id,amount,bank_number,bank_user,bank_name,status,state,create_by,create_at,update_by,update_at,is_delete")] Withdrawal withdrawal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(withdrawal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id", withdrawal.wallet_id);
            return View(withdrawal);
        }

        // GET: Withdrawals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Withdrawals == null)
            {
                return NotFound();
            }

            var withdrawal = await _context.Withdrawals.FindAsync(id);
            if (withdrawal == null)
            {
                return NotFound();
            }
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id", withdrawal.wallet_id);
            return View(withdrawal);
        }

        // POST: Withdrawals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,wallet_id,amount,bank_number,bank_user,bank_name,status,state,create_by,create_at,update_by,update_at,is_delete")] Withdrawal withdrawal)
        {
            if (id != withdrawal.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(withdrawal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WithdrawalExists(withdrawal.id))
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
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id", withdrawal.wallet_id);
            return View(withdrawal);
        }

        // GET: Withdrawals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Withdrawals == null)
            {
                return NotFound();
            }

            var withdrawal = await _context.Withdrawals
                .Include(w => w.Wallet)
                .FirstOrDefaultAsync(m => m.id == id);
            if (withdrawal == null)
            {
                return NotFound();
            }

            return View(withdrawal);
        }

        // POST: Withdrawals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Withdrawals == null)
            {
                return Problem("Entity set 'Web_Trung_GianContext.Withdrawals'  is null.");
            }
            var withdrawal = await _context.Withdrawals.FindAsync(id);
            if (withdrawal != null)
            {
                _context.Withdrawals.Remove(withdrawal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WithdrawalExists(string id)
        {
          return (_context.Withdrawals?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
