using System;
using System.Runtime.InteropServices;

namespace WindowsInputMonitor.Win32API
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr CallNextHookEx(
            IntPtr idHook,
            int nCode,
            UIntPtr wParam,
            IntPtr lParam);


        [DllImport("user32.dll", SetLastError = true)]
        internal static extern SafeHookHandle SetWindowsHookEx(
            int idHook,
            CallbackFunction lpfn,
            IntPtr hMod,
            uint dwThreadId);


        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnhookWindowsHookEx(IntPtr idHook);
    }
}
