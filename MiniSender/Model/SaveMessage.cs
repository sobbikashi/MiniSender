using MiniSender.View;
using System;
using System.IO;

namespace MiniSender.Model
{
    public class SaveMessage
    {
        string path = @"E:\УЧЁБА\logs\maillog.txt";
        private string letterData;
        DateTime loggerTime = DateTime.Now;
        public void SaveInFile()
        {
            if (!File.Exists(path))
            {
                letterData = loggerTime.ToString() + "\n" + "От кого: " + Common.Username + "\n" + "Кому: " + Common.Reciever + "\n" + Common.Subject + "\n" + Common.Body + Environment.NewLine;
                File.WriteAllText(path, letterData);
            }
            File.AppendAllText(path, letterData);
            Common.Logger = "Сохранено";            
        }
    }
}
