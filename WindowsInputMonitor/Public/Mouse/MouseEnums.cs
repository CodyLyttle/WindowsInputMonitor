using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInputMonitor
{
    public enum MouseButton
    {
        None,
        Left,
        Right,
        Middle,
    }

    public enum ScrollDirection
    {
        Down,
        Up
    }

    internal enum MouseAction
    {
        Down,
        Up,
        Move,
        Scroll,
        Ignore
    }
}
