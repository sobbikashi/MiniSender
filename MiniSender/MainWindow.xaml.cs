using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MiniSender
{  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fromAddress = new MailAddress(tbUserName.Text);
                var toAddress = new MailAddress(tbToAddress.Text);

                string subject = tbSubject.Text;

                string body = tbBody.Text;

                string password = tbPassword.Password;

                var smtp = new SmtpClient()

                {
                    Host = tbServer.Text,
                    Port = Int32.Parse(tbPort.Text),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(tbUserName.Text, password),
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("Message has been sent");
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                Console.WriteLine(ex);
            }
        }
    }
}
