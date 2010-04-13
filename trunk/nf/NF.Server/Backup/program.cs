using System;
using System.Collections.Generic;
using System.Text;

namespace webshotex_csharp
{
    class program
    {
        [STAThread] // [STAThread] REQUIRED!
        static void Main(string[] args)
        {
            int WebShotHandle = 0;

			
            WebShot.DllInit("debug.log", WebShot.DEBUG_FLAGWINDOW | WebShot.DEBUG_FLAGFILE);

			WebShot.OleInitialize(IntPtr.Zero);
			
            WebShot.Create(ref WebShotHandle);
            WebShot.SetVerbose(WebShotHandle, 1);
            
            if (WebShot.Open(WebShotHandle, "http://www.nathanm.com/") == 0)
                Console.WriteLine("Error: Cannot take screenshot!");
        
            WebShot.Destroy(ref WebShotHandle);

			WebShot.OleUninitialize();
			
            WebShot.DllUninit();

            return;
        }
    }
}
