using BussinessObject;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public static List<Product> GetAllProduct()
        {
            List<Product> list = new List<Product>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Products.ToList();

            }
            return list;
        }
        public static Product GetProductWithId(int? id)
        {
            return GetAllProduct().FirstOrDefault(x => x.id == id);
        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                product.update_at = DateTime.Now;
                Product c = GetProductWithId(product.id);
                if (c != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var products = context.Set<Product>();
                        products.Update(product);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Product does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void InsertProduct(Product product)
        {
            product.create_at = DateTime.Now;
            product.update_at = DateTime.Now;

            using (var context = new Web_Trung_GianContext())
            {
                var products = context.Set<Product>();
                products.Add(product);
                context.SaveChanges();
            }
        }

    }
}