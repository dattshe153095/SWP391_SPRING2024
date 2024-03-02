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
using DataAccess.ViewModel;

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
        public IActionResult Index()
        {
            ViewBag.account_id = HttpContext.Session.GetInt32("Account");
            List<IntermediateProduct> order = IntermediateProductDAO.GetAllIntermediateProduct();
            return View(order);
        }

        // GET: IntermediateOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.IntermediateOrders == null)
            {
                return NotFound();
            }
            IntermediateProduct intermediateOrder = new IntermediateProduct();
            intermediateOrder = IntermediateProductDAO.GetIntermediateProductById(id.Value);
            OrderViewModel order = new OrderViewModel();

            //MapData
            order = IntermediateProductDAO.GetOrderViewModel(intermediateOrder);

            if (intermediateOrder == null)
            {
                return NotFound();
            }

            return View(order);
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
            IntermediateProduct order = new IntermediateProduct();
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
                    order = new IntermediateProduct()
                    {
                        name = name,
                        price = price,
                        fee_type = fee_type,
                        description = description,
                        contact = contact,
                        hidden_content = hidden_content,
                        is_public = is_public,
                        fee = 500,
                        state = StateEnum.DANG_XU_LI,
                        create_by = 14,
                        create_at = DateTime.Now,
                        update_by = 14,
                        update_at = DateTime.Now,
                    };

                    IntermediateProductDAO.CreateIntermediateOrder(order);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(order);
        }



        // POST: IntermediateOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,name,price,fee_type,description,contact,hidden_content,is_public,fee,status,state,create_by,create_at,buy_by,update_by,update_at,is_delete")] IntermediateProduct intermediateOrder)
        {
            if (id != intermediateOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                intermediateOrder.update_by = 13;
                IntermediateProductDAO.UpdateIntermediateOrder(intermediateOrder);
                return RedirectToAction(nameof(Index));
            }
            return View(intermediateOrder);
        }

        // GET: IntermediateOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            return View();
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

            IntermediateProduct intermediateOrder = IntermediateProductDAO.GetIntermediateProductById(id.Value);

            if (intermediateOrder == null)
            {
                return NotFound();
            }
            return View(intermediateOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int id, [Bind("id,name,price,fee_type,description,contact,hidden_content,is_public,fee,status,state,create_by,create_at,buy_by,update_by,update_at,is_delete")] IntermediateProduct intermediateOrder)
        {
            if (id != intermediateOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //CALCULATE PRICE
                OrderViewModel order = new OrderViewModel();
                //MapData
                order = IntermediateProductDAO.GetOrderViewModel(intermediateOrder);
                if (WalletDAO.GetWalletByAccountId(14).balance < order.earn_amount)
                {
                    ModelState.AddModelError(string.Empty, "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(14).balance);
                }
                WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(14).id, intermediateOrder.price + 500);

                intermediateOrder.update_by = 14;
                //intermediateOrder.buy_by = 14;
                IntermediateProductDAO.BuyIntermediateOrder(intermediateOrder);
                return RedirectToAction(nameof(Index));
            }
            return View(intermediateOrder);
        }
    }
}
