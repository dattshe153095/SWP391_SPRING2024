﻿using BussinessObject.Models;
using DataAccess.Captcha;
using DataAccess.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

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


        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = ProductDAO.GetProductWithId(id);

            ViewBag.Product = product;

            return View();
        }

        [HttpPost]
        public IActionResult UpdateProduct(int id, string code, int price, int quantity, int categories, string desctiption)
        {
            var product = ProductDAO.GetProductWithId(id);

            product.code = code; product.price = price; product.quantity = quantity; product.categories = categories; product.desctiption = desctiption;
            ProductDAO.UpdateProduct(product);
            ViewBag.Product = product;

            return RedirectToAction("UpdateProduct", new { id = product.id });
        }

        [HttpPost]
        public IActionResult BuyProduct(int id)
        {
            var product = ProductDAO.GetProductWithId(id);

            if (product != null)
            {
                if (product.quantity > 0)
                {
                    OrderDAO.BuyProductOrder(id);

                }
                return Json(new { message = "Mua thành công" });
            }
            else
            {
                return Json(new { message = "Mua thất bại" });
            }
        }
    }
}