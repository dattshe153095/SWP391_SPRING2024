using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public static List<Order> GetAllOrder()
        {
            List<Order> list = new List<Order>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Orders.ToList();
            }
            return list;
        }

        public static Order GetOrderById(int id)
        {
            return GetAllOrder().FirstOrDefault(x => x.id == id);
        }

        public static void BuyProductOrder(int accountId, int productId)
        {
            Wallet wallet = WalletDAO.GetWalletById(accountId);
            Product product = ProductDAO.GetProductWithId(productId);
            Order order = new Order() { product_id = productId, quantity = 1, total_price = product.price, account_id = accountId, create_by = accountId, create_at = DateTime.Now, update_by = accountId, update_at = DateTime.Now };
            
            using (var context = new Web_Trung_GianContext())
            {
                var orders = context.Set<Order>();
                orders.Add(order);

                wallet.balance -= product.price;
                var wallets = context.Set<Wallet>();
                wallets.Update(wallet);

                product.quantity--;
                var products = context.Set<Product>();
                products.Update(product);

                context.SaveChanges();


            }
        }
    }
}
