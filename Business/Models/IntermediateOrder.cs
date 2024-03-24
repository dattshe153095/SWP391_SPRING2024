using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class IntermediateOrder
    {
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        [Key]
        public string id { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public float price { get; set; }
        public float fee_rate { get; set; } = 0.05f;
        public bool fee_type { get; set; }
        public float payment_amount { get { return fee_type ? price : price + (int)(price * fee_rate); } set { } }
        public float earn_amount { get { return fee_type ? price - (int)(price * fee_rate) : price; } set { } }
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string description { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string contact { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string hidden_content { get; set; }
        public bool is_public { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string status { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string state { get; set; }
        public int create_by { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;
        public int? buy_user { get; set; }
        public DateTime? buy_at { get; set; }
        public int update_by { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string? link_product { get; set; } = "#";
        public bool is_delete { get; set; } = false;
    }
}
