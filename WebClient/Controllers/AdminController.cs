using BussinessObject.Models;
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

namespace WebClient.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }


        #region
        [HttpGet]
        public IActionResult Login()
        {
            Captcha oCaptcha = new Captcha();
            Random rnd = new Random();
            string[] s = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int i;
            StringBuilder sb = new StringBuilder(4);
            for (i = 0; i <= 4; i++)
            {
                sb.Append(s[rnd.Next(1, s.Length)]);
            }
            Bitmap bm = oCaptcha.MakeCaptchaImage(sb.ToString(), 200, 100, "Arial");

            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                ViewBag.CaptchaImageBytes = Convert.ToBase64String(imageBytes);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            //If not invalid info return Page
            if (!ModelState.IsValid) return View();

            Account account = new Account();
            account = AccountDAO.Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetInt32("Account", account.id);
                if (account.role_id == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }


            }

            return View();
        }
        #endregion

    }


}
