using Microsoft.AspNetCore.Mvc;
using Business.Models;
using DataAccess.Library;
using WebClient2.BackGroundServices;
using DataAccess.DAO;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using WebClient2.ViewModel;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    public class IntermediateOrdersController : Controller
    {
        #region VIEW INTER ORDER
        public IActionResult Market()
        {
            //List<IntermediateOrder> order = IntermediateOrderDAO.GetInterAbleToSell();
            //return View(order);
            return View();
        }

        public IActionResult ListOrders(int page = 1, int itemsPerPage = 5)
        {
            var data = IntermediateOrderDAO.GetInterAbleToSell(); // Lấy dữ liệu từ cơ sở dữ liệu hoặc nguồn dữ liệu khác

            // Tính toán số lượng trang dựa trên tổng số phần tử và số lượng phần tử trên mỗi trang
            var totalPages = (int)Math.Ceiling((double)data.Count() / itemsPerPage);

            // Phân trang dữ liệu
            var pagedData = data.Skip((page - 1) * itemsPerPage)
                                .Take(itemsPerPage)
                                .Select(item => new
                                {
                                    id = item.id,
                                    name = item.name,
                                    price = item.price,
                                    status = item.status,
                                    payment_amount = item.payment_amount,
                                    accountName = AccountDAO.GetAccountWithId(item.create_by).name,
                                    create_at = item.create_at.ToString("dd/MM/yyyy"),
                                    update_at = item.update_at.ToString("dd/MM/yyyy")
                                });

            // Trả về dữ liệu dưới dạng JSON cùng với thông tin phân trang
            return Json(new
            {
                currentPage = page,
                totalPages = totalPages,
                items = pagedData
            });
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

        public IActionResult OrderDetail(string? id)
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
                if (price < 0)
                {
                    ModelState.AddModelError(string.Empty, "Số tiền cần lớn hơn 0");
                    return RedirectToAction("Create", "IntermediateOrders");
                }
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
        public IActionResult Edit(string? id)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
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

            if (intermediateOrder.buy_user != null)
            {
                return RedirectToAction("Market");
            }
            if (intermediateOrder.create_by != HttpContext.Session.GetInt32("Account").Value)
            {
                return RedirectToAction("Market");
            }
            UpdateOrderView update = new UpdateOrderView()
            {
                id = order.id,
                name = order.name,
                price = order.price,
                fee_type = order.fee_type,
                description = order.description,
                contact = order.contact,
                hidden_content = order.hidden_content,
                is_public = order.is_public,
            };

            //return View(order);
            return View(update);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public IActionResult Edit(UpdateOrderView orderView)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;


            IntermediateOrder order = new IntermediateOrder();
            order = IntermediateOrderDAO.GetIntermediateOrderById(orderView.id);
            if (order == null) { return NotFound(); }
            if (order.buy_user != null)
            {
                return RedirectToAction("Market");
            }
            if (order.create_by != account_id)
            {
                return RedirectToAction("Market");
            }
            if (ModelState.IsValid)
            {
                order.name = orderView.name;
                order.price = orderView.price;
                order.fee_type = orderView.fee_type;
                order.payment_amount = orderView.fee_type ? orderView.price : orderView.price + (int)(orderView.price * Constant.FEE);
                order.earn_amount = orderView.fee_type ? orderView.price - (int)(orderView.price * Constant.FEE) : orderView.price;
                order.description = orderView.description;
                order.contact = orderView.contact;
                order.hidden_content = orderView.hidden_content;
                order.is_public = orderView.is_public;
                order.update_by = account_id;
                IntermediateOrderDAO.UpdateIntermediateOrder(order);
                return RedirectToAction("Edit", "IntermediateOrders", new { id = orderView.id });
            }
            return RedirectToAction("Edit", "IntermediateOrders", new { id = orderView.id });
        }

        [Authorize(Roles = "Admin,User")]
        public bool CheckInterOrderEdit(int create_user, string inter_order)
        {
            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(inter_order);
            if (order.buy_user == null && order.create_by == create_user)
            {
                return true;
            }
            return false;
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
            if (order.buy_user != null)
            {
                return Json(new { success = true, message = "Hàng đã có người mua" });
            }
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

        [Authorize(Roles = "Admin,User")]
        public IActionResult ConfirmInterOrderComplete(string id)
        {
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);


            if (order.buy_user == null)
            {
                TempData["Message"] = "Lỗi xảy ra";
                return RedirectToAction("OrderDetail", "IntermediateOrders", new { id = id });
            }
            else
            {
                if (order.status == IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG)
                {
                    IntermediateOrderDAO.ConfirmInterOrderComplete(id);
                    WalletDAO.UpdateWalletDepositBalance(order.create_by, (int)order.earn_amount);
                }
            }

            TempData["Message"] = "Đã xác nhận thông tin đúng";
            return RedirectToAction("OrderDetail", "IntermediateOrders", new { id = id });
        }

        //[HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult KhieuNaiInterOrder(string id)
        {

            int account_id = HttpContext.Session.GetInt32("Account").Value;

            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);

            IntermediateOrderDAO.ReportInterOrder(id);
            TempData["Message"] = "Đã gửi khiếu nại cho người bán";
            return RedirectToAction("OrderDetail", "IntermediateOrders", new { id = id });
        }

        //[HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult KhieuNaiAdminInterOrder(string id)
        {

            int account_id = HttpContext.Session.GetInt32("Account").Value;

            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);

            IntermediateOrderDAO.ReportAdminInterOrder(id);
            TempData["Message"] = "Đã gửi khiếu nại lên admin đơn hàng thành công";
            return RedirectToAction("OrderDetail", "IntermediateOrders", new { id = id });
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
            if (order.buy_user != null)
            {
                WalletDAO.UpdateWalletDepositBalance(order.buy_user.Value, (int)order.payment_amount);
            }
            TempData["Message"] = "Hủy đơn hàng thành công";
            return RedirectToAction("OrderDetail", "IntermediateOrders", new { id = id });
        }
    }
}
