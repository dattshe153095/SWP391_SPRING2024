using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class AccountRole
    {
        public AccountRole()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Role { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
