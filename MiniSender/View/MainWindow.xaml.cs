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
            ConfigVar.Host = tbServer.Text;
            ConfigVar.Port = Int32.Parse(tbPort.Text);
            ConfigVar.Subject = tbSubject.Text;
            ConfigVar.Password = tbPassword.Password;
            ConfigVar.Body = tbBody.Text;
            ConfigVar.Username = tbUserName.Text;
            ConfigVar.Reciever = tbToAddress.Text;
        }
        private void FillLogger()
        {
            tbLog.Text = ConfigVar.Logger;
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

        private void tbBody_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ConfigVar.Body = tbBody.Text;
        }

        private void tbSubject_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ConfigVar.Subject = tbSubject.Text;
        }

        private void tbToAddress_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ConfigVar.Reciever = tbToAddress.Text;
        }
    }
}
