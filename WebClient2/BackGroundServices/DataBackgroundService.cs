using Business.Models;
using DataAccess.DAO;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebClient2.BackGroundServices
{
    public class DataBackgroundService : BackgroundService
    {
        private readonly ILogger<DataBackgroundService> _logger;
        public DataBackgroundService(ILogger<DataBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Thực hiện công việc của bạn ở đây
                    _logger.LogInformation("Cap nhat Database after 10s");
                    Console.WriteLine("Cap Nhat Data base");
                    //CHECK DEPOSIT
                    DepositDAO.DepositAction();
                    //CHECK IntermediateOrderDAO
                    IntermediateOrderDAO.HandleIntermediateOrderCreate();

                    //CHECK STATE INTERMEDIATE ORDER
                    IntermediateOrderDAO.CheckOrderKiemTraHang();
                    IntermediateOrderDAO.CheckOrderKhieuNai();
                    IntermediateOrderDAO.CheckOrderDanhDauKhieuNai();

                    // Đợi 3 phút trước khi thực hiện lại công việc
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Bắt các yêu cầu hủy
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi trong quá trình thực hiện công việc.");
                }
            }
        }
    }
}
