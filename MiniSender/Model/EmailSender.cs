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
                message.Subject = Common.Subject;
                message.Body = Common.Body;
               

                var smtp = new SmtpClient()
                {
                    Host = Common.Host,
                    Port = Common.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Common.Username, Common.Password),
                };
                smtp.Send(Common.Username, Common.Reciever, message.Subject, message.Body);
                Common.Logger = "done";
            }
            catch (Exception ex)
            {              
               Common.Logger = ex.ToString();
            }    
            

        }

    }
}
