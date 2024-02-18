using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProcessedTransactionInfoDAO
    {
        public static List<ProcessedTransactionInfo> GetAllProcessedTransactionInfo()
        {
            List<ProcessedTransactionInfo> list = new List<ProcessedTransactionInfo>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.ProcessedTransactionInfos.ToList();

            }
            return list;
        }

        public static ProcessedTransactionInfo GetProcessedTransactionInfoById(int id)
        {
            return GetAllProcessedTransactionInfo().FirstOrDefault(x => x.id == id);
        }

        public static ProcessedTransactionInfo GetProcessedTransactionInfoByTransactionErrorId(int id)
        {
            return GetAllProcessedTransactionInfo().FirstOrDefault(x => x.transaction_error_id == id);
        }

        public static void UpdateProcessedTransactionInfo(ProcessedTransactionInfo processedTransactionInfo)
        {
            try
            {
                ProcessedTransactionInfo p = GetProcessedTransactionInfoById(processedTransactionInfo.id);
                if (p != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var processedTransactionInfos = context.Set<ProcessedTransactionInfo>();
                        processedTransactionInfos.Update(processedTransactionInfo);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The ProcessedTransactionInfo does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
