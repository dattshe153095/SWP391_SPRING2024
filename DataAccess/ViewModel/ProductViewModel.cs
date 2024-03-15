using Business.Models;
using DataAccess.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ProductViewModel
    {
        public string id { get; set; }
        public Account? account_create { get; set; }
        public string state { get; set; }
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
        public float pay_amount
        {
            get
            {
                return fee_type ? price : price + fee_amount;
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
