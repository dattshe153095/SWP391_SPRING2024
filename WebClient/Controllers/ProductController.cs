using BussinessObject.Models;
using DataAccess.Captcha;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductDAO.GetAllProduct();
            ViewBag.Products = products;
            return View();
        }

    }
}