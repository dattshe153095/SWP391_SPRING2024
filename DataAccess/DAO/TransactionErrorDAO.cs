using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class TransactionErrorDAO
    {
        public static List<TransactionError> GetAllTransactionError()
        {
            List<TransactionError> list = new List<TransactionError>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.TransactionErrors.ToList();

            }
            return list;
        }

        public static TransactionError GetTransactionErrorById(int id)
        {
            return GetAllTransactionError().FirstOrDefault(x => x.id == id);
        }

    }
}
