using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey(nameof(Product))]
        public int product_id { get; set; }
        public virtual Product? Product { get; set; }
        public int quantity { get; set; }
        public int total_price { get; set; }
        public int account_id { get; set; }
        public int create_by { get; set; }
        public DateTime create_at { get; set; }
        public int update_by { get; set; }
        public DateTime update_at { get; set; }


    }
}
