using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInputMonitor
{
    public interface IMouseHook : IDisposable
    {
        public event EventHandler<MouseArgs> Move;
        public event EventHandler<MouseScrollArgs> Scroll;
        public event EventHandler<MouseButtonArgs> Click;
        public event EventHandler<MouseButtonArgs> Down;
        public event EventHandler<MouseButtonArgs> Up;
    }
}
