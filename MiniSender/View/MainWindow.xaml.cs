using MiniSender.Model;
using MiniSender.View;
using System;
using System.IO;
using System.Windows;

namespace MiniSender
{
    public partial class MainWindow : Window
    {
        private string letterData;
        DateTime loggerTime = DateTime.Now;

     
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
            string path = @"E:\УЧЁБА\logs\maillog.txt";
            if (!File.Exists(path))
            {
                letterData = loggerTime.ToString() + "\n" + "От кого: " + ConfigVar.Username + "\n" + "Кому: " + ConfigVar.Reciever + "\n" + ConfigVar.Subject + "\n" + ConfigVar.Body + Environment.NewLine;
                File.WriteAllText(path, letterData);
            }
            File.AppendAllText(path, letterData);
            ConfigVar.Logger = "Сохранено";
            FillLogger();

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
