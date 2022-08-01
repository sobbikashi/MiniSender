using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using MiniSender;

namespace MiniSender.Model
{
    class EmailSender
    {
        public void SendMyMail()
        {
           MailAddress from = new MailAddress("test.send207@gmail.com");
           MailAddress to = new MailAddress("vanilmirth@inbox.ru");
           MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "проверка";
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("test.send207@gmail.com", "oddmopuytnwnchjj"),
            };
            smtp.Send(m);

        }

    }
}
