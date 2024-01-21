using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; } = string.Empty;
    }
}
