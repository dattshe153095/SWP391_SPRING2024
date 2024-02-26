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
                    _logger.LogInformation("Đây là công việc được thực hiện mỗi 3 phút.");
                    Console.WriteLine("Cap Nhat Data base");
                    //DataBase
                    DepositDAO.DepositAction();


                    // Đợi 3 phút trước khi thực hiện lại công việc
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
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
