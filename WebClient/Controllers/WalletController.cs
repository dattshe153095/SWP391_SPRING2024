using BussinessObject.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class WalletController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WithdrawalTransaction()
        {
            return View();
        }

        public ActionResult DepositTransaction()
        {
            List<Wallet> wallets = new List<Wallet>();
            wallets = WalletDAO.GetAllWallet();
            ViewBag.Wallets = wallets;
            return View();
        }

        public ActionResult ReportTransaction()
        {
            return View();
        }
    }
}
