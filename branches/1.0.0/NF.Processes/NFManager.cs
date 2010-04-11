using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace NF.Processes {
    public class NFManager {
        private const string DATE = "<DATE>";
        static string path = @"d:\NF_PROCESS\LOG\";
        public static void WriteLogFile(string fileName) {
            StreamWriter writer = new StreamWriter(path  + fileName + ".txt");
            writer.Flush();
        }

        public static void WriteLog(string text, string fileName) {
            StreamWriter writer = new StreamWriter(path + fileName + ".txt");
            writer.WriteLine(text);
            writer.Flush();
        }

        public static bool IsProcessSucceed(string file) {
            string[] files = Directory.GetFiles(path);
            foreach (string f in files) {
                if (Path.GetFileName(f).ToLower() == file.ToLower() + ".txt") {
                    return true;
                }
            }
            return false;
        }

        public static void SendEmail(string subject, string msg) {
            //string body = msg;
            //NetworkCredential loginInfo = new NetworkCredential("ludmal@gmail.com", "79081569xyz");

            //MailMessage m = new MailMessage("ludmal@gmail.com", "ludmal@gmail.com",string.Format("{0}- NF Process",subject), body);
            //SmtpClient client = new SmtpClient("smtp.gmail.com");

            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.Credentials = loginInfo;
            //client.Send(m);

        }

        public  static string GetDateString() {
            return DateTime.Now.ToString("ddMMyyyy");
        }

        public static string GetFileName() {
            return "Log_" + GetDateString();
        }

        public static DateTime LocalDate()
        {
            string timespanstr = "5:30";
            char[] c = { ':' };
            string hr = timespanstr.Split(c)[0];
            string min = timespanstr.Split(c)[1];

            TimeSpan s = new TimeSpan(Convert.ToInt32(hr), Convert.ToInt32(min), 0);
            return DateTime.UtcNow.Add(s);
        }

        public static string FormatURL(string url)
        {
            string dateTimeText = LocalDate().ToString("yyyy/MM/dd");
            if (url.Contains(DATE))
            {
                url = url.Replace(DATE, dateTimeText);
                return url;
            }
            return url;
        }

    }

    public enum NFProcess {
        Process1, Process2, Process3, Process4
    }

    public enum NFProcessStatus {
        Success, Failure
    }
}
