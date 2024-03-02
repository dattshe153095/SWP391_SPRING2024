using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class IntermediateProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string name { get; set; }
        public int price { get; set; }
        public int fee_create { get; set; } = 100;
        public bool fee_type { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string description { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string contact { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string hidden_content { get; set; }
        public bool is_public { get; set; }
        public int fee { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string state { get; set; }

        //==TRACK==
        #region TRACKING
        public int create_by { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;


        public int update_by { get; set; }
        public DateTime update_at { get; set; } = DateTime.Now;

        public bool is_delete { get; set; } = false;
        #endregion
    }
}
