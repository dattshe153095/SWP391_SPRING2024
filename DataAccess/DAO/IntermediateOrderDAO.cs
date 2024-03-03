using Business;
using Business.Models;
using DataAccess.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class IntermediateOrderDAO
    {
        public static List<IntermediateOrder> GetAllIntermediateOrders()
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
    }
}
