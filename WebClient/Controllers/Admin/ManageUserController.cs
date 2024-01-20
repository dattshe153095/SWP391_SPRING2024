using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers.Admin
{
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
    }
}
