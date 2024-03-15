using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
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
        public int update_by { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;
        #endregion

    }
}

