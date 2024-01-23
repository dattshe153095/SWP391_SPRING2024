using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MailSender
{
    public interface IEmailSender
    {
        string SendEmailAsync(string email, string subject, string message);
    }
}
