using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class ProcessedTransactionInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey(nameof(TransactionError))]
        public int transaction_error_id { get; set; }
        public virtual TransactionError? TransactionError { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string processed_message { get; set; } = "";
        public DateTime create_at { get; set; } = DateTime.Now;
        public int create_by { get; set; }

    }
}
