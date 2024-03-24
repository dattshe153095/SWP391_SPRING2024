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
                list = context.IntermediateOrders.Where(x => x.is_delete == false).OrderByDescending(x=>x.update_at).ToList();
            }
            return list;
        }

        public static List<IntermediateOrder> GetInterAbleToSell()
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.
                    Where(x => x.is_delete == false
                    && x.buy_user == null
                    && x.is_public == true
                    && x.status == IntermediateOrderEnum.SAN_SANG_GIAO_DICH
                    ).OrderByDescending(x => x.update_at)
                    .ToList();
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
                    orders = context.IntermediateOrders.Where(x => x.status == IntermediateOrderEnum.MOI_TAO && x.state == StateEnum.DANG_XU_LI && x.is_delete == false).ToList();
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
                id = order.id.ToString(),
                account_create = AccountDAO.GetAccountWithId(order.create_by),
                account_buy = AccountDAO.GetAccountWithId(order.buy_user),
                state = order.state,
                status = order.status,
                name = order.name,
                price = order.price,
                fee_type = order.fee_type,
                fee_amount = order.fee_rate * order.price,
                pay_amount = order.payment_amount,
                earn_amount = order.earn_amount,
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

        public static void CheckOrderKiemTraHang()
        {
            try
            {
                List<IntermediateOrder> orders = new List<IntermediateOrder>();
                using (var context = new Web_Trung_GianContext())
                {
                    orders = context.IntermediateOrders.Where(x =>
                    x.status == IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG ||
                    x.status == IntermediateOrderEnum.CHO_BEN_MUA_XAC_NHAN
                    ).ToList();

                }
                foreach (IntermediateOrder o in orders)
                {
                    TimeSpan khoangCach = DateTime.Now - o.buy_at.Value;
                    int days = (int)khoangCach.TotalDays;
                    if (days >= 3)
                    {
                        WalletDAO.UpdateWalletDepositBalance(o.create_by, (int)o.earn_amount);
                        o.state = StateEnum.THANH_CONG;
                        o.status = IntermediateOrderEnum.HOAN_THANH;
                        o.update_at = DateTime.Now;
                        o.update_by = AccountDAO.GetAccountWithRole(1).id;
                        UpdateIntermediateOrderState(o);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void CheckOrderKhieuNai()
        {
            try
            {
                List<IntermediateOrder> orders = new List<IntermediateOrder>();
                using (var context = new Web_Trung_GianContext())
                {
                    orders = context.IntermediateOrders.Where(x => x.status == IntermediateOrderEnum.BEN_MUA_KHIEU_NAI).ToList();

                }
                foreach (IntermediateOrder o in orders)
                {
                    TimeSpan khoangCach = DateTime.Now - o.update_at;
                    int days = (int)khoangCach.TotalDays;
                    if (days >= 1 && o.buy_at < o.update_at)
                    {
                        WalletDAO.UpdateWalletDepositBalance(o.buy_user.Value, (int)o.payment_amount);
                        o.state = StateEnum.THAT_BAI;
                        o.status = IntermediateOrderEnum.HUY;
                        o.update_at = DateTime.Now;
                        o.update_by = AccountDAO.GetAccountWithRole(1).id;
                        UpdateIntermediateOrderState(o);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CheckOrderDanhDauKhieuNai()
        {
            try
            {
                List<IntermediateOrder> orders = new List<IntermediateOrder>();
                using (var context = new Web_Trung_GianContext())
                {
                    orders = context.IntermediateOrders.Where(x =>
                    x.status == IntermediateOrderEnum.BEN_BAN_DANH_DAU_KHIEU_NAI ||
                    x.status == IntermediateOrderEnum.YEU_CAU_QUAN_TRI
                    ).ToList();

                }
                foreach (IntermediateOrder o in orders)
                {
                    TimeSpan khoangCach = DateTime.Now - o.update_at;
                    int days = (int)khoangCach.TotalDays;
                    if (days >= 1 && o.buy_at < o.update_at)
                    {
                        WalletDAO.UpdateWalletDepositBalance(o.buy_user.Value, (int)o.payment_amount);
                        o.state = StateEnum.THAT_BAI;
                        o.status = IntermediateOrderEnum.HUY;
                        o.update_at = DateTime.Now;
                        o.update_by = AccountDAO.GetAccountWithRole(1).id;
                        UpdateIntermediateOrderState(o);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateIntermediateOrderState(IntermediateOrder intermediateOrder)
        {
            try
            {
                intermediateOrder.update_at = DateTime.Now;
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

        public static List<IntermediateOrder> GetIntermediateOrderBuyed(int user_id)
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.
                    Where(x => x.is_delete == false
                    && x.buy_user == user_id
                    ).OrderByDescending(x => x.update_at).ToList();
            }
            return list;
        }

        public static List<IntermediateOrder> GetIntermediateOrderCreated(int user_id)
        {
            List<IntermediateOrder> list = new List<IntermediateOrder>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.IntermediateOrders.
                    Where(x => x.is_delete == false
                    && x.create_by == user_id
                    ).OrderByDescending(x => x.update_at).ToList();
            }
            return list;
        }

        public static void ConfirmInterOrderComplete(string id)
        {
            try
            {
                IntermediateOrder order = GetIntermediateOrderById(id);
                if (order != null)
                {
                    if (order.status == IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG)
                    {
                        order.status = IntermediateOrderEnum.HOAN_THANH;
                        using (var context = new Web_Trung_GianContext())
                        {
                            var intermediateOrders = context.Set<IntermediateOrder>();
                            intermediateOrders.Update(order);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ReportInterOrder(string id)
        {
            try
            {
                IntermediateOrder order = GetIntermediateOrderById(id);
                if (order != null)
                {
                    if (order.status == IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG)
                    {
                        order.status = IntermediateOrderEnum.BEN_MUA_KHIEU_NAI;
                        order.update_at = DateTime.Now;
                        using (var context = new Web_Trung_GianContext())
                        {
                            var intermediateOrders = context.Set<IntermediateOrder>();
                            intermediateOrders.Update(order);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ReportAdminInterOrder(string id)
        {
            try
            {
                IntermediateOrder order = GetIntermediateOrderById(id);
                if (order != null)
                {
                    if (order.status == IntermediateOrderEnum.BEN_MUA_KHIEU_NAI)
                    {
                        order.status = IntermediateOrderEnum.YEU_CAU_QUAN_TRI;
                        order.update_at = DateTime.Now;
                        using (var context = new Web_Trung_GianContext())
                        {
                            var intermediateOrders = context.Set<IntermediateOrder>();
                            intermediateOrders.Update(order);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteInterOrder(string id)
        {
            try
            {
                IntermediateOrder order = GetIntermediateOrderById(id);
                if (order != null)
                {
                    if (order.status != IntermediateOrderEnum.HOAN_THANH && order.state != StateEnum.THANH_CONG)
                    {
                        order.status = IntermediateOrderEnum.HUY;
                        order.state = IntermediateOrderEnum.HUY;
                        order.update_at = DateTime.Now;
                        using (var context = new Web_Trung_GianContext())
                        {
                            var intermediateOrders = context.Set<IntermediateOrder>();
                            intermediateOrders.Update(order);
                            context.SaveChanges();
                        }
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
