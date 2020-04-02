using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public static class ControlsExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            if (control != null && control.InvokeRequired)
                control.Invoke((MethodInvoker)delegate { action?.Invoke(); });
            else
                action?.Invoke();
        }
        public static void Invoke<T>(this T control, Action<T> action) where T : Control
        {
            if (control != null && control.InvokeRequired)
                control.Invoke((MethodInvoker)delegate { action?.Invoke(control); });
            else
                action?.Invoke(control);
        }
    }
}
