using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windower;

namespace Kunihiro.FFXi
{
    public class NaHookHelper
    {
        private Process ffxi;

        public NaHookHelper(int pid)
        {
            this.ffxi = Process.GetProcessById(pid);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Command
        {


            [MarshalAs(UnmanagedType.I1)]
            public byte id;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] data;
        }

        private byte[] GetBytes(Command t)
        {
            byte[] buffer = new byte[260];

            Buffer.BlockCopy(new byte[] { t.id }, 0, buffer, 0, 1);
            Buffer.BlockCopy(t.data, 0, buffer, 1, t.data.Length);

            return buffer;
        }


        public void SendString(string text)
        {
            using (NamedPipeClientStream npc = new NamedPipeClientStream(".", "NaHook_" + ffxi.Id, PipeDirection.Out))
            {
                using (BinaryWriter sw = new BinaryWriter(npc))
                {
                    npc.Connect();
                    Command t = new Command();
                    t.id = 0;
                    t.data = Encoding.ASCII.GetBytes(text);
              
                    sw.Write(GetBytes(t));
                }
            }
        }

        public void SetKey(Keys key, bool down)
        {
            using (NamedPipeClientStream npc = new NamedPipeClientStream(".", "NaHook_" + ffxi.Id, PipeDirection.Out))
            {
                using (BinaryWriter sw = new BinaryWriter(npc))
                {
                    npc.Connect();
                    Command t = new Command();
                    t.id = 1;
                    t.data = new byte[256];
                    t.data[0] = (byte)key;
                    t.data[1] = Convert.ToByte(down);

                    sw.Write(GetBytes(t));
                }
            }
        }

        public void SendKey(Keys key)
        {
            SetKey(key, true);
            Thread.Sleep(100);
            SetKey(key, false);
        }
    }
}
