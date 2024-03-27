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
            return View();
        }
        public IActionResult Profile1()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
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
            return View();
        }
        public IActionResult Profile2()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
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
            return View();
        }
        public IActionResult Profile3()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
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
            return View();
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
            return AccountDAO.CheckAccountExist(userName);
            // Sử dụng đối tượng DbContext để kiểm tra tồn tại của userName trong cơ sở dữ liệu
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

        public IActionResult CreateDeposit()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        [HttpPost]
        public IActionResult CreateDeposit(int wallet_id, int amount)
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            Deposit deposit = new Deposit()
            {
                wallet_id = wallet_id,
                amount = amount,
                status = "pending",
                create_by = HttpContext.Session.GetInt32("Account").Value,
                update_by = HttpContext.Session.GetInt32("Account").Value,
            };
            DepositDAO.CreateDeposit(deposit);
            return View();
        }

        public IActionResult CreateWithdrawal()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        [HttpPost]
        public IActionResult CreateWithdrawal(int wallet_id, int amount, string bank_user, string bank_number, string bank_name)
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            Withdrawal withdrawal = new Withdrawal()
            {
                wallet_id = wallet_id,
                amount = amount,
                bank_user = bank_user,
                bank_number = bank_number,
                bank_name = bank_name,
                status = "pending",
                create_by = HttpContext.Session.GetInt32("Account").Value,
                update_by = HttpContext.Session.GetInt32("Account").Value,
            };
            WithdrawalDAO.CreateWithdrawal(withdrawal);
            return View();
        }


        public IActionResult TransactionHistory()
        {
            int id = HttpContext.Session.GetInt32("Account").Value;
            if (id == null) return RedirectToAction("Login", "Home");
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            List<Deposit> deposits = DepositDAO.GetAllDeposit().Where(x => x.wallet_id == WalletDAO.GetWalletByAccountId(id).id).ToList();
            ViewBag.Deposits = deposits;

            List<Withdrawal> withdrawals = WithdrawalDAO.GetAllWithdrawal().Where(x => x.wallet_id == WalletDAO.GetWalletByAccountId(id).id).ToList();
            ViewBag.Withdrawals = withdrawals;
            return View();
        }
        #endregion


    }
}
