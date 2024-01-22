using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class Wallet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public decimal balance { get; set; }
        [ForeignKey(nameof(Account))]
        public int account_id { get; set; }
        public virtual Account? Account { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

        public virtual ICollection<Deposit>? Deposits { get; set; }
        public virtual ICollection<Withdrawal>? Withdrawals { get; set; }
    }
}
