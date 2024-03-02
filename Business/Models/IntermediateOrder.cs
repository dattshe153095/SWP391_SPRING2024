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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int product_id { get; set; }
        public bool is_pay { get; set; }
        public int sell_user { get; set; }
        public int? buy_user { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string status { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string state { get; set; }
        public int payment_amount { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string? link_product { get; set; } = "#";
        public bool is_delete { get; set; } = false;
    }
}
