using MiniSender.Model;
using MiniSender.View;
using System;
using System.IO;
using System.Windows;

namespace MiniSender
{
    public partial class MainWindow : Window
    {
           
        public MainWindow()
        {
            InitializeComponent();
            FillData();
        }
        private void FillData()
        {
            Common.Host = tbServer.Text;
            Common.Port = Int32.Parse(tbPort.Text);
            Common.Subject = tbSubject.Text;
            Common.Password = tbPassword.Password;
            Common.Body = tbBody.Text;
            Common.Username = tbUserName.Text;
            Common.Reciever = tbToAddress.Text;
        }
        private void FillLogger()
        {
            tbLog.Text = Common.Logger;
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
            SaveMessage messageSaver = new SaveMessage();
            messageSaver.SaveInFile();
            FillLogger();
        }

        private void tbBody_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Common.Body = tbBody.Text;
        }

        private void tbSubject_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Common.Subject = tbSubject.Text;
        }

        private void tbToAddress_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Common.Reciever = tbToAddress.Text;
        }
    }
}
