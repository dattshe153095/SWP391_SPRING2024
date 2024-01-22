using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string code { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int categories { get; set; }
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string? desctiption { get; set; }
        [Required]
        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string link { get; set; }
        public string? image { get; set; }
        public int create_by { get; set; }
        public DateTime create_at { get; set; }
        public int update_by { get; set; }
        public DateTime update_at { get; set; }
        public int delete_by { get; set; }
        public DateTime delete_at { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }



    }
}
