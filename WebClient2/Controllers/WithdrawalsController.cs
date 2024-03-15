using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebClient2.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class WithdrawalsController : Controller
    {
        private readonly Web_Trung_GianContext _context;

        public WithdrawalsController(Web_Trung_GianContext context)
        {
            _context = context;
        }

        // GET: Withdrawals
       
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

    }
}
