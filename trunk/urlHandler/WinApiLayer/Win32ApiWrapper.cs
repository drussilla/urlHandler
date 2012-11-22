using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace urlHandler.WinApiLayer
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ProcessBasicInformation
    {
        public IntPtr ExitStatus;
        public IntPtr PepBaseAddress;
        public IntPtr AffinityMask;
        public IntPtr BasePriority;
        public IntPtr UniqueProcessID;
        public IntPtr InheritedFromUniqueProcessId;
    }

    public class Win32ApiWrapper
    {
        private static uint PROCESSBASICINFORMATION = 0;

        public static int GetParentProcessId()
        {
            ProcessBasicInformation ProccessInfo = new ProcessBasicInformation();

            IntPtr ProcHandle = Process.GetCurrentProcess().Handle;

            uint RetLength = 0;

            NtQueryInformationProcess(ProcHandle, PROCESSBASICINFORMATION, ref ProccessInfo, Marshal.SizeOf(ProccessInfo), ref RetLength);

            return ProccessInfo.InheritedFromUniqueProcessId.ToInt32();
        }

        public static string GetParentProcessName()
        {
            int ParentId = GetParentProcessId();
            Process ParentProcess = Process.GetProcessById(ParentId);
            return ParentProcess.ProcessName;
        }

        [DllImport("ntdll.dll", EntryPoint = "NtQueryInformationProcess")]
        private static extern int NtQueryInformationProcess(IntPtr handle, uint processinformationclass, ref ProcessBasicInformation processInformation, int processInformationLength, ref uint returnLength);
    }
}
