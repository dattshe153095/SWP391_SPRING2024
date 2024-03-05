using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebClient2.ViewModel
{
    public class MarketView
    {
        public string id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public float fee_rate { get; set; } = 0.05f;
        public bool fee_type { get; set; }
        public float payment_amount { get { return fee_type ? price : price + (int)(price * fee_rate); } set { } }
        public float earn_amount { get { return fee_type ? price - (int)(price * fee_rate) : price; } set { } }
        public string description { get; set; }
        public string contact { get; set; }
        public string hidden_content { get; set; }
        public bool is_public { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public int create_by { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;
        public int? buy_user { get; set; }
        public DateTime? buy_at { get; set; } = DateTime.Now;
        public int update_by { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;
        public string? link_product { get; set; } = "#";
        public bool is_delete { get; set; } = false;
    }
}
