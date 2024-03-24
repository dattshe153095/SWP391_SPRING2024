using Business.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DataAccess.Captcha;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using DataAccess.ViewModel;

namespace WebClient2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        public IActionResult DetailOrder(string? id)
        {
            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            OrderViewModel orderView = new OrderViewModel();

            OrderViewModel orderViewModel= IntermediateOrderDAO.GetOrderViewModel(order);
            return View(orderView);

        }
        public IActionResult DepositManage()
        {
            List<Deposit> deposits = DepositDAO.GetAllDeposit();
            return View(deposits);
        }
        public IActionResult DetailDeposit(string? id)
        {
            List<Deposit> deposits = DepositDAO.GetAllDeposit();
            return View(deposits);
        }
    }


}
