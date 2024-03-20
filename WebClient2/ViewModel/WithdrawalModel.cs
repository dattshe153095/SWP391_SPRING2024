using System.ComponentModel.DataAnnotations;

namespace WebClient2.ViewModel
{
    public class WithdrawalModel
    {
        [Range(20000, 500000, ErrorMessage = "Số tiền chỉ trong khoảng từ 20,000 đến 500,000")]
        public int amount { get; set; }
        [MaxLength(50, ErrorMessage = "Số kí tự dưới 50 kí hiệu")]
        public string bank_number { get; set; }
        [MaxLength(50, ErrorMessage = "Số kí tự dưới 50 kí hiệu")]
        public string bank_user { get; set; }
        [MaxLength(100, ErrorMessage = "Số kí tự dưới 50 kí hiệu")]
        public string bank_name { get; set; }
    }
}
