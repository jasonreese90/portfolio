using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory;
using Kunihiro.Memory.SigScan;

namespace Kunihiro.FFXi
{
    
    public class NPC
    {
        private PolProcess proc;
        private IntPtr npcmapAddress;

        public NPC(int pid)
        {
            proc = new PolProcess(pid);

            SignatureScan ss = new SignatureScan(proc.Process, proc.FFXiMain);
            npcmapAddress = ss.FindSignature(Signatures.NPCMAP_SIGNATURE);
        }

        public NPCStruct Read(int id)
        {
            return MemTools.ReadProcessMemory<NPCStruct>(proc.Handle,NPCPointer(id));
        }



        public IntPtr NPCPointer(int id)
        {
            IntPtr dwNpcObj;
            int dwNpcPtr = (int)npcmapAddress + (id * 4);
            dwNpcObj = (IntPtr)MemTools.ReadProcessMemory<int>(proc.Handle, (IntPtr)dwNpcPtr);
            return dwNpcObj;
        }
    }
}
