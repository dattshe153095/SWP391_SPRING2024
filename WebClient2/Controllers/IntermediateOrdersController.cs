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

        public IActionResult Market()
        {
            List<IntermediateOrder> order = IntermediateOrderDAO.GetInterAbleToSell();
            return View(order);
        }

        // GET: IntermediateOrders/Details/5
        public IActionResult MarketDetail(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IntermediateOrder intermediateOrder = new IntermediateOrder();
            intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderById(id);
            OrderViewModel order = new OrderViewModel();

            //MapData
            order = IntermediateOrderDAO.GetOrderViewModel(intermediateOrder);

            if (intermediateOrder == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: IntermediateOrders/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            return View();
        }

        // POST: IntermediateOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string name, int price, bool fee_type, string description, string contact, string hidden_content, bool is_public)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;

            IntermediateOrder order = new IntermediateOrder();
            if (ModelState.IsValid)
            {
                //int user_id = HttpContext.Session.GetInt32("Account").Value;

                if (WalletDAO.GetWalletByAccountId(account_id).balance < 500)
                {
                    ModelState.AddModelError(string.Empty, "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(account_id).balance);
                }
                else
                {
                    //Tieu tien de tao order
                    WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(account_id).id, 500);
                    string code = Gencode.GenerateUniqueId();
                    //Tao Order
                    order = new IntermediateOrder()
                    {
                        id = code,
                        name = name,
                        price = price,
                        fee_rate = Constant.FEE,
                        fee_type = fee_type,
                        description = description,
                        contact = contact,
                        hidden_content = hidden_content,
                        is_public = is_public,
                        status = IntermediateOrderEnum.MOI_TAO,
                        state = StateEnum.DANG_XU_LI,
                        create_by = account_id,
                        create_at = DateTime.Now,
                        update_by = account_id,
                        update_at = DateTime.Now,
                        link_product = "/Details/" + code
                    };

                    IntermediateOrderDAO.CreateIntermediateOrder(order);
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
        public IActionResult Edit(string id, string name, int price, bool fee_type, string description, string contact, string hidden_content, bool is_public)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;


            IntermediateOrder order = new IntermediateOrder();
            order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            if (order == null) { return NotFound(); }

            if (ModelState.IsValid)
            {
                order.name = name;
                order.price = price;
                order.fee_type = fee_type;
                order.payment_amount = fee_type ? price : price + (int)(price * Constant.FEE);
                order.earn_amount = fee_type ? price - (int)(price * Constant.FEE) : price;
                order.description = description;
                order.contact = contact;
                order.hidden_content = hidden_content;
                order.is_public = is_public;
                order.update_by = account_id;
                IntermediateOrderDAO.UpdateIntermediateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult BuyDetail(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IntermediateOrder intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderById(id);

            if (intermediateOrder == null)
            {
                return NotFound();
            }
            return View(intermediateOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(string id)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;

            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            //CALCULATE PRICE

            //MapData
            if (WalletDAO.GetWalletByAccountId(account_id).balance < order.payment_amount)
            {
                ModelState.AddModelError(string.Empty, "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(account_id).balance);
            }
            WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(account_id).id, (int)order.payment_amount);

            order.update_by = account_id;
            order.buy_user = account_id;
            order.buy_at = DateTime.Now;
            IntermediateOrderDAO.BuyIntermediateOrder(account_id, order);
            return RedirectToAction(nameof(Market));
        }

        [HttpGet]
        public IActionResult OrderBuy()
        {
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            if (account_id == null)
            {
                return NotFound();
            }

            List<IntermediateOrder> intermediateOrder = new List<IntermediateOrder>();
            intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderBuyed(account_id);

            if (intermediateOrder == null)
            {
                return NotFound();
            }
            return View(intermediateOrder);
        }

        [HttpGet]
        public IActionResult OrderSell()
        {
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            if (account_id == null)
            {
                return NotFound();
            }

            List<IntermediateOrder> intermediateOrder = new List<IntermediateOrder>();
            intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderCreated(account_id);

            if (intermediateOrder == null)
            {
                return NotFound();
            }
            return View(intermediateOrder);
        }
    }
}
