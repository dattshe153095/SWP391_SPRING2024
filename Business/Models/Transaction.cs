using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Transaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string description { get; set; }
        public int wallet_id { get; set; }
        public bool type { get; set; }
        public int amount { get; set; }
    }
}
