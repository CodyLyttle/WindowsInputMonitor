
using System;
using System.Diagnostics;

namespace WindowsInputMonitor.Monitoring
{
    internal abstract class InputMonitor
    {
        private readonly Win32.CallbackFunction _callback;
        private readonly Win32.SafeHookHandle _hookHandle;

        public InputMonitor(Win32.HookType hookType)
        {
            _callback = new Win32.CallbackFunction(HandleCallback);
            _hookHandle = Win32.NativeMethods.SetWindowsHookEx((int)hookType, _callback, GetPointerToThisLibrary(), 0);
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

            return Win32.NativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        private static IntPtr GetPointerToThisLibrary()
            => Process.GetCurrentProcess().MainModule.BaseAddress;
    }
}
