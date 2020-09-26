using Kunihiro.Memory.SigScan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory;

namespace Kunihiro.XIV
{
    public class Player
    {
        private XIVProcess _process;
        private SignatureScan _scan;
        public IntPtr _playerPtr;

        public Player(XIVProcess proc)
        {
            _process = proc;
            _scan = new SignatureScan(proc, proc.MainModule);

            _playerPtr = _scan.FindRelativeSignature("48894648488D4E60488D15");
        }

        private string GetName()
        {
            return MemTools.ReadString(_process.Handle, _playerPtr, 64);
        }

        public string Name
        {
            get
            {
                return GetName();
            }
        }
    }
}
