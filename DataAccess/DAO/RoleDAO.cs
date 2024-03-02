using Business.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        public static List<Role> GetAllAccountRole()
        {
            List<Role> list = new List<Role>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Roles.ToList();
            }
            return list;
        }

        public static Role GetAccountRoleById(int id)
        {
            return GetAllAccountRole().FirstOrDefault(x=>x.id==id);
        }

    }
}
