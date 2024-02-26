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


        private static Queue<IntermediateOrder> intermediateOrderQueue = new Queue<IntermediateOrder>();
        private static object queueLock = new object();
        private static bool isProcessing = false;

        public static void BuyIntermediateOrder(int id_user, IntermediateOrder intermediateOrder)
        {
            intermediateOrder.buy_by = id_user;
            intermediateOrder.update_at = DateTime.Now;
            intermediateOrder.update_by = id_user;

            lock (queueLock)
            {
                intermediateOrderQueue.Enqueue(intermediateOrder); // Thêm deposit vào hàng đợi
                if (!isProcessing)
                {
                    isProcessing = true;
                    ProcessIntermediateOrders(); // Bắt đầu xử lý hàng đợi nếu chưa có công việc nào đang được xử lý
                }
            }
        }

        private static void ProcessIntermediateOrders()
        {
            while (true)
            {
                IntermediateOrder intermediateOrder;
                lock (queueLock)
                {
                    if (intermediateOrderQueue.Count == 0)
                    {
                        isProcessing = false;
                        return; // Kết thúc nếu không còn deposit nào trong hàng đợi
                    }
                    intermediateOrder = intermediateOrderQueue.Dequeue(); // Lấy deposit đầu tiên từ hàng đợi
                }

                try
                {
                    if (intermediateOrder.status == IntermediateOrderEnum.SAN_SANG_GIAO_DICH)
                    {

                        //Update Wallet
                        int wallet_id = WalletDAO.GetWalletByAccountId(intermediateOrder.buy_by.Value).id;
                        int total = intermediateOrder.price;
                        //Check inter if it fee type
                        total += intermediateOrder.fee_type ? intermediateOrder.fee : 0;

                        if (WalletDAO.GetWalletById(wallet_id).balance < total)
                        {
                            return;
                        }
                        WalletDAO.UpdateWalletBuyOrder(wallet_id, total);

                        //Update Order
                        using (var context = new Web_Trung_GianContext())
                        {
                            var intermediateOrders = context.Set<IntermediateOrder>();
                            intermediateOrders.Update(intermediateOrder);
                            context.SaveChanges();
                        }

                        intermediateOrder.status = IntermediateOrderEnum.BEN_MUA_KIEM_TRA_HANG;


                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating intermediateOrder: " + ex.Message);
                    // Xử lý lỗi tạo deposit ở đây nếu cần thiết
                }
            }
        }
    }
}
