using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NF.Engine.Facade;
using NF.Engine;
using Infonex;
using System.Drawing;

namespace webshotex_csharp
{
    public class program
    {
        [STAThread] // [STAThread] REQUIRED!
        static void Main(string[] args)
        {
            DataTable dt = SourceFacade.GetSourceItems();
            CaptureScreenshot(ref dt);
        }

        public static void CaptureScreenshot(ref DataTable dt)
        {
            WebShot.OleInitialize(IntPtr.Zero);

            for (int i = 0; i < dt.Rows.Count ; i++)
            {
                string imgName = string.Format("{0}.gif", ShortGuid.NewGuid().ToString());
                string imgNameThumb = string.Format("t__{0}.gif", ShortGuid.NewGuid().ToString());
                string path = string.Format(@"{0}{1}", Util.GetImageFolder(), imgName);
                string pathTo = string.Format(@"{0}{1}", Util.GetImageFolder(), imgNameThumb);
                try
                {
                    CaptureScreenshot(dt.Rows[i]["ITM_URL"].ToString(), path );
                    //ImageManager.ResizeImageFile(PhotoSize.Medium, path, pathTo);
                    Bitmap b = ImageManager.ResizeImage(System.Drawing.Image.FromFile(path), 320, 340);
                    ImageManager.SaveJpeg(pathTo, b, 60);

                    dt.Rows[i]["ITM_IMGNAME"] = imgName;
                    dt.Rows[i]["ITM_IMGTHUMB"] = imgNameThumb;
                    dt.Rows[i]["ITM_IMAGE"] = true;
                    dt.Rows[i]["ITM_FAILED"] = 0;
                }
                catch 
                {
                    dt.Rows[i]["ITM_FAILED"] = 1;

                }
            }
            WebShot.OleUninitialize();
            SourceFacade.InsertSourceItems(dt);
        }

        public static void CaptureScreenshot(string Url, string ImageFilename)
        {
            int WebShotHandle = 0;

            WebShot.DllInit("debug.log", WebShot.DEBUG_FLAGWINDOW | WebShot.DEBUG_FLAGFILE);

            WebShot.Create(ref WebShotHandle);
            WebShot.SetVerbose(WebShotHandle, 1);
            WebShot.SetRedirectMaximum(WebShotHandle, 10);
            WebShot.SetPageTimeout(WebShotHandle, 40);
            WebShot.SetVerbose(WebShotHandle, 1);
            WebShot.SetBrowserHeight(WebShotHandle, 800);
            WebShot.SetBrowserWidth(WebShotHandle, 1000);
            WebShot.SetImageQuality(WebShotHandle, 30);
            WebShot.SetRedirectMaximum(WebShotHandle, 10);
            WebShot.SetOutputPath(WebShotHandle, ImageFilename);

            if (WebShot.Open(WebShotHandle, Url) == 0)
                Console.WriteLine("Error: Cannot take screenshot!");

            WebShot.Destroy(ref WebShotHandle);
            WebShot.DllUninit();

        }
    }
}
