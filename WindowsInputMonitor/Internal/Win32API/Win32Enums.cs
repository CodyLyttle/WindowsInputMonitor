using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInputMonitor.Win32API
{
    internal enum HookType
    {
        WH_MOUSE_LL = 14,
        WH_KEYBOARD_LL = 13
    }

    internal enum MouseMessage
    {
        /// <summary> On cursor move. </summary>
        WM_MOUSEMOVE = 0x200,

        /// <summary> On left button down. </summary>
        WM_LBUTTONDOWN = 0x201,

        /// <summary> On right button down. </summary>
        WM_RBUTTONDOWN = 0x204,

        /// <summary> On middle button down. </summary>
        WM_MBUTTONDOWN = 0x207,

        /// <summary> On left button up. </summary>
        WM_LBUTTONUP = 0x202,

        /// <summary> On right button up. </summary>
        WM_RBUTTONUP = 0x205,

        /// <summary> On middle button up. </summary>
        WM_MBUTTONUP = 0x208,

        ///<summary> On vertical scroll. </summary>
        WM_MOUSEWHEEL = 0x020A,

        // The following messages are not implemented
        // - WM_LBUTTONDBLCLK = 0x203,
        // - WM_RBUTTONDBLCLK = 0x206,
        // - WM_MBUTTONDBLCLK = 0x209,
        // - WM_XBUTTONDOWN = 0x20B,
        // - WM_XBUTTONUP = 0x20C,
        // - WM_XBUTTONDBLCLK = 0x20D,
        // - WM_MOUSEHWHEEL = 0x20E
    }

    internal enum KeyboardMessage
    {
        /// <summary> On keyboard key down. </summary>
        WM_KEYDOWN = 0x100,

        /// <summary> On keyboard key up. </summary>
        WM_KEYUP = 0x101,

        /// <summary> On keyboard key down while the Alt key modifier is active. </summary>
        WM_SYSKEYDOWN = 0x104,

        /// <summary> On keyboard key up while the Alt key modifier is active. </summary>
        WM_SYSKEYUP = 0x105
    }
}
