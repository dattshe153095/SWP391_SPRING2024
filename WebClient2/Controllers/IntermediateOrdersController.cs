using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;
using DataAccess.Library;

namespace WebClient2.Controllers
{
    public class IntermediateOrdersController : Controller
    {
        private readonly Web_Trung_GianContext _context;

        public IntermediateOrdersController(Web_Trung_GianContext context)
        {
            _context = context;
        }

        // GET: IntermediateOrders
        public async Task<IActionResult> Index()
        {
            ViewBag.account_id = HttpContext.Session.GetInt32("Account");
            var web_Trung_GianContext = _context.IntermediateOrders.Include(i => i.AccountBuy).Include(i => i.AccountCreate).Include(i => i.AccountUpdate);
            return View(await web_Trung_GianContext.ToListAsync());
        }

        // GET: IntermediateOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IntermediateOrders == null)
            {
                return NotFound();
            }

            var intermediateOrder = await _context.IntermediateOrders
                .Include(i => i.AccountBuy)
                .Include(i => i.AccountCreate)
                .Include(i => i.AccountUpdate)
                .FirstOrDefaultAsync(m => m.id == id);
            if (intermediateOrder == null)
            {
                return NotFound();
            }

            return View(intermediateOrder);
        }

        // GET: IntermediateOrders/Create
        public IActionResult Create()
        {
            ViewData["buy_by"] = new SelectList(_context.Accounts, "id", "email");
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email");
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email");
            return View();
        }

        // POST: IntermediateOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, int price, bool fee_type, string description, string contact, string hidden_content, bool is_public)
        {
            IntermediateOrder order = new IntermediateOrder();
            if (ModelState.IsValid)
            {
                order = new IntermediateOrder()
                {
                    name = name,
                    price = price,
                    fee_type = fee_type,
                    description = description,
                    contact = contact,
                    hidden_content = hidden_content,
                    is_public = is_public,
                    fee = 500,
                    status = IntermediateOrderEnum.MOI_TAO,
                    state = StateEnum.DANG_XU_LI,
                    create_by = 14,
                    create_at = DateTime.Now,
                    update_by = 14,
                    update_at = DateTime.Now,
                };


                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: IntermediateOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IntermediateOrders == null)
            {
                return NotFound();
            }

            var intermediateOrder = await _context.IntermediateOrders.FindAsync(id);
            if (intermediateOrder == null)
            {
                return NotFound();
            }
            ViewData["buy_by"] = new SelectList(_context.Accounts, "id", "email", intermediateOrder.buy_by);
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email", intermediateOrder.create_by);
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email", intermediateOrder.update_by);
            return View(intermediateOrder);
        }

        // POST: IntermediateOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,price,fee_type,description,contact,hidden_content,is_public,fee,status,state,create_by,create_at,buy_by,update_by,update_at,is_delete")] IntermediateOrder intermediateOrder)
        {
            if (id != intermediateOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intermediateOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntermediateOrderExists(intermediateOrder.id))
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
            ViewData["buy_by"] = new SelectList(_context.Accounts, "id", "email", intermediateOrder.buy_by);
            ViewData["create_by"] = new SelectList(_context.Accounts, "id", "email", intermediateOrder.create_by);
            ViewData["update_by"] = new SelectList(_context.Accounts, "id", "email", intermediateOrder.update_by);
            return View(intermediateOrder);
        }

        // GET: IntermediateOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IntermediateOrders == null)
            {
                return NotFound();
            }

            var intermediateOrder = await _context.IntermediateOrders
                .Include(i => i.AccountBuy)
                .Include(i => i.AccountCreate)
                .Include(i => i.AccountUpdate)
                .FirstOrDefaultAsync(m => m.id == id);
            if (intermediateOrder == null)
            {
                return NotFound();
            }

            return View(intermediateOrder);
        }

        // POST: IntermediateOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IntermediateOrders == null)
            {
                return Problem("Entity set 'Web_Trung_GianContext.IntermediateOrders'  is null.");
            }
            var intermediateOrder = await _context.IntermediateOrders.FindAsync(id);
            if (intermediateOrder != null)
            {
                _context.IntermediateOrders.Remove(intermediateOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntermediateOrderExists(int id)
        {
            return (_context.IntermediateOrders?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
