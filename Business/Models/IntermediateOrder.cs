using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class IntermediateOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string name { get; set; }
        public int price { get; set; }
        public bool fee_type { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string description { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string contact { get; set;}

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string hidden_content { get; set; }
        public bool is_public { get; set; }
        public int fee { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string status { get; set; }


        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string state { get; set; }

        //==TRACK==
        #region TRACKING
        [ForeignKey(nameof(AccountCreate))]
        public int create_by { get; set; }
        public virtual Account? AccountCreate { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;

        [ForeignKey(nameof(AccountBuy))]
        public int? buy_by { get; set; }
        public virtual Account? AccountBuy { get; set; }

        [ForeignKey(nameof(AccountUpdate))]
        public int update_by { get; set; }
        public virtual Account? AccountUpdate { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;

        public bool is_delete { get; set; } = false;
        #endregion
    }
}
