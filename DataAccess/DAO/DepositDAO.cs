using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class DepositDAO
    {
        public static List<Deposit> GetAllDeposit()
        {
            List<Deposit> list = new List<Deposit>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Deposits.ToList();

            }
            return list;
        }

        public static Deposit GetDepositById(int id)
        {
            return GetAllDeposit().FirstOrDefault(x => x.id == id);
        }
    }
}
