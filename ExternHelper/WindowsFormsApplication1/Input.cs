using Kunihiro.ExternHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Input : ExternHelper
    {
        private struct Targets
        {
            public int id;
        }
        public Input(Process process) : base(process)
        {

        }

        [ExternFunction(CallingConvention = CallingConvention.Thiscall, Module = "FFXiMain.dll", Offset = 0x14CE60)]
        public void Target(IntPtr targetStruct, IntPtr entityStruct2, bool unknown1, bool unknown2)
        {
            this.CallFunction(targetStruct, entityStruct2, unknown1, unknown2);
        }

        [ExternFunction(CallingConvention = CallingConvention.Cdecl, Module = "FFXiMain.dll", Offset = 0x14E28A)]
        public void Interact(IntPtr target)
        {
            //Targets t = new Targets();
            //t.id = target;
            byte z = 0;
            base.CallFunction(target,z,z,z,z);
        }

        [ExternFunction(CallingConvention = CallingConvention.Cdecl, Module = "FFXiMain.dll", Offset = 0x7E970)]
        public void SendString(string text)
        {
            base.CallFunction(text, 1);
        }
    }
}
