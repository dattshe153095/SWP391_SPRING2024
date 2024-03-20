using Business.Models;
using DataAccess.Captcha;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace WebClient2.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class AccountController : Controller
    {
        public IActionResult Profile()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            int accountId = HttpContext.Session.GetInt32("Account").Value;
            //CAPTCHA
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
            HttpContext.Session.SetString("CaptchaChangePass", sb.ToString());

            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                ViewBag.CaptchaImageBytes = Convert.ToBase64String(imageBytes);
            }

            //MESSAGE
            ViewBag.ChangePasswordSuccess = TempData["SuccessMessage"];
            return View(AccountDAO.GetAccountWithId(accountId));
        }

        [HttpPost]
        public IActionResult UpdateProfile(string name, string description, String phone)
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Account account = AccountDAO.GetAccountWithId(id);

                account.name = name;
                account.description = description;
                account.phone = phone;
                AccountDAO.UpdateAccount(account);
                return RedirectToAction("Profile", "Account");

            }
            return RedirectToAction("Profile", "Account");
        }


        [HttpPost]
        public IActionResult ChangePassword(string new_password, string confirmPassword, string captcha, string old_password)
        {
            if (HttpContext.Session.GetString("CaptchaChangePass") != captcha) { return RedirectToAction("Profile", "Account"); }
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                int? id = HttpContext.Session.GetInt32("Account");
                Account account = AccountDAO.GetAccountWithId(id);
                if (!old_password.Equals(account.password))
                {

                    return RedirectToAction("Profile", "Account");

                }
                if (new_password.Equals(confirmPassword))
                {
                    account.password = new_password;
                    AccountDAO.UpdateAccount(account);
                }
                TempData["SuccessMessage"] = "Mật khẩu đã được đổi thành công.";
                return RedirectToAction("Profile", "Account");

            }
            return RedirectToAction("Profile", "Account");
        }





        [HttpPost]
        public IActionResult RefreshCaptcha()
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
            HttpContext.Session.SetString("CaptchaChangePass", sb.ToString());

            string imageCaptcha = "";
            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                imageCaptcha = Convert.ToBase64String(imageBytes);
            }
            return Json(imageCaptcha);
        }


        #region Wallet
        public IActionResult Wallet()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            List<Wallet> wallets = new List<Wallet>();
            wallets = WalletDAO.GetAllWallet();
            ViewBag.Wallets = wallets;
            return View();
        }
        #endregion


    }
}
