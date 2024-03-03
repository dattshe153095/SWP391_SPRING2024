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
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        [Key]
        public string id { get; set; }
        public int wallet_id { get; set; }
        public int amount { get; set; }

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
