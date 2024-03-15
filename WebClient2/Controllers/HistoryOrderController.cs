using Business.Models;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;

namespace WebClient2.Controllers
{
    public class HistoryOrderController : Controller
    {
        public IActionResult HistoryOrder()
        {
            List<IntermediateOrder> order = IntermediateOrderDAO.GetInterAbleToSell();
            return View(order);
        }
    }
}
