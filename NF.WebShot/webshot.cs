using System;
using System.Text;
using System.Runtime.InteropServices;
using mshtml; // Microsoft.mshtml primary Interop assembly

/*********************************************************************/

public class WebShot {

    [DllImport("ole32.dll")]
    public static extern int OleInitialize(IntPtr pvReserved);
    [DllImport("ole32.dll")]
    public static extern void OleUninitialize();

    public const int DEBUG_FLAGDISABLED				= (0x00000000);
    public const int DEBUG_FLAGWINDOW				= (0x00000001);
    public const int DEBUG_FLAGFILE					= (0x00000002);
    public const int DEBUG_FLAGVERBOSE				= (0x00000004);
    public const int DEBUG_FLAGAPPEND				= (0x00000008);
    public const int DEBUG_FLAGCOMMANDLINE			= (0x00000010);
    public const int DEBUG_FLAGTIMESTAMP			= (0x00000020);
    public const int DEBUG_FLAGPERTHREAD			= (0x00000100);

    /*********************************************************************/

    public delegate int ProgressCallback(int WebShotHandle, int UserHandle, double Progress);
    public delegate int StatusCallback(int WebShotHandle, int UserHandle, string Status);
    public delegate int DocumentCallback(int WebShotHandle, int UserHandle, ref IHTMLDocument2 Document);
    public delegate int CaptureCallback(int WebShotHandle, int UserHandle, int hBitmap, ref int SaveToFile);
    public delegate int ExitCallback(int UserHandle);

    /*********************************************************************/

