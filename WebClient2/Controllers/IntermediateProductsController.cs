using Business;
using Business.Models;
using DataAccess.DAO;
using DataAccess.Library;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebClient2.BackGroundServices;

namespace WebClient2.Controllers
{
    [ServiceFilter(typeof(SemaphoreActionFilter))]
    public class IntermediateProductsController : Controller
    {
        public IntermediateProductsController()
        {
        }

        public IActionResult Index()
        {
            ViewBag.account_id = HttpContext.Session.GetInt32("Account");
            List<IntermediateProduct> intermediateProducts = IntermediateProductDAO.GetAllIntermediateProduct();
            return View(intermediateProducts);
        }
        public IActionResult Details(int? id)
        {
            IntermediateProduct intermediateOrder = IntermediateProductDAO.GetIntermediateProductById(id.Value);
            if (id == null || intermediateOrder == null)
            {
                return NotFound();
            }

            ProductViewModel order = new ProductViewModel();
            //MapData
            order = IntermediateProductDAO.GetProductViewModel(intermediateOrder);

            if (intermediateOrder == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string name, int price, bool fee_type, string description, string contact, string hidden_content, bool is_public)
        {
            IntermediateProduct order = new IntermediateProduct();
            if (ModelState.IsValid)
            {
                //int user_id = HttpContext.Session.GetInt32("Account").Value;

                if (WalletDAO.GetWalletByAccountId(14).balance < 100)
                {
                    ModelState.AddModelError(string.Empty, "Không đủ tiền trong tài khoản! Tài khoản hiện tại có: " + WalletDAO.GetWalletByAccountId(14).balance);
                }
                else
                {
                    WalletDAO.UpdateWalletBuyOrder(WalletDAO.GetWalletByAccountId(14).id, 500);
                    order = new IntermediateProduct()
                    {
                        name = name,
                        price = price,
                        fee_type = fee_type,
                        description = description,
                        contact = contact,
                        hidden_content = hidden_content,
                        is_public = is_public,
                        fee = Convert.ToInt32(price * Constant.FEE),
                        state = StateEnum.DANG_XU_LI,
                        create_by = 14,
                        create_at = DateTime.Now,
                        update_by = 14,
                        update_at = DateTime.Now,
                    };

                    IntermediateProductDAO.CreateIntermediateOrder(order);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(order);
        }

    }
}
