using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Kunihiro.XIV
{
    public class Input
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private XIVProcess _process;

        public Input(XIVProcess proc)
        {
            _process = proc;
        }

        public void SendKeyStroke(Keys key)
        {
            PostMessage(_process.hWnd, 0x100, (IntPtr)key, (IntPtr)0x30001);
            Thread.Sleep(100);
            PostMessage(_process.hWnd, 0x102, (IntPtr)key, (IntPtr)0x30001);
            Thread.Sleep(100);
            PostMessage(_process.hWnd, 0x101, (IntPtr)key, (IntPtr)0x30001);
        }
    }
}
