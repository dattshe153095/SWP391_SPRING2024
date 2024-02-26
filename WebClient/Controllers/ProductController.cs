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
using WebClient.ViewModel;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult InsertProduct()
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            return View();
        }

        [HttpPost]
        public IActionResult InsertProduct(ProductViewModel p)
        {
            int id_account = 0;
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            id_account = HttpContext.Session.GetInt32("Account").Value;
            Product product = new Product();
            product.name = p.name;
            product.code = "UIA3HFIU3";
            product.name = p.name;
            product.price = p.price;
            product.quantity = p.quantity;
            product.categories = 1;
            product.content = p.content;
            product.desctiption = p.description;
            product.link = "#";
            product.create_by = id_account;
            product.update_by = id_account;
            ProductDAO.InsertProduct(product);
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.accountId = HttpContext.Session.GetInt32("Account");
            var product = ProductDAO.GetProductWithId(id);
            ViewBag.Product = product;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateProduct(int id, string code, int price, int quantity, int categories, string desctiption)
        {
            var product = ProductDAO.GetProductWithId(id);

            product.code = code; product.price = price; product.quantity = quantity; product.categories = categories; product.desctiption = desctiption;
            ProductDAO.UpdateProduct(product);
            ViewBag.Product = product;

            return RedirectToAction("UpdateProduct", new { id = product.id });
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public IActionResult BuyProduct(int id)
        {
            int id_account = 0;
            if (HttpContext.Session.GetInt32("Account") == null)
            {
                return Json(new { message = "Hãy đăng nhập" });
            }
            else if (id_account != null)
            {
                id_account = HttpContext.Session.GetInt32("Account").Value;
                Wallet wallet = WalletDAO.GetWalletByAccountId(id_account);

                var product = ProductDAO.GetProductWithId(id);

                if (product != null)
                {
                    if (product.quantity > 0)
                    {
                        if (wallet.balance >= product.price)
                        {
                            OrderDAO.BuyProductOrder(id_account, id);
                            return Json(new { message = "Mua thành công" });
                        }
                        else
                        {
                            return Json(new { message = "Không đủ tiền" });
                        }


                    }
                    else
                    {
                        return Json(new { message = "Hết hàng" });
                    }

                }
                else
                {
                    return Json(new { message = "Mua thất bại" });
                }
            }
            return Json(new { message = "Mua thất bại có lỗi xảy ra" });
        }
    }
}