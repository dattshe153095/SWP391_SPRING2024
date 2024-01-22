using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BussinessObject.Models
{
    public partial class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string name { get; set; } = "";
        [Required]
        public string username { get; set; } = "";
        [Required]
        public string email { get; set; } = "";
        [Required]
        public string phone { get; set; } = "";
        [Required]
        public string password { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(200)]
        public string? description { get; set; }
        [ForeignKey(nameof(Role))]
        public int role_id { get; set; }
        public virtual Role? Role { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int wallet_id { get; set; }
        public virtual Wallet? Wallet { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool? IsDelete { get; set; }
    }
}
