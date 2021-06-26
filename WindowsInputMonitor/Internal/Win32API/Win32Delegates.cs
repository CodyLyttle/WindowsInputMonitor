using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInputMonitor.Win32API
{
    /// <summary>
    /// Maps to the win32 callback function - HOOKPROC.
    /// <br/>
    /// <a href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-hookproc"></a>
    /// </summary>
    public delegate IntPtr CallbackFunction(int code, UIntPtr wParam, IntPtr lParam);
}
