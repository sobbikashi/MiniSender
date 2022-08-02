using MiniSender.Model;
using MiniSender.View;
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
            FillData();

        }
        private void FillData()
        {
            ConfigVar.host = tbServer.Text;
            ConfigVar.port = Int32.Parse(tbPort.Text);
            ConfigVar.subject = tbSubject.Text;
            ConfigVar.password = tbPassword.Password;
            ConfigVar.body = tbBody.Text;
            ConfigVar.username = tbUserName.Text;
            ConfigVar.reciever = tbToAddress.Text;
        }
        private void FillLogger()
        {
            tbLog.Text = ConfigVar.logger;
        }
       

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            EmailSender mail = new EmailSender();
            mail.SendMyMail();
            FillLogger();
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
