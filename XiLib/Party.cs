using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kunihiro.Memory;
using Kunihiro.Memory.SigScan;

namespace Kunihiro.FFXi
{
    public class Party
    {
        private PolProcess proc;
        public IntPtr partyAddress;

        public Party(int pid)
        {
            proc = new PolProcess(pid);

            SignatureScan ss = new SignatureScan(proc.Process, proc.FFXiMain);
            partyAddress = ss.FindSignature(Signatures.PARTY_SIGNATURE);
        }

        private PartyStruct ReadParty()
        {
            return MemTools.ReadProcessMemory<PartyStruct>(proc.Handle, partyAddress);
        }

        public PartyMemberStruct[] GetPartyMembers()
        {
            return ReadParty().PartyMembers;
        }

        public PartyInfoStruct GetPartyInfo()
        {
            return MemTools.ReadProcessMemory<PartyInfoStruct>(proc.Handle, ReadParty().PartyMembers[0].PartyInfoPointer);
        }
    }
}
