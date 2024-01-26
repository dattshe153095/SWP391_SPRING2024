﻿using BussinessObject;
using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace WebClient.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Profile()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(string name, string description)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Account account = AccountDAO.GetAccountWithId(id);
                
                account.name = name;
                account.description = description;
                AccountDAO.UpdateAccount(account);
                return RedirectToAction("Profile", "Account");

            }
            return RedirectToAction("Profile", "Account");
        }

        [HttpPost]
        public IActionResult ChangePassword(string new_password, string confirmPassword)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Account account = AccountDAO.GetAccountWithId(id);
                if (new_password.Equals(confirmPassword))
                {
                    account.password = new_password;
                    AccountDAO.UpdateAccount(account);
                }
                return RedirectToAction("Profile", "Account");

            }
            return RedirectToAction("Profile", "Account");
        }

        [HttpGet]
        public IActionResult UserNameIsExist(string userName)
        {
            // Kiểm tra xem userName có tồn tại trong cơ sở dữ liệu hay không
            bool isExist = CheckIfUserNameExists(userName);

            // Trả về kết quả kiểm tra dưới dạng JSON
            return Json(!isExist);
        }

        private bool CheckIfUserNameExists(string userName)
        {
            // Sử dụng đối tượng DbContext để kiểm tra tồn tại của userName trong cơ sở dữ liệu
            return false;
        }
    }
}
