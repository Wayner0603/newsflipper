using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Net;
using System.IO;
using NF.Processes;
using System.Data.SqlClient;


namespace NF.Process1 {
    class Program {
        [STAThread()]
        static void Main(string[] args) {
            string path = @"D:\NF_PROCESS\";
            string xmlPath = @"D:\NF_PROCESS\webshotcmd.xml";
            string exePath = @"D:\NF_PROCESS\webshotcmd.exe";
            
            //Step 1
            try {
                StreamWriter w = new StreamWriter(path + "urls.txt");

                List<Source> sources = GetAllSources();
                StringBuilder b = new StringBuilder();

                StreamWriter writer = new StreamWriter(@"D:\NF_PROCESS\urls1.txt");
                foreach (Source s in sources)
                {
                    w.WriteLine("{0}", NFManager.FormatURL(s.Url));
                }

                w.Flush();

                WriteLine("Urls text file created.", NFProcess.Process1);
                NFManager.WriteLogFile("Process1_" + NFManager.GetDateString());
                
            } catch (Exception ex) {
                LogError(ex, NFProcess.Process1);
                return;
            }
            //Step 2 
            try {
                if (!NFManager.IsProcessSucceed("Process1_" + NFManager.GetDateString())) {
                    throw new Exception("Previous process not succeed!");   
                }

                File.Delete(xmlPath);
                WriteLine("Xml file successfully deleted.", NFProcess.Process2);
                NFManager.WriteLogFile("Process2_" + NFManager.GetDateString());

            } catch (Exception ex) {
                LogError(ex, NFProcess.Process2);
                return;
            }
           
            //Step 3
            try {
                if (!NFManager.IsProcessSucceed("Process2_" + NFManager.GetDateString())) {
                    throw new Exception("Previous process not succeed!");
                }

                StringBuilder xml = new StringBuilder();
                string imagePath = string.Format(@"D:\NF_PROCESS\IMAGES\{0}\{1}\{2}\%d%p.gif", NFManager.LocalDate().ToString(@"yyyy"), NFManager.LocalDate().ToString(@"MM"), NFManager.LocalDate().ToString(@"dd")); // Get the folder for the current day
                xml.AppendFormat(@"<WebShot><Debug>FALSE</Debug> <ImagePath>{0}</ImagePath> <ImageQuality>30</ImageQuality> <ImageType>gif</ImageType> <BrowserWidth>1000</BrowserWidth> <BrowserHeight>800</BrowserHeight> <BatchFile>{1}</BatchFile> <Verbose>TRUE</Verbose> <DisableActiveX></DisableActiveX><DisableScripts></DisableScripts><IgnoreErrors></IgnoreErrors><ThreadMax>50</ThreadMax> </WebShot>", imagePath, path + "urls.txt");

                StreamWriter xmlf = new StreamWriter(path + "webshotcmd.xml");
                xmlf.Write(xml);
                xmlf.Flush();

                WriteLine("Xml successfully created", NFProcess.Process3);
                NFManager.WriteLogFile("Process3_" + NFManager.GetDateString());
                
            } catch (Exception ex) {
                LogError(ex, NFProcess.Process3);
                return;
            }

            //Step 4 - Execute the webshot.exe 
            try {
                Process cmd = new Process();
                cmd.StartInfo.FileName = exePath;
                //cmd.StartInfo.RedirectStandardOutput =true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                Console.WriteLine
                (cmd.StandardOutput.ReadToEnd());
                cmd.Close();
            } catch (Exception ex) {
                LogError(ex, NFProcess.Process4);
            }
        }

        private static void LogError(Exception ex, NFProcess process) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            NFManager.WriteLog(ex.Message, NFManager.GetFileName());
            Console.ForegroundColor = ConsoleColor.White;

            //Send Email
            NFManager.SendEmail(string.Format("Failure on {0}", process.ToString()), ex.Message);
        }

        private static void WriteLine(string text, NFProcess process) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            //NFManager.WriteLog(text, NFManager.GetFileName());
            //NFManager.SendEmail(string.Format("Success on {0}", process.ToString()),text );
        }

      

        public static List<Source> GetAllSources()
        {
            SqlConnection cnn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NF;Data Source=LUDMAL_PC");
            SqlCommand cmd = new SqlCommand("USP_NEWSPAPERS_GETALL", cnn);
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Source> sourceList = new List<Source>();
            while (rdr.Read())
            {
                sourceList.Add(new Source()
                {
                    ID = Convert.ToInt32(rdr["NPR_ID"]),
                    ParentID = Convert.ToInt32(rdr["NPR_PARENT_ID"]),
                    Title = rdr["NPR_TITLE"].ToString(),
                    Desc = rdr["NPR_DESC"].ToString(),
                    Url = rdr["NPR_URL"].ToString(),
                    Active = Convert.ToBoolean(rdr["NPR_ACTIVE"])
                });
            }
            rdr.Close();
            cnn.Close();
            return sourceList;
        }

    }

    public class Source
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
        public string Desc { get; set; }

    }
}
