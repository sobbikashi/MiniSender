using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using MiniSender;

namespace MiniSender.Model
{
    class EmailSender
    {
        public void Send(MailAddress fromAddress, MailAddress toAddress, string message, string password)
        {
            try
            {
                fromAddress = new MailAddress("test.send207@gmail.com");
                toAddress = new MailAddress("vanilmirth@inbox.ru");

                //string subject = message.Subject;

                //string body = message.Body;

                //string password = tbPassword.Password;

                var smtp = new SmtpClient()

                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("test.send207@gmail.com", password),
                };                
                    smtp.Send(fromAddress, toAddress, message, password);
                    //MiniSender.tbLog.Text = DateTime.Now.ToString() + " Message has been sent";
                                
                //MessageBox.Show("Message has been sent");

            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                Console.WriteLine(ex.ToString());
                //tbLog.Text = DateTime.Now.ToString() + " " + ex.ToString();
            }
        }

    }
}
