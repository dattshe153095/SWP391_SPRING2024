using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class DepositDAO
    {
        private static Queue<Deposit> depositQueue = new Queue<Deposit>();
        private static object queueLock = new object();
        private static bool isProcessing = false;

        public static List<Deposit> GetAllDeposit()
        {
            List<Deposit> list = new List<Deposit>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Deposits.ToList();
            }
            return list;
        }

        public static Deposit GetDepositById(int id)
        {
            return GetAllDeposit().FirstOrDefault(x => x.id == id);
        }

        public static Deposit GetDepositTransactionCode(int wallet_id, string code)
        {
            return GetAllDeposit().FirstOrDefault(x => x.wallet_id == wallet_id && x.trans_code == code);
        }

        public static void UpdateDeposit(Deposit deposit)
        {
            Deposit d = GetDepositById(deposit.id);
            if (d != null)
            {
                d.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var deposits = context.Set<Deposit>();
                    deposits.Update(deposit);
                    context.SaveChanges();
                }
            }
        }

        public static void CreateDeposit(Deposit deposit)
        {
            deposit.status = "đang chờ xử lí";
            deposit.create_at = DateTime.Now;
            deposit.update_at = DateTime.Now;

            lock (queueLock)
            {
                depositQueue.Enqueue(deposit); // Thêm deposit vào hàng đợi
                if (!isProcessing)
                {
                    isProcessing = true;
                    ProcessDeposits(); // Bắt đầu xử lý hàng đợi nếu chưa có công việc nào đang được xử lý
                }
            }
        }

        private static void ProcessDeposits()
        {
            while (true)
            {
                Deposit deposit;
                lock (queueLock)
                {
                    if (depositQueue.Count == 0)
                    {
                        isProcessing = false;
                        return; // Kết thúc nếu không còn deposit nào trong hàng đợi
                    }
                    deposit = depositQueue.Dequeue(); // Lấy deposit đầu tiên từ hàng đợi
                }

                try
                {
                    if(deposit.status == "đang chờ xử lí")
                    {
                        deposit.status = "đang chờ xác nhận";
                        using (var context = new Web_Trung_GianContext())
                        {
                            var deposits = context.Set<Deposit>();
                            deposits.Add(deposit);
                            context.SaveChanges();
                        }
                    }
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating deposit: " + ex.Message);
                    // Xử lý lỗi tạo deposit ở đây nếu cần thiết
                }
            }
        }
    }
}
