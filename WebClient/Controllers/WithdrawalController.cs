using Business.Models;
using DataAccess.DAO;
using DataAccess.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebClient2.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class WithdrawalController : Controller
    {
        #region WITHDRAWAL
        [HttpPost]
        public ActionResult Withdrawal(int withdrawal_id, int amount)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int account_id = HttpContext.Session.GetInt32("Account").Value;
            if (WalletDAO.GetWalletByAccountId(account_id).balance >= amount)
            {
                return Json("Tài khoản không đủ số dư");
            }

            string code = Gencode.GenerateCodeDeposit(account_id);
            Withdrawal withdrawal = new Withdrawal()
            {
                wallet_id = WalletDAO.GetWalletByAccountId(account_id).id,
                amount = amount,
                trans_code = code,
                status = "đang chờ xử lí",
                state = "đang xử lí",
                create_by = account_id,
                update_by = account_id,
            };

            WithdrawalDAO.CreateWithdrawal(withdrawal);
            Withdrawal w = WithdrawalDAO.GetWithdrawalTransactionCode(WalletDAO.GetWalletByAccountId(account_id).id, code);
            return Json(w);
        }

        public ActionResult WithdrawalTransaction()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            List<Withdrawal> withdrawals = new List<Withdrawal>();
            withdrawals = WithdrawalDAO.GetAllWithdrawal();
            ViewBag.Withdrawals = withdrawals;
            return View();
        }

        public ActionResult WithdrawalDetail(int withdrawal_id)
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            Withdrawal withdrawal = new Withdrawal();
            withdrawal = WithdrawalDAO.GetWithdrawalById(withdrawal_id);
            ViewBag.Withdrawal = withdrawal;
            return View();
        }

        [HttpPost]
        public ActionResult WithdrawalHandle(int withdrawal_id, string status)
        {
            Withdrawal withdrawal = new Withdrawal();
            withdrawal = WithdrawalDAO.GetWithdrawalById(withdrawal_id);
            if (WalletDAO.GetWalletById(withdrawal.wallet_id).balance >= (withdrawal.amount))
            {

                withdrawal.status = status;
                WithdrawalDAO.UpdateWithdrawal(withdrawal);

                return RedirectToAction("WithdrawalDetail", new { withdrawal_id = withdrawal_id });
            }
            else
            {
                return RedirectToAction("WithdrawalDetail", new { withdrawal_id = withdrawal_id });
            }

        }

        #endregion
    }
}
