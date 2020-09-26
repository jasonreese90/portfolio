using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory.SigScan;
using Kunihiro.Memory;

namespace Kunihiro.XIV
{
    public class Fish
    {
        private XIVProcess _process;
        private SignatureScan _scan;
        private IntPtr _fishPtr;

        public FishingStatus Status
        {
            get
            {
                return GetStatus();
            }
        }

        public Fish(XIVProcess proc)
        {
            _process = proc;
            _scan = new SignatureScan(proc, proc.MainModule);

            _fishPtr = _scan.FindRelativeSignature("488D8E70FDFFFF4C8B114C8D0D");
        }

        private FishingStatus GetStatus()
        {
            if (_fishPtr != IntPtr.Zero)
            {
                byte b = MemTools.ReadProcessMemory<byte>(_process.Handle, _fishPtr);
                return (FishingStatus)b;
            }

            return FishingStatus.Error;
        }

        


    }
}
