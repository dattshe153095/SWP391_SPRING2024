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
    public class WithdrawalResponseDAO
    {
        private static Queue<WithdrawalResponse> withdrawalResponseQueue = new Queue<WithdrawalResponse>();
        private static object queueLock = new object();
        private static bool isProcessing = false;

        public static void CreateDepositResponse(WithdrawalResponse withdrawalResponse)
        {
            withdrawalResponse.state = StatusEnum.DANG_XU_LI;
            withdrawalResponse.create_at = DateTime.Now;
            withdrawalResponse.update_at = DateTime.Now;

            lock (queueLock)
            {
                withdrawalResponseQueue.Enqueue(withdrawalResponse); // Thêm depositResponse vào hàng đợi
                if (!isProcessing)
                {
                    isProcessing = true;
                    ProcessWithdrawalResponses(); // Bắt đầu xử lý hàng đợi nếu chưa có công việc nào đang được xử lý
                }
            }
        }

        private static void ProcessWithdrawalResponses()
        {
            while (true)
            {
                WithdrawalResponse withdrawalResponse;
                lock (queueLock)
                {
                    if (withdrawalResponseQueue.Count == 0)
                    {
                        isProcessing = false;
                        return; // Kết thúc nếu không còn deposit nào trong hàng đợi
                    }
                    withdrawalResponse = withdrawalResponseQueue.Dequeue(); // Lấy depositResponse đầu tiên từ hàng đợi
                }

                try
                {
                    if (withdrawalResponse.state != StateEnum.THANH_CONG)
                    {
                        withdrawalResponse.state = StateEnum.THANH_CONG;
                        using (var context = new Web_Trung_GianContext())
                        {
                            var withdrawalResponses = context.Set<WithdrawalResponse>();
                            withdrawalResponses.Add(withdrawalResponse);
                            context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating withdrawalResponses: " + ex.Message);
                    // Xử lý lỗi tạo deposit ở đây nếu cần thiết
                }
            }
        }

        public static WithdrawalResponse GetWithdrawalResponseByDepositId(string withdrawal_id)
        {
            return GetAllWithdrawalResponse().FirstOrDefault(x => x.withdrawal_id == withdrawal_id);
        }

        public static List<WithdrawalResponse> GetAllWithdrawalResponse()
        {
            List<WithdrawalResponse> list = new List<WithdrawalResponse>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.WithdrawalResponses.ToList();
            }
            return list;
        }

        public static WithdrawalResponse GetWithdrawalResponseById(int id)
        {
            return GetAllWithdrawalResponse().FirstOrDefault(x => x.id == id);
        }
    }
}
