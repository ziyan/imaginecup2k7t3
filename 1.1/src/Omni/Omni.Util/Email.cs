using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Omni.Util
{
    public static class Email
    {
        public static void Send(string to, string subject, string body)
        {
            //TODO: read from configuration
            MailAddress from = new MailAddress("no-reply@omniproject.org");
            MailAddress dest = new MailAddress(to);
            MailMessage message = new MailMessage(from, dest);
            message.Subject = subject;
            message.Body = body;
            //TODO: read from configuration
            SmtpClient client = new SmtpClient("smtp.winisp.net");
            client.Send(message);
        }

        public static string EmailPattern = @"([a-zA-Z0-9_\-\.])+@(([0-2]?[0-5]?[0-5]\.[0-2]?[0-5]?[0-5]\.[0-2]?[0-5]?[0-5]\.[0-2]?[0-5]?[0-5])|((([a-zA-Z0-9\-])+\.)+([a-zA-Z\-])+))";
        public static bool IsValidEmail(string email)
        {
            return email != null && email != "" && System.Text.RegularExpressions.Regex.Replace(email, EmailPattern, "") == "";
        }
    }
}
