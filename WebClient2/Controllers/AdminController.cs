using Business.Models;
using DataAccess.DAO;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebClient2.BackGroundServices;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult InterOrderManage()
        {
            List<IntermediateOrder> order = IntermediateOrderDAO.GetInterAbleToSell();
            return View(order);
        }

        public IActionResult DetailOrder(string? id)
        {
            IntermediateOrder order = IntermediateOrderDAO.GetIntermediateOrderById(id);
            return View(order);
        }

        public IActionResult DepositManage()
        {
            List<Deposit> deposits= DepositDAO.GetAllDeposit();
            return View(deposits);
        }
        public IActionResult DetailDeposit(string? id)
        {
            List<Deposit> deposits = DepositDAO.GetAllDeposit();
            return View(deposits);
        }

        public IActionResult WithdrawalManage()
        {
            List<Withdrawal> withdrawals = WithdrawalDAO.GetAllWithdrawal();
            return View(withdrawals);
        }
        public IActionResult DetailWithdrawal(string? id)
        {
            List<Deposit> deposits = DepositDAO.GetAllDeposit();
            return View(deposits);
        }

        public IActionResult UserManage()
        {
            List<Account> accounts = AccountDAO.GetAllAccount();
            return View(accounts);
        }

        public IActionResult DetailUser(int? id)
        {
            List<Deposit> deposits = DepositDAO.GetAllDeposit();
            return View(deposits);
        }


    }
}
