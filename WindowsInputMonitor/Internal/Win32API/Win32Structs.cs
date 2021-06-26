using System;
using System.Runtime.InteropServices;

namespace WindowsInputMonitor.Win32API
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MouseStruct
    {
        [FieldOffset(0x00)]
        public POINT Position;

        [FieldOffset(0x0A)]
        public short MouseData;

        [FieldOffset(0x10)]
        public int Timestamp;

        public MouseStruct(POINT pos, short data)
        {
            Position = pos;
            MouseData = data;
            Timestamp = Environment.TickCount;
        }
    }
}
