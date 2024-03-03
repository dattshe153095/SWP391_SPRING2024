using Business.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebClient2.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUserController : Controller
    {
        public IActionResult ViewUser()
        {
            List<Account> accounts = AccountDAO.GetAllAccount();
            ViewBag.Accounts = accounts;
            return View();
        }

        public IActionResult UserDetail(int userId)
        {
            Account account = AccountDAO.GetAccountWithId(userId);

            ViewBag.Account = account;
            return View(account);
        }

        [HttpPost]
        public IActionResult DeleteAccount(int userId)
        {
            AccountDAO.DeleteAccount(userId);
            return Json(new { success = true });
        }

        public IActionResult SearchByUsername(string username)
        {
            // Thực hiện tìm kiếm theo tên người dùng
            List<Account> result = AccountDAO.GetAccountWithUsername(username);

            // Trả về kết quả dưới dạng JSON
            return Json(result);
        }
    }
}
