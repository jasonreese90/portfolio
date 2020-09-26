using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Kunihiro.Memory.SigScan;
using System.Runtime.InteropServices;
using Kunihiro.FixedStruct;
using System.Text.RegularExpressions;

namespace FixedStructTest
{
    public partial class Form1 : Form
    {
        private Process pol;
        private IntPtr npcmap;
        private SignatureScan sigscan;

        public Form1()
        {
            pol = Process.GetProcessesByName("pol")[0];

            sigscan = new SignatureScan(pol, "FFXiMain.dll");

            npcmap = sigscan.FindSignature("8B560C8B042A8B0485");

            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 2000;i++)
            {
                Entity entity = FixedStruct.ReadStruct<Entity>(pol.Handle, Pointer(i));
                string name = Regex.Replace(entity.name, @"[^\w\.@-]", "");

                if (entity.id != 0)
                    listBox1.Items.Add(entity.id.ToString("X") + " " + entity.serverId.ToString("X") + " " + name + "  Bazaar:" +
                        entity.hasBazaar.ToString());
            }
            
        }

        public IntPtr Pointer(int id)
        {
            int npcPtr = (int)npcmap + (id * 4);
            byte[] buffer = new byte[4];

            ReadProcessMemory(pol.Handle, (IntPtr)npcPtr, buffer, 0x04, 0);
            return (IntPtr)BitConverter.ToInt32(buffer, 0);
        }

        [DllImport("kernel32")]
        static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, byte[] buffer, int size, int zero);
    }

}
