using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Library;

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

        public static Deposit GetDepositById(string id)
        {
            return GetAllDeposit().FirstOrDefault(x => x.id == id);
        }

        public static Deposit GetDepositTransactionCode(int wallet_id, string id)
        {
            return GetAllDeposit().FirstOrDefault(x => x.wallet_id == wallet_id && x.id == id);
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
            deposit.status = StatusEnum.DANG_XU_LI;
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
                    if (deposit.status == StatusEnum.DANG_XU_LI)
                    {
                        deposit.status = StatusEnum.DANG_CHO_XAC_NHAN;
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

        public static void DepositAction()
        {
            List<Deposit> deposits = GetAllDeposit().Where(x => x.status == StatusEnum.XAC_NHAN_THANH_CONG).ToList();
            foreach (var deposit in deposits)
            {
                if (deposit.status != StatusEnum.HOAN_THANH)
                {
                    deposit.status = StatusEnum.HOAN_THANH;
                    WalletDAO.UpdateWalletDepositBalance(deposit.wallet_id, deposit.amount);
                }
            }
            using (var context = new Web_Trung_GianContext())
            {
                var de = context.Set<Deposit>();
                de.UpdateRange(deposits);
                context.SaveChanges();
            }
        }
    }
}
