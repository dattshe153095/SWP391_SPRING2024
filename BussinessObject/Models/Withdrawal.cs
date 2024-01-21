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
    public class Withdrawal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int wallet_id { get; set; }
        public virtual Wallet? Wallet { get; set; }
        public int amount { get; set; }
        public int fee { get; set; }
        [Required]
        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string bank_user { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string bank_number { get; set; }
        [Required]
        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string bank_name { get; set; }
        public bool status { get; set; }

        //==TRACK==
        #region TRACKING
        [ForeignKey(nameof(AccountCreate))]
        public int create_by { get; set; }
        public virtual Account? AccountCreate { get; set; }
        public DateTime create_at { get; set; }

        [ForeignKey(nameof(AccountUpdate))]
        public int update_by { get; set; }
        public virtual Account? AccountUpdate { get; set; }
        public DateTime update_at { get; set; }
        public bool is_delete { get; set; }
        #endregion
    }
}
