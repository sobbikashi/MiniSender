using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MiniSender
{  
    public partial class MainWindow : Window
    {
        private string letterData;

        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fromAddress = new MailAddress(cbFromAddress.Text);
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
                    tbLog.Text = "Message has been sent";

                }
                //MessageBox.Show("Message has been sent");

            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                Console.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string path = @"E:\УЧЁБА\logs\mail.txt";
            if (!File.Exists(path))
            {
                letterData = "От кого: " + tbUserName.Text + "\n" + "Кому: " + tbToAddress.Text + "\n" + tbSubject.Text + "\n" + tbBody.Text + Environment.NewLine;
                File.WriteAllText(path, letterData);
            }
            File.AppendAllText(path, letterData);

        }
    }
}
