using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory;
using Kunihiro.Memory.SigScan;

namespace Kunihiro.FFXi
{
    public class Player
    {
        private PolProcess proc;
        private IntPtr playerAddress;
        private IntPtr zoneAddress;
        private IntPtr selfidAddress;
        private IntPtr buffAddress;
     
        private PlayerStruct player;
   
        private NPC npc;

        public Player(int pid)
        {
            proc = new PolProcess(pid);
            SignatureScan ss = new SignatureScan(proc.Process, proc.FFXiMain);
            playerAddress = ss.FindSignature(Signatures.PLAYER_SIGNATURE);
            zoneAddress = ss.FindSignature(Signatures.ZONE_SIGNATURE) + 0x5E;
            selfidAddress = ss.FindSignature(Signatures.SELFID_SIGNATURE);
            buffAddress = ss.FindSignature(Signatures.BUFF_SIGNATURE);

            npc = new NPC(pid);
        }

        private void ReadPlayer()
        {
            player = MemTools.ReadProcessMemory<PlayerStruct>(proc.Handle, playerAddress);
            
        }

        private Status GetPlayerStatus()
        {
            int status = MemTools.ReadProcessMemory<int>(proc.Handle, (IntPtr)((int)proc.BaseAddress + 0x5DB140));
            return (Status)status;
        }

        public Status Status
        {
            get
            {
                return GetPlayerStatus();
            }
        }

        public int ZoneID
        {
            get
            {
                return MemTools.ReadProcessMemory<int>(proc.Handle, zoneAddress);
            }
        }

        public Job MainJob
        {
            get
            {
                ReadPlayer(); return (Job)player.JobInfo.MainJobID;
            }
        }

        public byte MainJobLevel
        {
            get
            {
                ReadPlayer(); return player.JobInfo.MainJobLevel;
            }
        }

        public Job SubJob
        {
            get
            {
                ReadPlayer(); return (Job)player.JobInfo.SubJobID;
            }
        }

        public byte SubJobLevel
        {
            get
            {
                ReadPlayer(); return player.JobInfo.SubJobLevel;
            }
        }

        public int ID
        {
            get
            {
                return MemTools.ReadProcessMemory<short>(proc.Handle, (IntPtr)selfidAddress);
            }
        }   

        public float PosX
        {
            get
            {
                return npc.Read(ID).X;
            }
        }


        public float PosY
        {
            get
            {
                return npc.Read(ID).Y;
            }
        }

        public float PosZ
        {
            get
            {
                return npc.Read(ID).Z;
            }
        }
        public float Rotation
        {
            get
            {
                return npc.Read(ID).Rotation;
            }
        }

        public string Name
        {
            get
            {
                return npc.Read(ID).Name;
            }
        }

        public Buff[] GetBuffs()
        {
            return MemTools.ReadProcessMemory<StatusEffectStruct>(proc.Handle, buffAddress).StatusEffects;
        }

        public int GetActiveBuffCount(Buff buff)
        {
            Buff[] buffs = GetBuffs();

            int count = 0;

            foreach(Buff b in buffs)
            {
                if(b == buff)
                {
                    count++;
                }
            }

            return count;
        }

       
    }

    public enum Status : byte
    {
        Standing = 0,
        Fighting = 1,
        Dead1 = 2,
        Dead2 = 3,
        Event = 4,
        Chocobo = 5,
        Fishing = 56,
        Healing = 33,
        FishBite = 57,
        Obtained = 58,
        RodBreak = 40,
        LineBreak = 41,
        LostCatch = 43,
        CatchMonster = 42,
        Synthing = 44,
        Sitting = 47
    }

    public enum Job : byte
    {
        NA = 0,
        WAR = 1,
        MNK = 2,
        WHM = 3,
        BLM = 4,
        RDM = 5,
        THF = 6,
        PLD = 7,
        DRK = 8,
        BST = 9,
        BRD = 10,
        RNG = 11,
        SAM = 12,
        NIN = 13,
        DRG = 14,
        SMN = 15,
        BLU = 16,
        COR = 17,
        PUP = 18,
        DNC = 19,
        SCH = 20
    }
}
