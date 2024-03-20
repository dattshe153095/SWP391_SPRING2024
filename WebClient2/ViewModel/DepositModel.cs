using System.ComponentModel.DataAnnotations;

namespace WebClient2.ViewModel
{
    public class DepositModel
    {
        [Range(10000, 200000, ErrorMessage = "Số tiền chỉ trong khoảng từ 10,000 đến 200,000")]
        public int amount { get; set; }
        public string? description { get; set; }
    }
}
