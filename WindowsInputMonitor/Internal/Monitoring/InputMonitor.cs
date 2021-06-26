
using System;
using System.Diagnostics;

namespace WindowsInputMonitor.Monitoring
{
    internal abstract class InputMonitor
    {
        private readonly Win32API.CallbackFunction _callback;
        private readonly Win32API.SafeHookHandle _hookHandle;

        public InputMonitor(Win32API.HookType hookType)
        {
            _callback = new Win32API.CallbackFunction(HandleCallback);
            _hookHandle = Win32API.NativeMethods.SetWindowsHookEx((int)hookType, _callback, GetPointerToThisLibrary(), 0);
        }
        public void Dispose()
        {
            _hookHandle.Dispose();
        }

        protected abstract void ParseCallbackData(UIntPtr messageCode, IntPtr structPtr);

        private IntPtr HandleCallback(int nCode, UIntPtr wParam, IntPtr lParam)
        {
            // Our inner callback function should only be called if nCode is non-negative.
            // A negative value means that a hook higher in the chain has requested no further callbacks be executed.
            if(nCode >= 0)
                ParseCallbackData(wParam, lParam);

            return Win32API.NativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        private static IntPtr GetPointerToThisLibrary()
            => Process.GetCurrentProcess().MainModule.BaseAddress;
    }
}
