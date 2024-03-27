using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class Withdrawal
    {
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        [Key]
        public string id { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int wallet_id { get; set; }
        public virtual Wallet? Wallet { get; set; }
        [Range(20000, 500000, ErrorMessage = "Số tiền chỉ trong khoảng từ 20,000 đến 500,000")]
        public int amount { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string bank_number { get; set; }

        [Required]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string bank_user { get; set; }

        [Required]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string bank_name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string status { get; set; }


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

