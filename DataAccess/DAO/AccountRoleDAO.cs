using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountRoleDAO
    {
        public static List<AccountRole> GetAllAccountRole()
        {
            List<AccountRole> list = new List<AccountRole>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.AccountRoles.ToList();
            }
            return list;
        }

        public static AccountRole GetAccountRoleById(int id)
        {
            return GetAllAccountRole().FirstOrDefault(x=>x.id==id);
        }

    }
}
