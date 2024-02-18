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
        public int balance { get; set; }
        [ForeignKey(nameof(Account))]
        public int account_id { get; set; }
        public virtual Account? Account { get; set; }

        //===TRACKING===
        #region TRACKING
        [ForeignKey(nameof(AccountUpdate))]
        public int update_by { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;
        public virtual Account? AccountUpdate { get; set; }
        #endregion

        public virtual ICollection<Deposit>? Deposits { get; set; }
        public virtual ICollection<Withdrawal>? Withdrawals { get; set; }
        public virtual ICollection<TransactionError>? TransactionErrors { get; set; }
    }
}

