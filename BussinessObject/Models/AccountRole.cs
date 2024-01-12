using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class AccountRole
    {
        public AccountRole()
        {
            Accounts = new HashSet<Account>();
            Admins = new HashSet<Admin>();
        }

        public int Id { get; set; }
        public string? Role { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}
