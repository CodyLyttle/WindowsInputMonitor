namespace WindowsInputMonitor
{
    public static class Mouse
    {
        public static IMouseHook CreateHook()
        {
            return new Monitoring.GlobalMouseMonitor();
        }
    }
}
