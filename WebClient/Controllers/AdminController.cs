﻿using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProfileAdmin()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(string name, string email)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Admin admin = AdminDAO.GetAdminWithId(id);
                admin.Name = name;
                admin.Email = email;
                AdminDAO.UpdateAdmin(admin);
                return RedirectToAction("ProfileAdmin", "Admin");

            }
            return RedirectToAction("ProfileAdmin", "Admin");
        }

        [HttpPost]
        public IActionResult ChangePassword(string password, string confirmPassword)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Admin account = AdminDAO.GetAdminWithId(id);
                if (password.Equals(confirmPassword))
                {
                    account.Password = password;
                    AdminDAO.UpdateAdmin(account);
                }
                return RedirectToAction("ProfileAdmin", "Admin");

            }
            return RedirectToAction("ProfileAdmin", "Admin");
        }
    }


}
