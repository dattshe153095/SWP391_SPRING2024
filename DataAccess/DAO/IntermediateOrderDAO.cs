using Business;
using Business.Models;
using DataAccess.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class IntermediateOrderDAO
    {
        public static List<IntermediateOrder> GetAllIntermediateOrder()
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.ToList();
            }
            return list;
        }

        public static IntermediateOrder GetIntermediateOrderById(int id)
        {
            IntermediateOrder order = new IntermediateOrder();

            using (var context = new Web_Trung_GianContext())
            {
                order = context.IntermediateOrders.FirstOrDefault(x => x.id == id);
            }
            return order;
        }

        public static List<IntermediateOrder> GetIntermediateOrderPublic()
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.Where(x => x.is_public == true).ToList();
            }
            return list;
        }

        public static List<IntermediateOrder> GetIntermediateOrderNotBuy()
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.Where(x => x.buy_by != null).ToList();
            }
            return list;
        }

        public static List<IntermediateOrder> GetIntermediateOrderUserBuy(int user_id)
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.Where(x => x.buy_by == user_id).ToList();
            }
            return list;
        }



        public static void BuyIntermediateOrder(IntermediateOrder intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
                intermediateOrder.status = IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG;
                IntermediateOrder order = GetIntermediateOrderById(intermediateOrder.id);

                if (order != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var intermediateOrders = context.Set<IntermediateOrder>();
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

        public static void CreateIntermediateOrder(IntermediateOrder intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
                intermediateOrder.create_at = DateTime.Now;

                using (var context = new Web_Trung_GianContext())
                {
                    var orders = context.Set<IntermediateOrder>();
                    orders.Add(intermediateOrder);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateIntermediateOrder(IntermediateOrder intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
                intermediateOrder.status = IntermediateOrderEnum.MOI_TAO;
                IntermediateOrder order = GetIntermediateOrderById(intermediateOrder.id);

                if (order != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var intermediateOrders = context.Set<IntermediateOrder>();
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
                List<IntermediateOrder> orders = new List<IntermediateOrder>();

                using (var context = new Web_Trung_GianContext())
                {
                    orders = context.IntermediateOrders.Where(x => x.status == IntermediateOrderEnum.MOI_TAO && x.state == StateEnum.DANG_XU_LI).ToList();
                    foreach (var order in orders)
                    {
                        order.status = IntermediateOrderEnum.SAN_SANG_GIAO_DICH;
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
