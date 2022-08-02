using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MiniSender;
using MiniSender.View;

namespace MiniSender.Model
{
    class EmailSender
    {
        public void SendMyMail()
        {
            try
            {
                MailAddress fromAddress = new MailAddress(ConfigVar.username);
                MailMessage message = new MailMessage();
                message.Subject = ConfigVar.subject;
                message.Body = ConfigVar.body;
                message.Sender = fromAddress;

                var smtp = new SmtpClient()
                {
                    Host = ConfigVar.host,
                    Port = ConfigVar.port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(ConfigVar.username, ConfigVar.password),
                };
                smtp.Send(ConfigVar.username, ConfigVar.reciever, message.Subject, message.Body);
                ConfigVar.logger = "done";
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                Console.WriteLine(ex.ToString());
                ConfigVar.logger = ex.ToString();
            }    
            

        }

    }
}
