using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DataAccess.Library;

namespace DataAccess.DAO
{
    public class DepositResponseDAO
    {
        private static Queue<DepositResponse> depositResponseQueue = new Queue<DepositResponse>();
        private static object queueLock = new object();
        private static bool isProcessing = false;

        public static void CreateDepositResponse(DepositResponse depositResponse)
        {
            depositResponse.state = StatusEnum.DANG_XU_LI;
            depositResponse.create_at = DateTime.Now;
            depositResponse.update_at = DateTime.Now;

            lock (queueLock)
            {
                depositResponseQueue.Enqueue(depositResponse); // Thêm depositResponse vào hàng đợi
                if (!isProcessing)
                {
                    isProcessing = true;
                    ProcessDepositResponses(); // Bắt đầu xử lý hàng đợi nếu chưa có công việc nào đang được xử lý
                }
            }
        }

        private static void ProcessDepositResponses()
        {
            while (true)
            {
                DepositResponse depositResponse;
                lock (queueLock)
                {
                    if (depositResponseQueue.Count == 0)
                    {
                        isProcessing = false;
                        return; // Kết thúc nếu không còn deposit nào trong hàng đợi
                    }
                    depositResponse = depositResponseQueue.Dequeue(); // Lấy depositResponse đầu tiên từ hàng đợi
                }

                try
                {
                    if (depositResponse.state != StateEnum.THANH_CONG)
                    {
                        depositResponse.state = StateEnum.THANH_CONG;
                        using (var context = new Web_Trung_GianContext())
                        {
                            var depositResponses = context.Set<DepositResponse>();
                            depositResponses.Add(depositResponse);
                            context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating depositResponses: " + ex.Message);
                    // Xử lý lỗi tạo deposit ở đây nếu cần thiết
                }
            }
        }

        public static DepositResponse GetDepositResponseByDepositId(string deposit_id)
        {
            return GetAllDepositResponse().FirstOrDefault(x => x.deposit_id == deposit_id);
        }

        public static List<DepositResponse> GetAllDepositResponse()
        {
            List<DepositResponse> list = new List<DepositResponse>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.DepositResponses.ToList();
            }
            return list;
        }

        public static DepositResponse GetDepositResponseById(int id)
        {
            return GetAllDepositResponse().FirstOrDefault(x => x.id == id);
        }
    }
}
