using System;
using System.Runtime.InteropServices;
using WindowsInputMonitor.Win32;

namespace WindowsInputMonitor.Monitoring
{
    internal class GlobalMouseMonitor : InputMonitor, IMouseHook
    {
        public event EventHandler<MouseArgs> Move;
        public event EventHandler<MouseScrollArgs> Scroll;
        public event EventHandler<MouseButtonArgs> Click;
        public event EventHandler<MouseButtonArgs> Down;
        public event EventHandler<MouseButtonArgs> Up;

        public GlobalMouseMonitor() : base(HookType.WH_MOUSE_LL)
        {
        }

        protected override void ParseCallbackData(UIntPtr messageCode, IntPtr structPtr)
        {
            MouseMessage message = (MouseMessage)messageCode.ToUInt32();
            MouseStruct structData = Marshal.PtrToStructure<MouseStruct>(structPtr);

            MouseArgs args = new(
                structData.Position.X,
                structData.Position.Y);

            MouseAction action = message.ToMouseAction();
            switch (action)
            {
                case MouseAction.Move:
                    Move?.Invoke(this, args);
                    break;
                case MouseAction.Scroll:
                    SendMouseScrollEvent(args, structData.MouseData);
                    break;
                case MouseAction.Down:
                case MouseAction.Up:
                    SendMouseButtonEvent(args, message.ToMouseButton(), action);
                    break;
                case MouseAction.Ignore:
                    break;
            }
        }

        private void SendMouseButtonEvent(MouseArgs e, MouseButton button, MouseAction action)
        {
            MouseButtonArgs args = new(e, button);
            if (action == MouseAction.Down)
            {
                Down?.Invoke(this, args);
            }
            else if (action == MouseAction.Up)
            {
                Up?.Invoke(this, args);
                Click?.Invoke(this, args);
            }
            else throw new ArgumentException($"Unexpected {nameof(MouseAction)} in {nameof(SendMouseButtonEvent)}");
        }

        private void SendMouseScrollEvent(MouseArgs e, short delta)
        {
            MouseScrollArgs args = new(e, delta);
            Scroll.Invoke(this, args);
        }
    }
}
