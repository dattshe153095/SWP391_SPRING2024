using Business.Models;
using DataAccess.Library;

namespace DataAccess.ViewModel
{
    public class OrderViewModel
    {
        public string code { get; set; }
        public Account? account_create { get; set; }
        public Account? account_buy { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public bool fee_type { get; set; }
        public float fee_amount
        {
            get
            {
                return price * Constant.FEE;
            }
        }
        public float earn_amount
        {
            get
            {
                return fee_type ? price - fee_amount : price;
            }
        }
        public string description { get; set; }
        public string contact { get; set; }
        public string hidden_content { get; set; }
        public bool is_public { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public string link_share { get; set; }

    }
}
