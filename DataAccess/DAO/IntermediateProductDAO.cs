using Business;
using Business.Models;
using DataAccess.ViewModel;
using DataAccess.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class IntermediateProductDAO
    {
        public static List<IntermediateProduct> GetAllIntermediateProduct()
        {
            List<IntermediateProduct> list = new List<IntermediateProduct>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateProducts.ToList();
            }
            return list;
        }

        public static IntermediateProduct GetIntermediateProductById(int id)
        {
            IntermediateProduct order = new IntermediateProduct();

            using (var context = new Web_Trung_GianContext())
            {
                order = context.IntermediateProducts.FirstOrDefault(x => x.id == id);
            }
            return order;
        }

        //public static List<IntermediateProduct> GetIntermediateOrderPublic()
        //{
        //    List<IntermediateProduct> list = new List<IntermediateProduct>();

        //    using (var context = new Web_Trung_GianContext())
        //    {
        //        list = context.IntermediateOrders.Where(x => x.is_public == true).ToList();
        //    }
        //    return list;
        //}

        //public static List<IntermediateProduct> GetIntermediateOrderNotBuy()
        //{
        //    List<IntermediateProduct> list = new List<IntermediateProduct>();

        //    using (var context = new Web_Trung_GianContext())
        //    {
        //        list = context.IntermediateOrders.Where(x => x.buy_by != null).ToList();
        //    }
        //    return list;
        //}

        //public static List<IntermediateProduct> GetIntermediateOrderUserBuy(int user_id)
        //{
        //    List<IntermediateProduct> list = new List<IntermediateProduct>();

        //    using (var context = new Web_Trung_GianContext())
        //    {
        //        list = context.IntermediateOrders.Where(x => x.buy_by == user_id).ToList();
        //    }
        //    return list;
        //}



        public static void BuyIntermediateOrder(IntermediateProduct intermediateOrder)
        {
            try
            {
                //intermediateOrder.update_at = DateTime.Now;
                //intermediateOrder.status = IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG;
                //IntermediateProduct order = GetIntermediateOrderById(intermediateOrder.id);

                //if (order != null)
                //{
                //    using (var context = new Web_Trung_GianContext())
                //    {
                //        var intermediateOrders = context.Set<IntermediateProduct>();
                //        intermediateOrders.Update(intermediateOrder);
                //        context.SaveChanges();
                //    }
                //}

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CreateIntermediateOrder(IntermediateProduct intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
                intermediateOrder.create_at = DateTime.Now;

                using (var context = new Web_Trung_GianContext())
                {
                    var orders = context.Set<IntermediateProduct>();
                    orders.Add(intermediateOrder);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateIntermediateOrder(IntermediateProduct intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
                intermediateOrder.state = StateEnum.DANG_XU_LI;
                IntermediateProduct order = GetIntermediateProductById(intermediateOrder.id);

                if (order != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var intermediateOrders = context.Set<IntermediateProduct>();
                        intermediateOrders.Update(intermediateOrder);
                        context.SaveChanges();
                    }
                }


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void HandleIntermediateOrderCreate()
        {
            try
            {
                List<IntermediateProduct> orders = new List<IntermediateProduct>();

                using (var context = new Web_Trung_GianContext())
                {
                    //orders = context.IntermediateOrders.Where(x => x.status == IntermediateOrderEnum.MOI_TAO && x.state == StateEnum.DANG_XU_LI).ToList();
                    //foreach (var order in orders)
                    //{
                    //    order.status = IntermediateOrderEnum.SAN_SANG_GIAO_DICH;
                    //}
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static OrderViewModel GetOrderViewModel(IntermediateProduct order)
        {
            OrderViewModel viewModel = new OrderViewModel()
            {
                //code = order.id.ToString(),
                //account_create = AccountDAO.GetAccountWithId(order.create_by),
                //account_buy = AccountDAO.GetAccountWithId(order.buy_by),
                //state = order.state,
                //status = order.status,
                //name = order.name,
                //price = order.price,
                //fee_type = order.fee_type,
                //description = order.description,
                //contact = order.contact,
                //hidden_content = order.hidden_content,
                //is_public = order.is_public,
                //create_at = order.create_at,
                //update_at = order.update_at,
                //link_share = "#"

            };
            return viewModel;

        }

    }
}
