using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Library;

namespace DataAccess.DAO
{
    public class WithdrawalDAO
    {
        private static Queue<Withdrawal> withdrawalQueue = new Queue<Withdrawal>();
        private static object queueLock = new object();
        private static bool isProcessing = false;

        public static void CreateWithdrawal(Withdrawal withdrawal)
        {
            withdrawal.status = StatusEnum.DANG_XU_LI;
            withdrawal.create_at = DateTime.Now;
            withdrawal.update_at = DateTime.Now;

            lock (queueLock)
            {
                withdrawalQueue.Enqueue(withdrawal); // Thêm deposit vào hàng đợi
                if (!isProcessing)
                {
                    isProcessing = true;
                    ProcessWithdrawals(); // Bắt đầu xử lý hàng đợi nếu chưa có công việc nào đang được xử lý
                }
            }
        }

        private static void ProcessWithdrawals()
        {
            while (true)
            {
                Withdrawal withdrawal;
                lock (queueLock)
                {
                    if (withdrawalQueue.Count == 0)
                    {
                        isProcessing = false;
                        return; // Kết thúc nếu không còn deposit nào trong hàng đợi
                    }
                    withdrawal = withdrawalQueue.Dequeue(); // Lấy deposit đầu tiên từ hàng đợi
                }

                try
                {
                    if (withdrawal.status == StatusEnum.DANG_XU_LI)
                    {
                        withdrawal.status = StatusEnum.DANG_CHO_XAC_NHAN;
                        WalletDAO.UpdateWalletWithdrawalBalance(withdrawal.wallet_id, withdrawal.amount);
                        using (var context = new Web_Trung_GianContext())
                        {
                            var withdrawals = context.Set<Withdrawal>();
                            withdrawals.Add(withdrawal);
                            context.SaveChanges();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating withdrawal: " + ex.Message);
                    // Xử lý lỗi tạo deposit ở đây nếu cần thiết
                }
            }
        }

        public static List<Withdrawal> GetAllWithdrawal()
        {
            List<Withdrawal> list = new List<Withdrawal>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Withdrawals.ToList();

            }
            return list;
        }

        public static Withdrawal GetWithdrawalById(int id)
        {
            return GetAllWithdrawal().FirstOrDefault(x => x.id == id);
        }

        public static void UpdateWithdrawal(Withdrawal withdrawal)
        {
            Withdrawal d = GetWithdrawalById(withdrawal.id);
            if (d != null)
            {
                d.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var withdrawals = context.Set<Withdrawal>();
                    withdrawals.Update(withdrawal);
                    context.SaveChanges();
                }
            }
        }

        public static Withdrawal GetWithdrawalTransactionCode(int wallet_id, string code)
        {
            return GetAllWithdrawal().FirstOrDefault(x => x.wallet_id == wallet_id && x.trans_code == code);
        }

    }
}
