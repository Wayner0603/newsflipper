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
using System.Data;
using NF.Core;

namespace NF.ProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\NF_PROCESS\";
            string xmlPath = @"D:\NF_PROCESS\webshotcmd.xml";
            string exePath = @"D:\NF_PROCESS\webshotcmd.exe";

            //Step 1
            try
            {
                StreamWriter w = new StreamWriter(path + "urls_TEST.txt");

                DataSet ds = News.GetData();

                StringBuilder b = new StringBuilder();

                foreach (DataRow s in ds.Tables[0].Rows)
                {
                    w.WriteLine("{0}", s["NEWS_LINK"].ToString());
                }

                w.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
                return;
            }
            //Step 2 
            try
            {
                File.Delete(xmlPath);

            }
            catch (Exception ex)
            {
                throw ex;
                return;
            }

            //Step 3
            try
            {

                StringBuilder xml = new StringBuilder();
                string imagePath = string.Format(@"D:\NF_PROCESS\IMAGES\TEST\{0}\{1}\{2}\%u.gif", NFManager.LocalDate().ToString(@"yyyy"), NFManager.LocalDate().ToString(@"MM"), NFManager.LocalDate().ToString(@"dd")); // Get the folder for the current day
                xml.AppendFormat(@"<WebShot><Debug>FALSE</Debug> <ImagePath>{0}</ImagePath> <ImageQuality>30</ImageQuality> <ImageType>gif</ImageType> <BrowserWidth>1000</BrowserWidth> <BrowserHeight>800</BrowserHeight> <BatchFile>{1}</BatchFile> <Verbose>TRUE</Verbose> <DisableActiveX></DisableActiveX><DisableScripts></DisableScripts><IgnoreErrors></IgnoreErrors><ThreadMax>50</ThreadMax> </WebShot>", imagePath, path + "urls_TEST.txt");

                StreamWriter xmlf = new StreamWriter(path + "webshotcmd.xml");
                xmlf.Write(xml);
                xmlf.Flush();

            }
            catch (Exception ex)
            {
                throw ex;
                return;
            }

            //Step 4 - Execute the webshot.exe 
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = exePath;
                //cmd.StartInfo.RedirectStandardOutput =true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                //Console.WriteLine
                //(cmd.StandardOutput.ReadToEnd());
                //cmd.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
