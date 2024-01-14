using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //If not invalid info return Page
            if (!ModelState.IsValid) return View();

            Admin admin = new Admin();
            admin = AdminDAO.LoginAdmin(username, password);

            if (admin != null)
            {
                HttpContext.Session.SetInt32("Account", admin.Id);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                Account account = new Account();
                account = AccountDAO.Login(username, password);
                if (account != null)
                {
                    HttpContext.Session.SetInt32("Account", account.Id);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        #endregion

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}