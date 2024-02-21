using Microsoft.AspNetCore.Mvc;
using BussinessObject.Models;
using DataAccess.Captcha;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace WebClient.Controllers
{
    public class HistoryOrderController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductDAO.GetAllProduct();
            ViewBag.Products = products;
            return View();
        }


        [HttpGet]
        public IActionResult GetProductDetail(int productId)
        {
            var product = ProductDAO.GetProductWithId(productId);

            if (product != null)
            {
                return Json(product);
            }
            else
            {
                return Json(new { message = "Không tìm thấy thông tin sản phẩm." });
            }
        }
    }
}
