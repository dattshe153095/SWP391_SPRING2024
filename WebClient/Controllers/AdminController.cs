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
using DataAccess.Library;

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
        public IActionResult Index2()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }
        public IActionResult Index3()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }
        public IActionResult Index4()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        public IActionResult DetailOrder(string? id)
        {
            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            OrderViewModel orderView = new OrderViewModel();

            OrderViewModel orderViewModel = IntermediateOrderDAO.GetOrderViewModel(order);
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
        public IActionResult DeleteInterOrder(string? id)
        {
            int account_id = HttpContext.Session.GetInt32("Account").Value;


            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            if (order.status == IntermediateOrderEnum.YEU_CAU_QUAN_TRI)
            {
                if (order.buy_user != null)
                {
                    WalletDAO.UpdateWalletDepositBalance(order.buy_user.Value, (int)order.payment_amount);
                }
                IntermediateOrderDAO.DeleteInterOrder(id);
                TempData["Message"] = "Hủy đơn hàng thành công trả tiền cho người mua";
                return RedirectToAction("DetailOrder", new { id = id });
            }
            return RedirectToAction("DetailOrder", new { id = id });
        }
        #region WITHDRAWAL
        public IActionResult WithdrawalManage()
        {
            List<Withdrawal> withdrawals = WithdrawalDAO.GetAllWithdrawal();
            return View(withdrawals);
        }
        public IActionResult DetailWithdrawal(string? id)
        {
            Withdrawal withdrawal = WithdrawalDAO.GetWithdrawalById(id);
            if (withdrawal != null)
            {
                return View(withdrawal);
            }
            return RedirectToAction("WithdrawalManage");

        }
        public IActionResult CompleteWithdrawal(string? id)
        {
            Withdrawal withdrawal = WithdrawalDAO.GetWithdrawalById(id);
            if (withdrawal == null)
            {
                return RedirectToAction("WithdrawalManage");
            }


            if (withdrawal.state == StateEnum.DANG_XU_LI)
            {
                withdrawal.state = StateEnum.THANH_CONG;
                withdrawal.status = StatusEnum.HOAN_THANH;
                withdrawal.update_by = HttpContext.Session.GetInt32("Account").Value;
                WithdrawalDAO.UpdateWithdrawal(withdrawal);
                TempData["Message"] = "Cập nhật trạng thái đơn rút sang thành công";
            }
            else
            {
                TempData["Message"] = "Đơn đã xử lí trước đó, không thể cập nhật";
            }
            return RedirectToAction("DetailWithdrawal", new { id = withdrawal.id });

        }
        #endregion
    }
}