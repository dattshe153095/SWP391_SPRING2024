using Microsoft.AspNetCore.Mvc;
using Business.Models;
using DataAccess.Library;
using WebClient2.BackGroundServices;
using DataAccess.DAO;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    public class IntermediateOrdersController : Controller
    {
        #region VIEW INTER ORDER
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

            //return View(order);
            return PartialView("_ModalOrder", order);
        }
        #endregion

        #region CREATE INTER ORDER
        // GET: IntermediateOrders/Create
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: IntermediateOrders/Create
        [Authorize(Roles = "Admin,User")]
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
                    return RedirectToAction("Market", "IntermediateOrders");
                }

            }
            return RedirectToAction("Market", "IntermediateOrders");
        }
        #endregion

        #region EDIT INTER ORDER
        [Authorize(Roles = "Admin,User")]
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
        #endregion

        #region BUY INTER ORDER
        [Authorize(Roles = "Admin,User")]
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

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
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
                return Json(new { success = false, message = "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(account_id).balance });
            }
            WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(account_id).id, (int)order.payment_amount);

            order.update_by = account_id;
            order.buy_user = account_id;
            order.buy_at = DateTime.Now;
            IntermediateOrderDAO.BuyIntermediateOrder(account_id, order);
            return Json(new { success = true, message = "Mua hàng thành công" });
        }
        #endregion

        #region VIEW ORDER BY TYPE SELL AND BUYED
        [Authorize(Roles = "Admin,User")]
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
        [Authorize(Roles = "Admin,User")]
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
        #endregion

        [HttpGet]
        public IActionResult CheckSession()
        {
            bool loggedIn = HttpContext.Session.GetInt32("Account") != null;

            return Json(new { loggedIn = loggedIn });
        }

        //[HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult KhieuNaiInterOrder(string id)
        {

            int account_id = HttpContext.Session.GetInt32("Account").Value;

            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);

            IntermediateOrderDAO.ReportInterOrder(id);
            //return Json(new { success = true, message = "Khiếu nại thành công" });
            return RedirectToAction("Market", "IntermediateOrders");
        }

        //[HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult KhieuNaiAdminInterOrder(string id)
        {

            int account_id = HttpContext.Session.GetInt32("Account").Value;

            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);

            IntermediateOrderDAO.ReportAdminInterOrder(id);
            //return Json(new { success = true, message = "Khiếu nại lên Admin thành công" });
            return RedirectToAction("Market", "IntermediateOrders");
        }

        //[HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult DeleteInterOrder(string id)
        {

            int account_id = HttpContext.Session.GetInt32("Account").Value;


            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            if (account_id != order.create_by)
            {
                return RedirectToAction("Login", "Home");
            }

            IntermediateOrderDAO.DeleteInterOrder(id);
            //return Json(new { success = true, message = "Hủy hàng thành công" });
            return RedirectToAction("Market", "IntermediateOrders");
        }
    }
}
