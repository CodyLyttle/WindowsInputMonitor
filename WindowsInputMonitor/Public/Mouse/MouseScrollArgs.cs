namespace WindowsInputMonitor
{
    public class MouseScrollArgs : MouseArgs
    {
        private const int _notchValue = 120;

        public int Delta { get; }
        public int NotchCount { get; }
        public ScrollDirection Direction { get; }
        
        public MouseScrollArgs(int x, int y, int delta) : base(x, y)
        {
            Delta = delta;

            Direction = delta >= 0 
                ? ScrollDirection.Up 
                : ScrollDirection.Down;

            if (Delta > 0)
                NotchCount = Delta / _notchValue;
            else if (Delta < 0)
                NotchCount = Delta / _notchValue * -1;
        }

        public MouseScrollArgs(MouseArgs e, int delta) : this(e.X, e.Y, delta)
        {
        }
    }
}
