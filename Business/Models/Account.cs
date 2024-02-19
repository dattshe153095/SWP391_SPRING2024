using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BussinessObject.Models
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string password { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string? description { get; set; }
        [ForeignKey(nameof(Role))]
        public int role_id { get; set; }
        public virtual AccountRole? Role { get; set; }
        //==TRACK==
        public DateTime create_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
        public bool is_delete { get; set; } = false;

        //======== Many ======

        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Order>? OrderCreates { get; set; }
        public virtual ICollection<Order>? OrderUpdate { get; set; }
        public virtual ICollection<Product>? ProductCreates { get; set; }
        public virtual ICollection<Product>? ProductUpdates { get; set; }
        public virtual ICollection<Wallet>? Wallets { get; set; }
        public virtual ICollection<Wallet>? WalletUpdates { get; set; }
        public virtual ICollection<Deposit>? DepositCreates { get; set; }
        public virtual ICollection<Deposit>? DepositUpdates { get; set; }
        public virtual ICollection<Withdrawal>? WithdrawalCreates { get; set; }
        public virtual ICollection<Withdrawal>? WithdrawalUpdates { get; set; }
    }

}
