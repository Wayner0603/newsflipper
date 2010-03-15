using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using NF.Processes;

namespace NF.Process2 {
    class Program {
        static void Main(string[] args) {
            try {
                //string path = @"D:\NF_PROCESS\";
                string path = string.Format(@"D:\NF_PROCESS\IMAGES\{0}\{1}\{2}\", NFManager.LocalDate().ToString(@"yyyy"), NFManager.LocalDate().ToString(@"MM"), NFManager.LocalDate().ToString(@"dd")); // Get the folder for the current day
                string[] files = Directory.GetFiles(path);
                string url = "ftp://www.newsflippers.com/pages/" + string.Format("{0}/{1}/{2}/", NFManager.LocalDate().ToString(@"yyyy"), NFManager.LocalDate().ToString(@"MM"), NFManager.LocalDate().ToString(@"dd"));
                string username = "u52705967";
                string pwd = "thu$hari78-$@";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uploading....");

                StringBuilder fileList = new StringBuilder();

                foreach (string file in files) {
                    fileList.Append(Path.GetFileName(file) + "/r/n");
                    UploadFile(url, file, username, pwd);
                }

                Console.WriteLine("All the files uploaded");
                Console.ForegroundColor = ConsoleColor.Green;
                NFManager.WriteLog(fileList.ToString(), string.Format("FTP_{1}", NFManager.GetFileName()));

            } catch (Exception ex) {
                NFManager.SendEmail("Failure", ex.Message);
            }
        }

        private static void UploadFile(string FTPAddress, string filePath, string username, string password) {
            //Create FTP request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0} file uploaded.", Path.GetFileName(filePath)));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
