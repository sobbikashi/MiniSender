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
                MailMessage message = new MailMessage();
                message.Subject = ConfigVar.Subject;
                message.Body = ConfigVar.Body;
               

                var smtp = new SmtpClient()
                {
                    Host = ConfigVar.Host,
                    Port = ConfigVar.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(ConfigVar.Username, ConfigVar.Password),
                };
                smtp.Send(ConfigVar.Username, ConfigVar.Reciever, message.Subject, message.Body);
                ConfigVar.Logger = "done";
            }
            catch (Exception ex)
            {              
               ConfigVar.Logger = ex.ToString();
            }    
            

        }

    }
}
