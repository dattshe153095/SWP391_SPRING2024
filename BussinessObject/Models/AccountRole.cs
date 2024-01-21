using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
    public partial class AccountRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string? desctiption { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }

    }
}
