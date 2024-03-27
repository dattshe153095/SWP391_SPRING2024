using Business.Models;
using DataAccess.DAO;
using DataAccess.Library;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebClient2.BackGroundServices;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult InterOrderManage()
        {
            List<IntermediateOrder> order = IntermediateOrderDAO.GetAllIntermediateOrders();
            return View(order);
        }

        public IActionResult DetailOrder(string? id)
        {
            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            OrderViewModel orderView = new OrderViewModel();

            //MapData
            orderView = IntermediateOrderDAO.GetOrderViewModel(order);
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

        public IActionResult UnCompleteWithdrawal(string? id)
        {
            Withdrawal withdrawal = WithdrawalDAO.GetWithdrawalById(id);
            if (withdrawal == null)
            {
                return RedirectToAction("WithdrawalManage");
            }

            if (withdrawal.state == StateEnum.DANG_XU_LI)
            {
                withdrawal.state = StateEnum.THAT_BAI;
                withdrawal.status = StatusEnum.XAC_NHAN_THAT_BAI;
                withdrawal.update_by = HttpContext.Session.GetInt32("Account").Value;
                WithdrawalDAO.UpdateWithdrawal(withdrawal);
                WalletDAO.UpdateWalletDepositBalance(WalletDAO.GetWalletById(withdrawal.wallet_id).id, withdrawal.amount);
                TempData["Message"] = "Cập nhật trạng thái đơn rút sang thất bại, đã trả tiền về cho người dùng";
            }
            else
            {
                TempData["Message"] = "Đơn đã xử lí trước đó, không thể cập nhật";
            }
            return RedirectToAction("DetailWithdrawal", new { id = withdrawal.id });

        }

        #endregion
        #region USER MANAGE
        public IActionResult UserManage()
        {
            List<Account> accounts = AccountDAO.GetAllAccount();
            return View(accounts);
        }

        public IActionResult DetailUser(int? id)
        {
            Account account = AccountDAO.GetAccountWithId(id);
            if (account != null)
            {
                return View(account);
            }
            return RedirectToAction("UserManage");
        }

        [HttpPost]
        public IActionResult AddMoneyForUser(int id, int amount)
        {
            if (amount < 0)
            {
                TempData["ErrorAmount"] = "Số tiền không hợp lệ";
                return RedirectToAction("DetailUser", new { id = id });
            }

            WalletDAO.UpdateWalletDepositBalance(id, amount);
            TempData["ErrorAmount"] = "Nạp tiền cho người dùng thành công";
            return RedirectToAction("DetailUser", new { id = id });
        }
        #endregion

    }
}
