using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Models;
using WebClient2.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using DataAccess.DAO;
using DataAccess.Library;
using WebClient2.BackGroundServices;
using WebClient2.ViewModel;

namespace WebClient2.Controllers
{

    [ServiceFilter(typeof(SemaphoreActionFilter))]
    [Authorize(Roles = "Admin,User")]
    public class DepositsController : Controller
    {
        private readonly IVnPayService _vpnPayService;
        public DepositsController(IVnPayService vnPayServices)
        {
            _vpnPayService = vnPayServices;
        }

        // GET: Deposits/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            return View();
        }

        #region VNPAY
        [HttpPost]
        public IActionResult VnPay(DepositModel deposit)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int account_id = HttpContext.Session.GetInt32("Account").Value;
            if (ModelState.IsValid)
            {
                string id = Gencode.GenerateCodeDeposit();
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = deposit.amount,
                    CreatedDate = DateTime.Now,
                    Description = deposit.description == null ? "" : deposit.description,
                    Id = id,
                };
                return Redirect(_vpnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
            }
            return RedirectToAction(nameof(Create));
        }

        public IActionResult PaymentFail()
        {
            return View();
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult PaymentCallBack()
        {
            if (Request.Query.Count == 0)
            {
                TempData["Message"] = $"Lỗi thanh toán VN Pay"; return RedirectToAction("PaymentFail");
            }

            var response = _vpnPayService.PaymentExecute(Request.Query);
            try
            {


                if (response == null || response.VnPayReponseCode != "00") // Gia tri 00 la thanh cong
                {
                    TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayReponseCode}";
                    return RedirectToAction("PaymentFail");
                }
                int user_id = HttpContext.Session.GetInt32("Account").Value;
                //Lưu đơn hàng cho Database
                Deposit d = new Deposit
                {
                    id = response.OrderId,
                    wallet_id = WalletDAO.GetWalletByAccountId(user_id).id,
                    amount = response.Amount,
                    status = StatusEnum.HOAN_THANH,
                    state = StateEnum.THANH_CONG,
                    description = response.OrderDescription,
                    create_by = user_id,
                    create_at = DateTime.Now,
                    update_by = user_id,
                    update_at = DateTime.Now,
                };
                DepositDAO.CreateDeposit(d);
                WalletDAO.UpdateWalletDepositBalance(d.wallet_id, d.amount);

                TempData["Message"] = $"Thanh toán VN Pay thành công";
                return RedirectToAction("PaymentSuccess");
            }
            catch (Exception ex) { TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayReponseCode}"; return RedirectToAction("PaymentFail"); }

        }
        #endregion
    }
}
