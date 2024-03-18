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

        public IActionResult OrderDetail(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IntermediateOrder intermediateOrder = new IntermediateOrder();
            intermediateOrder = IntermediateOrderDAO.GetIntermediateOrderById(id);
            OrderViewModel order = new OrderViewModel();

            //MapData
            order = IntermediateOrderDAO.GetOrderViewModel(intermediateOrder);

            if (intermediateOrder == null)
            {
                return NotFound();
            }

            //return View(order);
            return PartialView("_ModalOrder", order);
        }

        public IActionResult DepositManage()
        {
            List<Deposit> deposits= DepositDAO.GetAllDeposit();
            return View(deposits);
        }

        public IActionResult WithdrawalManage()
        {
            List<Withdrawal> withdrawals = WithdrawalDAO.GetAllWithdrawal();
            return View(withdrawals);
        }
        public IActionResult UserManage()
        {
            List<Account> accounts = AccountDAO.GetAllAccount();
            return View(accounts);
        }


    }
}
