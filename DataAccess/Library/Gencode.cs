using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Library
{
    public class Gencode
    {
        public static void Main(string[] args)
        {
        }

        public static string GenerateCodeDeposit()
        {
            return "DE" + GenerateUniqueId();
        }

        public static string GenerateCodeWithdrawal()
        {
            return "WA" + GenerateUniqueId();
        }

        public static string GenerateUniqueId()
        {
            // You can customize this function according to your requirements
            // For simplicity, this example generates a random 8-character string
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] charArray = new char[8];
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                charArray[i] = chars[random.Next(chars.Length)];
            }

            string uniqueId = new string(charArray);
            return uniqueId;
        }
    }
}



