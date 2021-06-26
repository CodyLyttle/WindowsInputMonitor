using System;
using System.Drawing;

namespace WindowsInputMonitor
{
    public class MouseArgs : EventArgs
    {
        public int X { get; }
        public int Y { get; }
        public Point Location { get; }

        public MouseArgs(int x, int y)
        {
            X = x;
            Y = y;
            Location = new Point(x, y);
        }
    }
}
