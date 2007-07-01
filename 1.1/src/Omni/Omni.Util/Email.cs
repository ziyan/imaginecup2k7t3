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
            MailAddress from = new MailAddress(Util.Configuration.LocalSettings["Omni.Util.Email.FromAddress"], Util.Configuration.LocalSettings["Omni.Util.Email.FromName"]);
            MailAddress dest = new MailAddress(to);
            MailMessage message = new MailMessage(from, dest);
            message.Subject = subject;
            message.Body = body;
            SmtpClient client = new SmtpClient(Util.Configuration.LocalSettings["Omni.Util.Email.ServerHost"], Convert.ToInt32(Util.Configuration.LocalSettings["Omni.Util.Email.ServerPort"]));
            client.Send(message);
        }
        public static bool IsValidEmail(string email)
        {
            return email != null && email != "" && System.Text.RegularExpressions.Regex.Replace(email, Util.Configuration.LocalSettings["Omni.Util.Email.Pattern"], "") == "";
        }
    }
}
