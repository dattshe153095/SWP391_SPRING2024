using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using WebClient2.BackGroundServices;
using WebClient2.ViewModel;
using DataAccess.DAO;
using DataAccess.Library;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    [Authorize(Roles = "Admin,User")]
    public class WithdrawalsController : Controller
    {
        public IActionResult List()
        {
            int account_id = HttpContext.Session.GetInt32("Account").Value;

            List<Withdrawal> withdrawals = WithdrawalDAO.GetAllWithdrawalByWalletId(WalletDAO.GetWalletByAccountId(account_id).id);
            return View(withdrawals);
        }
        // GET: Withdrawals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Withdrawals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WithdrawalModel withdrawal)
        {
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            if (ModelState.IsValid)
            {
                if (withdrawal.amount + 500 <= WalletDAO.GetWalletByAccountId(account_id).balance)
                {
                    WalletDAO.UpdateWalletWithdrawalBalance(WalletDAO.GetWalletByAccountId(account_id).id, withdrawal.amount+ 500);
                    Withdrawal w = new Withdrawal
                    {
                        id = Gencode.GenerateCodeWithdrawal(),
                        wallet_id = WalletDAO.GetWalletByAccountId(account_id).id,
                        amount = withdrawal.amount,
                        bank_number = withdrawal.bank_number,
                        bank_user = withdrawal.bank_user,
                        bank_name = withdrawal.bank_name,
                        create_by = account_id,
                        update_by = account_id,
                    };

                    WithdrawalDAO.CreateWithdrawal(w);

                }
                else
                {

                    TempData["Message"] = $"Không đủ tiền thanh toán";
                    return RedirectToAction(nameof(Create));

                }

            }
            return View(withdrawal);
        }

    }
}
