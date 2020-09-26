using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.FFXi;
using Kunihiro.Memory;
using Kunihiro.Memory.SigScan;

namespace Kunihiro.FFXi
{
  public class Entity
  {
       private PolProcess proc;
       private IntPtr npcmapAddress;

        public Entity(int pid)
        {
            proc = new PolProcess(pid);

            SignatureScan ss = new SignatureScan(proc.Process, proc.FFXiMain);
            npcmapAddress = ss.FindSignature(Signatures.NPCMAP_SIGNATURE);
        }

        public EntityStruct ReadEntity(int id)
        {
            return MemTools.ReadProcessMemory<EntityStruct>(proc.Handle, (IntPtr)((int)npcmapAddress + (id * 4)));
        }

  }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        private byte[] Reserved1;
        public int Id;
        public int ServerId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] Reserved2;
        public IntPtr Struct2Address;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
        private byte[] Reserved3;
        public float Distance;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 69)]
        private byte[] Reserved4;
        public RenderFlagsType1 RenderFlags1;
        public RenderFlagsType2 RenderFlags2;
        public RenderFlagsType3 RenderFlags3;
        public RenderFlagsType4 RenderFlags4;
        public RenderFlagsType5 RenderFlags5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        private byte[] Reserved5;
        public EntityStatus Status;
        public EntityStatus Status2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
        private byte[] Reserved6;
        public EntityType Type;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct EntityStruct2
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
        private byte[] Reserved1;
        public Coordinate Position;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] Reserved2;
        public float Rotation;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Coordinate
    {
        public float X;
        public float Y;
        public float Z;

        public Coordinate(float x, float y, float z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    public enum EntityStatus
    {
        Idle = 0,
        Engaged = 1,
        DeadIdle = 2,
        DeadEngaged = 3,
        Event = 4,
        Chocobo = 5,
        DoorOpened = 8,
        DoorClosed = 9,
        Resting = 33,
        Crafting = 44,
        Sitting = 47,
        FishingIdle = 56,
        FishingBite = 57,
        FishingCaughtFish = 58,
        FishingRodBreak = 59,
        FishingLineSnap = 60,
        FishingCaughtMonster = 61,
        FishingCancel = 62
    }

    [Flags]
    public enum EntityType : byte
    {
        None = 0,
        PC = 1,
        NPC = 2,
        PartyMember = 4,
        AllianceMember = 8,
        Enemy = 16,
        Door = 32
    }

    [Flags]
    public enum RenderFlagsType1 : uint //Bitwise
    {
        //MovementLock = 128 one byte below now
        //Block1
        ModelBlinkDisable = 0x00000001,
        Spawned = 0x00000002, //Spawned/Rendering
        Bit03 = 0x00000004,
        Bit04 = 0x00000008,
        Bit05 = 0x00000010,
        IsAttackable = 0x00000020,
        ModelHideServer = 0x00000040,
        ModelHideClient = 0x00000080,
        //Block2
        Bit09 = 0x00000100,
        Bit10 = 0x00000200,
        Bit11 = 0x00000400,
        Bit12 = 0x00000800,
        Bit13 = 0x00001000,
        Bit14 = 0x00002000,
        Bit15 = 0x00004000,
        Bit16 = 0x00008000,
        //Block3
        Bit17 = 0x00010000,
        Bit18 = 0x00020000,
        Bit19 = 0x00040000,
        Bit20 = 0x00080000,
        Bit21 = 0x00100000,
        Bit22 = 0x00200000,
        Bit23 = 0x00400000,
        Bit24 = 0x00800000,
        //Block4
        Bit25 = 0x01000000,
        Bit26 = 0x02000000,
        Bit27 = 0x04000000,
        Bit28 = 0x08000000,
        Bit29 = 0x10000000,
        Bit30 = 0x20000000,
        Bit31 = 0x40000000,
        Bit32 = 0x80000000,
    }

    [Flags]
    public enum RenderFlagsType2 : uint //Bitwise
    {
        //Block1
        Bit01 = 0x00000001,
        Bit02 = 0x00000002,
        Bit03 = 0x00000004,
        Loaded = 0x00000008,
        Unloaded = 0x00000010,
        Bit06 = 0x00000020,
        Bit07 = 0x00000040,
        Bit08 = 0x00000080,
        /* 1 = ?
         * 2 = ?
         * 4 = ?
         * 8 = Spawned/Visible
         * 16 = Invisible/Unspawned
         * 32 = ?
         * 64 = Disable Setting New Idle Animations
         * 128 = ? (Unsets if set)
        */
        //Block2
        Bit09 = 0x00000100,
        Bit10 = 0x00000200,
        Bit11 = 0x00000400,
        Bit12 = 0x00000800,
        SeekParty = 0x00001000,
        Autogroup = 0x00002000,
        Away = 0x00004000,
        Anon = 0x00008000,
        //Block3
        CallForHelp = 0x00010000,
        Bit18 = 0x00020000,
        TemporaryLogout = 0x00040000,
        Linkshell = 0x00080000,
        Disconnecting = 0x00100000,
        Bit22 = 0x00200000,
        Bit23 = 0x00400000,
        Bit24 = 0x00800000,
        //Block4
        MovementSoundEnable = 0x01000000,
        Bit26 = 0x02000000,
        Bit27 = 0x04000000,
        NameAndHPPHide = 0x08000000,
        TargetableDisable = 0x10000000,
        Bit30 = 0x20000000,
        ModelInvisibleSpellClient = 0x40000000,
        ModelInvisibleSpellServer = 0x80000000,
    }

    [Flags]
    public enum RenderFlagsType3 : uint //Bitwise
    {
        //Block1
        ModelSneakSpell = 0x00000001,
        Bazaar = 0x00000002,
        Bit03 = 0x00000004,
        SeniorGM = 0x00000008, //Requires Support GM Flag
        LeadGM = 0x00000010, //Requires Support GM Flag
        SupportGM = 0x00000020, //Senior + Lead = PlayOnline; Senior + Lead + Support = Producer
        WallClippingEnable = 0x00000040,
        MovementLock = 0x00000080,
        //Block2
        Bit09 = 0x00000100,
        Bit10 = 0x00000200,
        Bit11 = 0x00000400,
        Bit12 = 0x00000800,
        Bit13 = 0x00001000,
        Bit14 = 0x00002000,
        Bit15 = 0x00004000,
        Bit16 = 0x00008000,
        //Block3
        Bit17 = 0x00010000,
        Bit18 = 0x00020000,
        Bit19 = 0x00040000,
        Bit20 = 0x00080000,
        Bit21 = 0x00100000,
        Bit22 = 0x00200000,
        Bit23 = 0x00400000,
        Bit24 = 0x00800000,
        //Block4
        ModelBlink = 0x01000000,
        Bit26 = 0x02000000,
        Bit27 = 0x04000000,
        Bit28 = 0x08000000,
        Bit29 = 0x10000000,
        Bit30 = 0x20000000,
        Bit31 = 0x40000000,
        Bit32 = 0x80000000,
    }

    [Flags]
    public enum RenderFlagsType4 : uint //Bitwise
    {
        //Block1
        Bit01 = 0x00000001,
        Bit02 = 0x00000002,
        Bit03 = 0x00000004,
        Bit04 = 0x00000008,
        Bit05 = 0x00000010,
        IsCharmed = 0x00000020,
        Bit07 = 0x00000040,
        Bit08 = 0x00000080,
        //Block2
        Bit09 = 0x00000100,
        Bit10 = 0x00000200,
        Bit11 = 0x00000400,
        Bit12 = 0x00000800,
        Bit13 = 0x00001000,
        Bit14 = 0x00002000,
        Bit15 = 0x00004000,
        Bit16 = 0x00008000,
        //Block3
        Bit17 = 0x00010000,
        Bit18 = 0x00020000,
        Bit19 = 0x00040000,
        IgnoreClaim = 0x00080000, //Allows attacking claimed mobs - Besieged, Campaign Battles, etc
        ClaimedByParty = 0x00100000,
        Bit22 = 0x00200000,
        Bit23 = 0x00400000,
        Bit24 = 0x00800000,
        //Block4
        Bit25 = 0x01000000,
        Bit26 = 0x02000000,
        Bit27 = 0x04000000,
        Bit28 = 0x08000000,
        Bit29 = 0x10000000,
        Bit30 = 0x20000000,
        Bit31 = 0x40000000,
        NameHide = 0x80000000,
    }

    [Flags]
    public enum RenderFlagsType5 : uint //Bitwise
    {
        //Block1
        Bit01 = 0x00000001,
        Bit02 = 0x00000002,
        Bit03 = 0x00000004,
        Bit04 = 0x00000008,
        Mentor = 0x00000010,
        NewAdventurer = 0x00000020,
        TrialAdventurer = 0x00000040,
        Bit08 = 0x00000080,
        //Block2
        Bit09 = 0x00000100,
        Bit10 = 0x00000200,
        ModelTransparent = 0x00000400,
        Bit12 = 0x00000800,
        Bit13 = 0x00001000,
        Bit14 = 0x00002000,
        Bit15 = 0x00004000,
        LevelSync = 0x00008000,
        //Block3
        Bit17 = 0x00010000,
        Bit18 = 0x00020000,
        Bit19 = 0x00040000,
        Bit20 = 0x00080000,
        Bit21 = 0x00100000,
        Bit22 = 0x00200000,
        Bit23 = 0x00400000,
        Bit24 = 0x00800000,
        //Block4
        Bit25 = 0x01000000,
        Bit26 = 0x02000000,
        Bit27 = 0x04000000,
        Bit28 = 0x08000000,
        Bit29 = 0x10000000,
        Bit30 = 0x20000000,
        Bit31 = 0x40000000,
        Bit32 = 0x80000000,
    }

    public enum PVPFlag
    {
        None = 1,
        San_dOria = 2,
        Bastok = 3,
        Windurst = 4,
        Wyverns = 5,
        Griffons = 6,
        ScoreBoard = 7,
        Gladiator1 = 8,
        Gladiator2 = 9,
        PankrationRed = 32,
        PankrationBlue = 33
    }
}
