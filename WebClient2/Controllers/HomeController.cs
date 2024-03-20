using DataAccess.Captcha;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using WebClient2.Models;
using System.Drawing.Imaging;
using Business.Models;
using System.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebClient2.ViewModel;
using Business;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using DataAccess.MailSender;
using Microsoft.AspNetCore.Identity;

namespace WebClient2.Controllers
{

    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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

        #region LOGIN
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
            HttpContext.Session.SetString("CaptchaLogin", sb.ToString());

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
        public async Task<IActionResult> Login(string username, string password, string captcha)
        {
            //If not invalid info return Page
            if (HttpContext.Session.GetString("CaptchaLogin") != captcha) return RedirectToAction("Login", "Home");


            Account account = new Account();


            account = AccountDAO.Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetInt32("Account", account.id);
                string role = "User";
                if (account.role_id == 1)
                {
                    role = "Admin";
                }


                var claims = new List<Claim>
                {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (account.role_id == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Login Failed";
            return RedirectToAction("Login", "Home");
        }
        #endregion
        [HttpPost]
        public IActionResult RefreshCaptchaLogin()
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
            HttpContext.Session.SetString("CaptchaLogin", sb.ToString());
            string imageCaptcha = "";
            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                imageCaptcha = Convert.ToBase64String(imageBytes);
            }
            return Json(imageCaptcha);
        }

        [HttpGet]
        public IActionResult Register()
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
        public IActionResult Register(RegisterViewModel model)
        {
            var sessionVerificationCode = HttpContext.Session.GetString("VerificationCode");
            var sessionVerificationGmail = HttpContext.Session.GetString("VerificationGmail");
            if (ModelState.IsValid && model.CodeValidate == sessionVerificationCode && model.Email == sessionVerificationGmail)
            {
                Account account = new Account()
                {
                    name = model.Name,
                    username = model.Username,
                    email = model.Email,
                    password = model.Password,
                    phone = model.Phone,
                    role_id = 2
                };

                AccountDAO.Register(account);   
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult SendEmail(string email)
        {
            HttpContext.Session.SetString("VerificationCode", EmailSender.SendEmailAsync(email, "", ""));
            HttpContext.Session.SetString("VerificationGmail", email);
            return Json(new { success = true, message = "Email sent successfully!" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult ForgotPassword()
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
            HttpContext.Session.SetString("CaptchaForgot", sb.ToString());
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
        public IActionResult ForgotPassword(string email, string code, string password, string cfpassword, string captcha)
        {
            var sessionVerificationCode = HttpContext.Session.GetString("ForgotPassword");
            var captchaForgot = HttpContext.Session.GetString("CaptchaForgot");
            if (code == sessionVerificationCode && captcha == captchaForgot)
            {

                Account account = AccountDAO.GetAccountWithUsernameMail(email);
                if (account == null)
                {
                    return RedirectToAction("ForgotPassword", "Home");
                }
                else
                {
                    if (password == cfpassword)
                    {
                        account.password = password;
                        AccountDAO.UpdateAccount(account);
                        return RedirectToAction("ForgotPasswordNotification", "Home");
                    }
                    else
                    {
                        return RedirectToAction("ForgotPassword", "Home");
                    }

                }

            }
            else
            {
                return RedirectToAction("ForgotPassword", "Home");

            }
        }
        [HttpGet]
        public IActionResult ForgotPasswordNotification()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendEmailForgot(string email)
        {
            HttpContext.Session.SetString("ForgotPassword", EmailSender.SendEmailAsync(email, "", ""));
            return Json(new { success = true, message = "Email sent successfully!" });
        }

        [HttpPost]

        public IActionResult RefreshCaptchaForgotPassword()
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
            HttpContext.Session.SetString("CaptchaForgot", sb.ToString());
            string imageCaptcha = "";
            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                imageCaptcha = Convert.ToBase64String(imageBytes);
            }
            return Json(imageCaptcha);
        }

        [HttpGet]
        public IActionResult UserNameIsExist(string userName)
        {
            // Kiểm tra xem userName có tồn tại trong cơ sở dữ liệu hay không
            bool isExist = CheckUserExist(userName);

            // Trả về kết quả kiểm tra dưới dạng JSON
            //Nếu tồn tại thì trả về false để username k hợp lệ
            return Json(!isExist);
        }

        private bool CheckUserExist(string userName)
        {
            return AccountDAO.CheckAccountExist(userName);
            // Sử dụng đối tượng DbContext để kiểm tra tồn tại của userName trong cơ sở dữ liệu
        }

    }
}