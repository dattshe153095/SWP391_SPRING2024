using Business;
using Business.Models;
using DataAccess.Library;
using DataAccess.ViewModel;
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
                list = context.IntermediateOrders.Where(x => x.is_delete == false).ToList();
            }
            return list;
        }

        public static IntermediateOrder GetIntermediateOrderById(string id)
        {
            IntermediateOrder order = new IntermediateOrder();

            using (var context = new Web_Trung_GianContext())
            {
                order = context.IntermediateOrders.FirstOrDefault(x => x.id == id);
            }
            return order;
        }
        public static void BuyIntermediateOrder(int user_id, IntermediateOrder intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
                intermediateOrder.buy_at = DateTime.Now;
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
                intermediateOrder.state = StateEnum.DANG_XU_LI;
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
                    orders = context.IntermediateOrders.Where(x => x.status == IntermediateOrderEnum.MOI_TAO && x.state == StateEnum.DANG_XU_LI && x.is_delete==false).ToList();
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


        public static OrderViewModel GetOrderViewModel(IntermediateOrder order)
        {
            OrderViewModel viewModel = new OrderViewModel()
            {
                code = order.id.ToString(),
                account_create = AccountDAO.GetAccountWithId(order.create_by),
                account_buy = AccountDAO.GetAccountWithId(order.buy_user),
                state = order.state,
                status = order.status,
                name = order.name,
                price = order.price,
                fee_type = order.fee_type,
                description = order.description,
                contact = order.contact,
                hidden_content = order.hidden_content,
                is_public = order.is_public,
                create_at = order.create_at,
                update_at = order.update_at,
                link_share = "#"
            };
            return viewModel;
        }
    }
}
