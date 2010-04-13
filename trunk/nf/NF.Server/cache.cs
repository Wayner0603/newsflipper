using System;
using System.Text;
using System.Runtime.InteropServices;

/*********************************************************************/

public class Cache {

    /*********************************************************************/

    [DllImport("webshot.dll", EntryPoint="Cache_MemberGetSourcePtr", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int MemberGetSourcePtr(int CacheHandle, int MemberHandle, ref string SourcePtr);
    [DllImport("webshot.dll", EntryPoint="Cache_MemberGetFilenamePtr", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int MemberGetFilenamePtr(int CacheHandle, int MemberHandle, ref string FilenamePtr);
    [DllImport("webshot.dll", EntryPoint="Cache_MemberGetDelete", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int MemberDelete(int CacheHandle, int MemberHandle);
    [DllImport("webshot.dll", EntryPoint="Cache_MemberGetFirst", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int MemberGetFirst(int CacheHandle, ref int MemberHandle);
    [DllImport("webshot.dll", EntryPoint="Cache_MemberGetNext", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int MemberGetNext(int CacheHandle, int MemberHandle, ref int NextMemberHandle);

    [DllImport("webshot.dll", EntryPoint="Cache_Delete", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int Delete(int CacheHandle);
    [DllImport("webshot.dll", EntryPoint="Cache_Load", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int Load(int CacheHandle);

    [DllImport("webshot.dll", EntryPoint="Cache_GetVerbose", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int GetVerbose(int CacheHandle, ref int Verbose);
    [DllImport("webshot.dll", EntryPoint="Cache_SetVerbose", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int SetVerbose(int CacheHandle, int Verbose);

    [DllImport("webshot.dll", EntryPoint="Cache_Create", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int Create(ref int CacheHandle);
    [DllImport("webshot.dll", EntryPoint="Cache_Destroy", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern int Destroy(ref int CacheHandle);

    /*********************************************************************/

}
