using System;
using System.Drawing;

namespace WindowsInputMonitor
{
    public class MouseButtonArgs : MouseArgs
    {
        public MouseButton Button { get; }

        public MouseButtonArgs(int x, int y, MouseButton button) : base(x, y)
        {
            Button = button;
        }

        public MouseButtonArgs(MouseArgs e, MouseButton button) : this(e.X, e.Y, button)
        {
        }
    }
}
