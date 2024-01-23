using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MailSender
{
    public class EmailSender
    {
        public static string SendEmailAsync(string email, string subject, string message)
        {
            using var smtp = new SmtpClient();

            MailAddress from = new MailAddress("fireflower208@gmail.com");
            MailAddress to = new MailAddress(email);
            MailMessage email1 = new MailMessage(from, to);

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("fireflower208@gmail.com", "usxrdbtzafucskdh"); // App password
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            string code = GenCode();
            smtp.Send("fireflower208@gmail.com", email, "[Thông báo] - Kích hoạt tài khoản Trade&DealHub", "Bạn hoặc ai đó đã sử dụng email để tạo tài khoản, đây là mã xác nhận: " + code);
            return code;
        }

        public static string GenCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString.ToString();
        }
    }
}
