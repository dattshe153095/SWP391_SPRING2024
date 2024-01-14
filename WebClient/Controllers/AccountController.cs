using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult UpdateProfile(string name, string email)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Account account = AccountDAO.GetAccountWithId(id);
                account.Name = name;
                account.Email = email;
                AccountDAO.UpdateAccount(account);
                return RedirectToAction("Profile", "Account");

            }
            return RedirectToAction("Profile", "Account");
        }

        [HttpPost]
        public IActionResult ChangePassword(string password, string confirmPassword)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Account account = AccountDAO.GetAccountWithId(id);
                if (password.Equals(confirmPassword))
                {
                    account.Password = password;
                    AccountDAO.UpdateAccount(account);
                }
                return RedirectToAction("Profile", "Account");

            }
            return RedirectToAction("Profile", "Account");
        }
    }
}
