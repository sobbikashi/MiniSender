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
        private MailAddress from;
        private MailAddress to;

     
        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Model.EmailSender emailSender = new Model.EmailSender();
            MailMessage mail = new MailMessage();
            mail.Subject = tbSubject.Text;
            mail.Body = tbBody.Text;
            from = new MailAddress("test.send207 @gmail.com");
            to = new MailAddress("vanilmirth@inbox.ru");
            emailSender.Send(from, to, mail, tbPassword.Password);
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
