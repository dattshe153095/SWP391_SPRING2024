using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Models
{
    public class Deposit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int wallet_id { get; set; }
        public virtual Wallet? Wallet { get; set; }
        public int amount { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string trans_code{ get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string status { get; set; }


        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string state { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string? description { get; set; }

        public virtual ICollection<DepositResponse>? DepositResponses { get; set; }

        //==TRACK==
        #region TRACKING
        [ForeignKey(nameof(AccountCreate))]
        public int create_by { get; set; }
        public virtual Account? AccountCreate { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;

        [ForeignKey(nameof(AccountUpdate))]
        public int update_by { get; set; }
        public virtual Account? AccountUpdate { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;

        public bool is_delete { get; set; } = false;
        #endregion
    }

}
