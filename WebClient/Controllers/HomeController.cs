using DataAccess.Captcha;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using WebClient.Models;
using System.Drawing.Imaging;
using BussinessObject.Models;
using System.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebClient.ViewModel;
using DataAccess.MailSender;
using Microsoft.AspNetCore.Identity;

namespace WebClient.Controllers
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
        public async Task<IActionResult> Login(string username, string password, string captcha,LoginViewModel login)
        {
            //If not invalid info return Page
            if (!ModelState.IsValid && HttpContext.Session.GetString("CaptchaLogin") != captcha) return RedirectToAction("Login", "Home");


            Account account = new Account();
            
            
            account = AccountDAO.Login(username, password);
            if (account != null )
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
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Login Failed";
            return RedirectToAction("Login", "Home");
        }
        #endregion
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
            captchaCode = bm.ToString();
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
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var sessionVerificationCode = HttpContext.Session.GetString("VerificationCode");
            if (ModelState.IsValid && model.CodeValidate == sessionVerificationCode)
            {
                Account account = new Account()
                {
                    name = model.Name,
                    username = model.Username,
                    email = model.Email,
                    phone = model.Phone,
                    password = model.Password,
                    role_id = 2,
                };
                AccountDAO.Register(account);
                return RedirectToAction("Index", "Home");
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
            Bitmap bm = oCaptcha.MakeCaptchaImage(sb.ToString(), 200, 100, "Arial");
            captchaCode = bm.ToString();

            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                ViewBag.CaptchaImageBytes = Convert.ToBase64String(imageBytes);
            }



            return View();

        }

        [HttpPost]
        public IActionResult ForgotPassword( string email, string code, string password, string cfpassword)
        {
            var sessionVerificationCode = HttpContext.Session.GetString("ForgotPassword");
            if (ModelState.IsValid && code == sessionVerificationCode)
            {

                Account account = AccountDAO.GetAccountWithUsernameMail( email);
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
            captchaCode = bm.ToString();

            string imageCaptcha = "";
            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                imageCaptcha = Convert.ToBase64String(imageBytes);
            }
            return Json(imageCaptcha);
        }


    }
}