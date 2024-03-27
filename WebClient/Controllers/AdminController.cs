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


    }


}
