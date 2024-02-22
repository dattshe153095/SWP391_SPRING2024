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

        public static void UpdateDeposit(Deposit deposit)
        {
            Deposit d = GetDepositById(deposit.id);
            if (d != null)
            {
                d.update_at = DateTime.Now;
                using (var context = new Web_Trung_GianContext())
                {
                    var deposits = context.Set<Deposit>();
                    deposits.Update(deposit);
                    context.SaveChanges();
                }
            }
        }

        public static void CreateDeposit(Deposit deposit)
        {
            deposit.create_at = DateTime.Now;
            deposit.update_at = DateTime.Now;
            deposit.status = "pending";
            if (deposit != null)
            {
              
                using (var context = new Web_Trung_GianContext())
                {
                    var deposits = context.Set<Deposit>();
                    deposits.Add(deposit);
                    context.SaveChanges();
                }
            }
        }
    }
}
