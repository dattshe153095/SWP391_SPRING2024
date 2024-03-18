using System.ComponentModel.DataAnnotations;

namespace WebClient2.ViewModel
{
    public class DepositModel
    {
        [Range(20000, 500000, ErrorMessage = "Số tiền chỉ trong khoảng từ 20,000 đến 500,000")]
        public int amount { get; set; }
        public string? description { get; set; }
    }
}
