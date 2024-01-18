using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers.Admin
{
    public class ManageUserAccountController : Controller
    {
        public IActionResult ViewUserAccount()
        {
            List<Account> accounts = AccountDAO.GetAllAccount();
            ViewBag.Accounts = accounts;
            return View();
        }
    }
}