    [DllImport("webshot.dll", EntryPoint="WebShot_Stop", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int Stop(int WebShotHandle);
    [DllImport("webshot.dll", EntryPoint="WebShot_Open", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int Open(int WebShotHandle, string Url);

    [DllImport("webshot.dll", EntryPoint="WebShot_SetProgressCallback", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetProgressCallback(int WebShotHandle, int UserHandle, ProgressCallback Callback);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetStatusCallback", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetStatusCallback(int WebShotHandle, int UserHandle, StatusCallback Callback);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetDocumentCallback", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetDocumentCallback(int WebShotHandle, int UserHandle, DocumentCallback Callback);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetCaptureCallback", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetCaptureCallback(int WebShotHandle, int UserHandle, CaptureCallback Callback);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetExitCallback", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetExitCallback(int WebShotHandle, int UserHandle, ExitCallback Callback);

    [DllImport("webshot.dll", EntryPoint="WebShot_GetParentWindow", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetParentWindow(int WebShotHandle, ref int hWnd);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetParentWindow", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetParentWindow(int WebShotHandle, int hWnd);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetOutputPath", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetOutputPath(int WebShotHandle, StringBuilder Path, int MaxPath);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetOutputPath", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetOutputPath(int WebShotHandle, string Path);

    [DllImport("webshot.dll", EntryPoint="WebShot_GetPageTimeout", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetPageTimeout(int WebShotHandle, ref int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetPageTimeout", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetPageTimeout(int WebShotHandle, int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetMetaRefreshTimeout", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetMetaRefreshTimeout(int WebShotHandle, ref int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetMetaRefreshTimeout", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetMetaRefreshTimeout(int WebShotHandle, int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetDocumentWait", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetDocumentWait(int WebShotHandle, ref int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetDocumentWait", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetDocumentWait(int WebShotHandle, int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetDocumentWaitFlash", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetDocumentWaitFlash(int WebShotHandle, ref int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetDocumentWaitFlash", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetDocumentWaitFlash(int WebShotHandle, int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageWait", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageWait(int WebShotHandle, ref int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageWait", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageWait(int WebShotHandle, int Seconds);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetRedirectMaximum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetRedirectMaximum(int WebShotHandle, ref int MaxRedirects);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetRedirectMaximum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetRedirectMaximum(int WebShotHandle, int MaxRedirects);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetRedirectCount", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetRedirectCount(int WebShotHandle, ref int Count);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetRedirectUrl", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetRedirectUrl(int WebShotHandle, StringBuilder RedirectUrl, int MaxRedirectUrl);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetUrl", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetUrl(int WebShotHandle, StringBuilder Url, int MaxUrl);	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetTitle", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetTitle(int WebShotHandle, StringBuilder Title, int MaxTitle);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetTitle", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetTitle(int WebShotHandle, string Title);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetMetaKeywords", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetMetaKeywords(int WebShotHandle, StringBuilder MetaKeywords, int MaxMetaKeywords);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetMetaDescription", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetMetaDescription(int WebShotHandle, StringBuilder MetaDescription, int MaxMetaDescription);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetUserAgent", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetUserAgent(int WebShotHandle, StringBuilder UserAgent, int MaxUserAgent);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetUserAgent", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetUserAgent(int WebShotHandle, string UserAgent);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetCustomHeaders", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetCustomHeaders(int WebShotHandle, StringBuilder CustomHeaders, int MaxCustomHeaders);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetCustomHeaders", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetCustomHeaders(int WebShotHandle, string CustomHeaders);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetResponseHeaders", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetResponseHeaders(int WebShotHandle, StringBuilder ResponseHeaders, int MaxResponseHeaders);
	[DllImport("webshot.dll", EntryPoint="WebShot_GetPostData", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetPostData(int WebShotHandle, StringBuilder PostData, int MaxPostData);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetPostData", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetPostData(int WebShotHandle, string PostData);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_SetUsername", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetUsername(int WebShotHandle, string Username);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetPassword", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetPassword(int WebShotHandle, string Password);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetDisableActiveX", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetDisableActiveX(int WebShotHandle, ref int DisableActiveX);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetDisableActiveX", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetDisableActiveX(int WebShotHandle, int DisableActiveX);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetDisableScripts", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetDisableScripts(int WebShotHandle, ref int DisableScripts);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetDisableScripts", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetDisableScripts(int WebShotHandle, int DisableScripts);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserWidth", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserWidth(int WebShotHandle, ref int Width);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserWidth", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserWidth(int WebShotHandle, int Width);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserHeight", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserHeight(int WebShotHandle, ref int Height);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserHeight", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserHeight(int WebShotHandle, int Height);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserWidthMinimum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserWidthMinimum(int WebShotHandle, ref int MinimumWidth);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserWidthMinimum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserWidthMinimum(int WebShotHandle, int MinimumWidth);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserHeightMinimum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserHeightMinimum(int WebShotHandle, ref int MinimumHeight);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserHeightMinimum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserHeightMinimum(int WebShotHandle, int MinimumHeight);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserWidthMaximum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserWidthMaximum(int WebShotHandle, ref int MaximumWidth);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserWidthMaximum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserWidthMaximum(int WebShotHandle, int MaximumWidth);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserHeightMaximum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserHeightMaximum(int WebShotHandle, ref int MaximumHeight);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserHeightMaximum", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserHeightMaximum(int WebShotHandle, int MaximumHeight);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetHttpCode", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetHttpCode(int WebShotHandle, ref int HttpCode);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetBrowserVisible", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetBrowserVisible(int WebShotHandle, ref int Visible);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetBrowserVisible", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetBrowserVisible(int WebShotHandle, int Visible);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageFilename(int WebShotHandle, StringBuilder ImageFilename, int MaxImageFilename);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageType", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageType(int WebShotHandle, StringBuilder Type, int MaxType);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageType", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageType(int WebShotHandle, string Type);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageWidth", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageWidth(int WebShotHandle, ref int Width);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageWidth", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageWidth(int WebShotHandle, int Width);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageHeight", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageHeight(int WebShotHandle, ref int Height);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageHeight", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageHeight(int WebShotHandle, int Height);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageQuality", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageQuality(int WebShotHandle, ref int ImageQuality);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageQuality", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageQuality(int WebShotHandle, int ImageQuality);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageGrayscale", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageGrayscale(int WebShotHandle, ref int ImageGrayscale);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageGrayscale", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageGrayscale(int WebShotHandle, int ImageGrayscale);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetImageSaveToDisk", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetImageSaveToDisk(int WebShotHandle, ref int SaveToDisk);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetImageSaveToDisk", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetImageSaveToDisk(int WebShotHandle, int SaveToDisk);
	
	[DllImport("webshot.dll", EntryPoint="WebShot_SetWatermarkFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
	public static extern int SetWatermarkFilename(int WebShotHandle, string Filename);
	[DllImport("webshot.dll", EntryPoint="WebShot_SetWatermarkPosition", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
	public static extern int SetWatermarkPosition(int WebShotHandle, double MultiX, double MultiY);
	[DllImport("webshot.dll", EntryPoint="WebShot_SetWatermarkOpacity", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
	public static extern int SetWatermarkOpacity(int WebShotHandle, double Opacity);	
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetCsvFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetCsvFilename(int WebShotHandle, StringBuilder Filename, int MaxFilename);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetCsvFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetCsvFilename(int WebShotHandle, string Filename);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetHtmlFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetHtmlFilename(int WebShotHandle, StringBuilder Filename, int MaxFilename);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetHtmlFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetHtmlFilename(int WebShotHandle, string Filename);
    [DllImport("webshot.dll", EntryPoint="WebShot_GetLinkFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetLinkFilename(int WebShotHandle, StringBuilder Filename, int MaxFilename);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetLinkFilename", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetLinkFilename(int WebShotHandle, string Filename);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetError", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetError(int WebShotHandle, StringBuilder Error, int MaxError);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetVerbose", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetVerbose(int WebShotHandle, ref int Verbose);
    [DllImport("webshot.dll", EntryPoint="WebShot_SetVerbose", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int SetVerbose(int WebShotHandle, int Verbose);
	
    [DllImport("webshot.dll", EntryPoint="WebShot_GetWindow", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int GetWindow(int WebShotHandle, ref int hWnd);

    [DllImport("webshot.dll", EntryPoint="WebShot_Create", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int Create(ref int WebShotHandle);
    [DllImport("webshot.dll", EntryPoint="WebShot_Destroy", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int Destroy(ref int WebShotHandle);

    [DllImport("webshot.dll", EntryPoint="WebShot_DllInit", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int DllInit(string DebugFilename, int DebugFlags);
    [DllImport("webshot.dll", EntryPoint="WebShot_DllUninit", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
    public static extern int DllUninit();

    /*********************************************************************/

}
