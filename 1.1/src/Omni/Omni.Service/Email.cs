using System;
using System.Net;
using System.Net.Mail;

namespace Omni.Service
{
    public static class Email
    {
        public static void Send(string to, string subject, string body)
        {
            MailAddress from = new MailAddress(Data.Configuration.LocalSettings["Omni.Service.Email.FromAddress"], Data.Configuration.LocalSettings["Omni.Service.Email.FromName"]);
            MailAddress dest = new MailAddress(to);
            MailMessage message = new MailMessage(from, dest);
            message.Subject = subject;
            message.Body = body;
            SmtpClient client = new SmtpClient(Data.Configuration.LocalSettings["Omni.Service.Email.ServerHost"], Convert.ToInt32(Data.Configuration.LocalSettings["Omni.Service.Email.ServerPort"]));
            client.Send(message);
        }
    }
}
