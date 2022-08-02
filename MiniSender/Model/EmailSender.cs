using System;
using System.Diagnostics;
using System.IO;
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
                MailAddress from = new MailAddress(Common.Username);
                MailAddress to = new MailAddress(Common.Reciever);
                MailMessage message = new MailMessage(from, to);
                message.Subject = Common.Subject;
                message.Body = Common.Body;


                if ((Common.Path != "") & (File.Exists(Common.Path)))
                {
                    Attachment data = new Attachment(Common.Path);
                    message.Attachments.Add(data);
                }
                

                var smtp = new SmtpClient()
                {
                    Host = Common.Host,
                    Port = Common.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Common.Username, Common.Password),
                };                
                smtp.Send(message);
                Common.Logger = message.Attachments.ToString();
                
            }
            catch (Exception ex)
            {              
               Common.Logger = ex.ToString();
            }    
            

        }

    }
}
