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
using WebClient2.BackGroundServices;
using DataAccess.DAO;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
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
            return View();
        }

        // POST: IntermediateOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string name, int price, bool fee_type, string description, string contact, string hidden_content, bool is_public)
        {
            IntermediateOrder order = new IntermediateOrder();
            if (ModelState.IsValid)
            {
                //int user_id = HttpContext.Session.GetInt32("Account").Value;

                if (WalletDAO.GetWalletByAccountId(14).balance < 500)
                {
                    ModelState.AddModelError(string.Empty, "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(14).balance);
                }
                else
                {
                    WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(14).id, 500);
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

                    IntermediateOrderDAO.CreateIntermediateOrder(order);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(order);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IntermediateOrder intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderById(id.Value);

            if (intermediateOrder == null)
            {
                return NotFound();
            }
            return View(intermediateOrder);
        }

        // POST: IntermediateOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,name,price,fee_type,description,contact,hidden_content,is_public,fee,status,state,create_by,create_at,buy_by,update_by,update_at,is_delete")] IntermediateOrder intermediateOrder)
        {
            if (id != intermediateOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                intermediateOrder.update_by = 13;
                IntermediateOrderDAO.UpdateIntermediateOrder(intermediateOrder);
                return RedirectToAction(nameof(Index));
            }
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

        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IntermediateOrder intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderById(id.Value);

            if (intermediateOrder == null)
            {
                return NotFound();
            }
            return View(intermediateOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int id, [Bind("id,name,price,fee_type,description,contact,hidden_content,is_public,fee,status,state,create_by,create_at,buy_by,update_by,update_at,is_delete")] IntermediateOrder intermediateOrder)
        {
            if (id != intermediateOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (WalletDAO.GetWalletByAccountId(14).balance < 500)
                {
                    ModelState.AddModelError(string.Empty, "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(14).balance);
                }
                WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(14).id, intermediateOrder.price + 500);

                intermediateOrder.update_by = 14;
                intermediateOrder.buy_by = 14;
                IntermediateOrderDAO.BuyIntermediateOrder(intermediateOrder);
                return RedirectToAction(nameof(Index));
            }
            return View(intermediateOrder);
        }
    }
}
