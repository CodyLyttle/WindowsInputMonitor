using Microsoft.Win32.SafeHandles;

namespace WindowsInputMonitor.Win32API
{
    internal class SafeHookHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public SafeHookHandle() : base(ownsHandle: true)
        {
        }

        protected override bool ReleaseHandle()
            => NativeMethods.UnhookWindowsHookEx(handle);
        
    }
}
