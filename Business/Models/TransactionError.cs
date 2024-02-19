using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class TransactionError
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int wallet_id { get; set; }
        public virtual Wallet? Wallet { get; set; }
        public string type { get; set; } = "Deposit";
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string description { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string status { get; set; } = "Pending";
        public DateTime create_at { get; set; } = DateTime.Now;
        public int create_by { get; set; }
        public virtual ICollection<ProcessedTransactionInfo>? ProcessedTransactionInfos { get; set; }


    }
}

