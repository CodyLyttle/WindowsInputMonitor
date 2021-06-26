namespace WindowsInputMonitor.Win32API
{
    internal static class Win32Extensions
    {
        public static MouseButton ToMouseButton(this MouseMessage message)
        {
            return message switch
            {
                MouseMessage.WM_LBUTTONDOWN or
                MouseMessage.WM_LBUTTONUP => MouseButton.Left,

                MouseMessage.WM_RBUTTONDOWN or
                MouseMessage.WM_RBUTTONUP => MouseButton.Right,

                MouseMessage.WM_MBUTTONDOWN or
                MouseMessage.WM_MBUTTONUP => MouseButton.Middle,

                _ => MouseButton.None,
            };
        }

        public static MouseAction ToMouseAction(this MouseMessage message)
        {
            return message switch
            {
                MouseMessage.WM_MOUSEMOVE => MouseAction.Move,
                MouseMessage.WM_MOUSEWHEEL => MouseAction.Scroll,

                MouseMessage.WM_LBUTTONDOWN or 
                MouseMessage.WM_RBUTTONDOWN or 
                MouseMessage.WM_MBUTTONDOWN => MouseAction.Down,

                MouseMessage.WM_LBUTTONUP or 
                MouseMessage.WM_RBUTTONUP or 
                MouseMessage.WM_MBUTTONUP => MouseAction.Up,

                _ => MouseAction.Ignore
            };
        }
    }
}
