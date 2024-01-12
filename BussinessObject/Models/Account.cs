using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDelete { get; set; }
        public int? IdRole { get; set; }

        public virtual AccountRole? IdRoleNavigation { get; set; }
    }
}
