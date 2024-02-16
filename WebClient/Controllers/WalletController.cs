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
            List<Deposit> deposits = new List<Deposit>();
            deposits = DepositDAO.GetAllDeposit();
            ViewBag.Deposits = deposits;
            return View();
        }

        public ActionResult ReportTransaction()
        {
            List<TransactionError> transactionErrors = new List<TransactionError>();
            transactionErrors = TransactionErrorDAO.GetAllTransactionError();
            ViewBag.TransactionErrors = transactionErrors;
            return View();
        }
    }
}
