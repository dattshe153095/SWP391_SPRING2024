using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;
using WebClient2.BackGroundServices;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    public class DepositsController : Controller
    {
        private readonly Web_Trung_GianContext _context;

        public DepositsController(Web_Trung_GianContext context)
        {
            _context = context;
        }

        // GET: Deposits
        public async Task<IActionResult> Index()
        {
            var web_Trung_GianContext = _context.Deposits.Include(d => d.AccountCreate).Include(d => d.AccountUpdate).Include(d => d.Wallet);
            return View(await web_Trung_GianContext.ToListAsync());
        }

        // GET: Deposits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .Include(d => d.AccountCreate)
                .Include(d => d.AccountUpdate)
                .Include(d => d.Wallet)
                .FirstOrDefaultAsync(m => m.id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // GET: Deposits/Create
        public IActionResult Create()
        {
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email");
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email");
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id");
            return View();
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,wallet_id,amount,trans_code,status,state,description,create_by,create_at,update_by,update_at,is_delete")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deposit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email", deposit.create_by);
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email", deposit.update_by);
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id", deposit.wallet_id);
            return View(deposit);
        }

        // GET: Deposits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email", deposit.create_by);
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email", deposit.update_by);
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id", deposit.wallet_id);
            return View(deposit);
        }

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,wallet_id,amount,trans_code,status,state,description,create_by,create_at,update_by,update_at,is_delete")] Deposit deposit)
        {
            if (id != deposit.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositExists(deposit.id))
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
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email", deposit.create_by);
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email", deposit.update_by);
            ViewData["wallet_id"] = new SelectList(_context.Wallets, "id", "id", deposit.wallet_id);
            return View(deposit);
        }

        // GET: Deposits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .Include(d => d.AccountCreate)
                .Include(d => d.AccountUpdate)
                .Include(d => d.Wallet)
                .FirstOrDefaultAsync(m => m.id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // POST: Deposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deposits == null)
            {
                return Problem("Entity set 'Web_Trung_GianContext.Deposits'  is null.");
            }
            var deposit = await _context.Deposits.FindAsync(id);
            if (deposit != null)
            {
                _context.Deposits.Remove(deposit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositExists(int id)
        {
          return (_context.Deposits?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
