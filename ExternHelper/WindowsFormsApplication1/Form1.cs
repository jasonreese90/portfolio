using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
           uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll")]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress,
           int dwSize, MemoryProtection flNewProtect, out uint lpflOldProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            int zero);

        Process pol;
        Process con;
        Input h;
        IntPtr addr;
        Test t;

        public Form1()
        {
            InitializeComponent();
           con = Process.GetProcessesByName("ConsoleApplication3")[0];
           t = new Test(con);
            //pol = Process.GetProcessesByName("pol")[0];
            //h = new Input(pol);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //uint u;
            //VirtualProtectEx(pol.Handle, pol.MainModule.BaseAddress, pol.MainModule.ModuleMemorySize, MemoryProtection.ReadWrite, out u);
            //addr = VirtualAllocEx(pol.Handle, pol.MainModule.BaseAddress,64, AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            //WriteProcessMemory(pol.Handle, addr, BitConverter.GetBytes(0x1C), 4, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //t.MethodTest(new IntPtr((int)con.MainModule.BaseAddress+0x305B8));
            t.Print(textBox1.Text);
            //t.MethodTest(5);
           // h.Interact((IntPtr)0x130C75A8);
            //h.SendString(textBox1.Text);
            //Test.TestStruct tt = new Test.TestStruct();
            //tt.a = 55;
            //tt.b = 342352235;
            //tt.c = "absfgetwetwetsdgwektnmgskdmgnwiejtset";
            //tt.d = 235235.3f;
            //tt.e = "dsasdasdasd";
            //tt.f =235235235235235;

            
        }
    }
}
