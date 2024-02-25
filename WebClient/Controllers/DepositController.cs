﻿using Business.Models;
using DataAccess.DAO;
using DataAccess.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebClient.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class DepositController : Controller
    {
        #region DEPOSIT

        [HttpPost]
        public ActionResult Deposit(int deposit_id, int amount, string desctiption)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int account_id = HttpContext.Session.GetInt32("Account").Value;
            string code = Gencode.GenerateCodeDeposit(account_id);
            Deposit deposit = new Deposit()
            {
                wallet_id = WalletDAO.GetWalletByAccountId(account_id).id,
                amount = amount,
                trans_code = code,
                status = "đang chờ xử lí",
                state = "đang xử lí",
                description = desctiption,
                create_by = account_id,
                update_by = account_id,
            };

            DepositDAO.CreateDeposit(deposit);
            Deposit d = DepositDAO.GetDepositTransactionCode(WalletDAO.GetWalletByAccountId(account_id).id, code);
            return Json(d);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DepositConfirm(int deposit_id, string description)
        {
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int account_id = HttpContext.Session.GetInt32("Account").Value;
            DepositResponse depositResponse = new DepositResponse()
            {
                deposit_id = deposit_id,
                type_transaction="nạp tiền",
                description = description,
                status = "đang xử lí",
                state = "đang xử lí",
                create_by = account_id,
                update_by = account_id,
            };
            return View();
        }


        #endregion
    }
}