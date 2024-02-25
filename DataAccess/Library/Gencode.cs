﻿using System;
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
            int id = 14; // ID của bạn

            string generatedCode = GenerateCodeDeposit(id);
            Console.WriteLine("Generated Code: " + generatedCode);
        }

        public static string GenerateCodeDeposit(int id)
        {
            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder();

            codeBuilder.Append(id.ToString("000")+"D"); // Thêm ID vào mã

            // Thêm 9 kí tự ngẫu nhiên
            for (int i = 0; i < 9; i++)
            {
                int randomNumber = random.Next(0, 36); // 26 chữ cái và 10 chữ số
                char character;
                if (randomNumber < 10)
                    character = (char)('0' + randomNumber); // Chữ số
                else
                    character = (char)('a' + randomNumber - 10); // Chữ cái

                codeBuilder.Append(character);
            }

            return codeBuilder.ToString().ToUpper();
        }

        public static string GenerateCodeWithdrawal(int id)
        {
            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder();

            codeBuilder.Append(id.ToString("000") + "W"); // Thêm ID vào mã

            // Thêm 9 kí tự ngẫu nhiên
            for (int i = 0; i < 9; i++)
            {
                int randomNumber = random.Next(0, 36); // 26 chữ cái và 10 chữ số
                char character;
                if (randomNumber < 10)
                    character = (char)('0' + randomNumber); // Chữ số
                else
                    character = (char)('a' + randomNumber - 10); // Chữ cái

                codeBuilder.Append(character);
            }

            return codeBuilder.ToString().ToUpper();
        }
    }
}


