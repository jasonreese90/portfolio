using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.FFXi
{
    public struct ChatLogStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public short[] NewChatLogOffsets;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public short[] OldChatLogOffsets;

        public byte NumberOfLines;
        public IntPtr NewChatLogPtr;
        public IntPtr OldChatLogPtr;
        public int ChatLogBytes;
        public short FinalOffset;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct StatusEffectStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Buff[] StatusEffects;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct PartyInfoStruct
    {
        public UInt32 AllianceLeaderServerID;
        public UInt32 Party1LeaderServerID;
        public UInt32 Party2LeaderServerID;
        public UInt32 Party3LeaderServerID;
        public byte Party1Exists; //0 = Exists, 15 = Not Exists
        public byte Party2Exists; //1 = Exists, 15 = Not Exists
        public byte Party3Exists; //2 = Exists, 15 = Not Exists
        public byte Party1MemberCount;
        public byte Party2MemberCount;
        public byte Party3MemberCount;
        public byte Invited; //1 when invited to party
        private byte Unknown;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PartyMemberStruct
    {
        internal IntPtr PartyInfoPointer;
        public byte Index;
        public byte MemberNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        private byte[] name;
        public UInt32 ServerID;
        public UInt32 ID;
        private UInt32 Unknown3;
        public UInt32 HP;
        public UInt32 MP;
        public UInt32 TP;
        public byte HPP;
        public byte MPP;
        public UInt16 ZoneID;
        public UInt16 ZoneNameToggle;
        private UInt16 Unknown4;
        public UInt32 Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        private byte[] Unknown5;
        public UInt32 ServerID2;
        public byte HPP2;
        public byte MPP2;
        public byte Exists;
        private byte Unknown6;

        public string Name
        {
            get
            {
                string n= Encoding.ASCII.GetString(name);
                int start = n.IndexOf((char)0);
                return n.Substring(0, start);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PartyStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public PartyMemberStruct[] PartyMembers;
    }

    public struct Fishs
    {
        internal int MaxHP;
        internal int HP;
        internal int unknown0;
        internal int ID3;
        internal int unk;
        internal int ID1;
        internal int ID2;
        internal int ID4;
        internal int timeout;
        internal int unknown1;
        internal int unknown2;
        internal int unk1;
        internal int rodPos;
    }

    //public struct Fishs
    //{
    //    internal int MaxHP;
    //    internal int HP;
    //    internal int ID3;
    //    internal int unknown0;
    //    internal int ID1;
    //    internal int ID2;
    //    internal int ID4;
    //    internal int unk;
    //    internal int timeout;
    //    internal int unknown1;
    //    internal int unknown2;
    //    internal int unk1;
    //    internal int rodPos;
    //}

    //public struct FishStruct
    //{
    //    public UInt32 MaxHP;
    //    public UInt32 HP;
    //    public UInt32 HPDisplay;
    //    public UInt32 RodMovementFrequency;
    //    public UInt32 FishRegenRate;
    //    public UInt32 RodMiddleDuration;
    //    public UInt32 FishHPDepletionRate;
    //    public UInt32 FishRecoveryRate;
    //    public UInt32 TimeRemaining;
    //    public UInt32 TimeoutMessage; //Bool -- 1 = message given
    //    public UInt32 UsableItem; //For Item Message, 0 = Usable, = 1 Not
    //    public UInt32 AnglerMessage; //Keen Angler Sense Message
    //    public Int32 RodPosition;
    //    private UInt32 Unknown; //Counts down as arrows are displayed
    //}
    public struct FishingInfo
    {
        internal int rodPos;
        internal int one;
        internal int two;
        internal int unknown0;
        internal int unknown1;
        internal int unknown2;
        internal int unknown3;
        internal int unknownPtr;
        internal int fishPtr;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct PlayerStruct
    {
        public Int32 MaxHP;
        public Int32 MaxMP;
        public JobInfoStruct JobInfo;
        public UInt16 ExpCurrent;
        public UInt16 ExpNext;
        public AttributesBaseStruct Attributes;
        public AttributesAdditionalStruct AttributesAdditional;
        public Int16 Attack;
        public Int16 Defense;
        public ResistancesStruct Resistances;
        public UInt16 TitleID;
        public UInt16 Rank;
        public UInt16 RankPoints;
        public byte NationID;
        public byte ResidenceID;
        public byte SuperiorLevel;
        private byte Unknown1;
        //public UInt16 HomepointZoneID; //Seems to have been replaced?
        private UInt16 Unknown2;
        public CombatSkillStruct CombatSkills;
        public MagicSkillStruct MagicSkills;
        public CraftingSkillStruct CraftingSkills;
        private UInt16 Unknown3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct PlayerStruct2
    {
        private UInt32 Unknown1;
        public byte MainJob;
        private byte Unknown2;
        private byte Unknown3;
        public byte SubJob;
        public UInt32 JobsDisplayed; //Bit/Flags
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Jobs1; //Up to Zilart
        public AttributesBaseStruct Attributes;
        public AttributesAdditionalStruct AttributesAdditional;
        public Int32 MaxHP;
        public Int32 MaxMP;
        private UInt32 Unknown4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Jobs1Duplicate; //Up to Zilart
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Jobs2; //Aht Urhgan to Adoulin
        public UInt32 LastZonedEpoch;
        public byte IsLoaded;
        private byte Unknown5;
        private byte Unknown6;
        private byte Unknown7;
        private UInt32 Unknown8;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct JobInfoStruct
    {
        public byte MainJobID;
        public byte MainJobLevel;
        public byte SubJobID;
        public byte SubJobLevel;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct AttributesBaseStruct
    {
        public UInt16 STR;
        public UInt16 DEX;
        public UInt16 VIT;
        public UInt16 AGI;
        public UInt16 INT;
        public UInt16 MND;
        public UInt16 CHR;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct AttributesAdditionalStruct
    {
        public Int16 STR;
        public Int16 DEX;
        public Int16 VIT;
        public Int16 AGI;
        public Int16 INT;
        public Int16 MND;
        public Int16 CHR;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ResistancesStruct
    {
        public Int16 Fire;
        public Int16 Ice;
        public Int16 Wind;
        public Int16 Earth;
        public Int16 Lightning;
        public Int16 Water;
        public Int16 Light;
        public Int16 Dark;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct CombatSkillStruct
    {
        public UInt16 HandToHand;
        public UInt16 Dagger;
        public UInt16 Sword;
        public UInt16 GreatSword;
        public UInt16 Axe;
        public UInt16 GreatAxe;
        public UInt16 Scythe;
        public UInt16 Polearm;
        public UInt16 Katana;
        public UInt16 GreatKatana;
        public UInt16 Club;
        public UInt16 Staff;
        public UInt16 Unused1;
        public UInt16 Unused2;
        public UInt16 Unused3;
        public UInt16 Unused4;
        public UInt16 Unused5;
        public UInt16 Unused6;
        public UInt16 Unused7;
        public UInt16 Unused8;
        public UInt16 Unused9;
        public UInt16 Unused10;
        public UInt16 Unused11;
        public UInt16 Unused12;
        public UInt16 Archery;
        public UInt16 Marksmanship;
        public UInt16 Throwing;
        public UInt16 Guarding;
        public UInt16 Evasion;
        public UInt16 Shield;
        public UInt16 Parrying;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MeritJobPointsStruct
    {
        private UInt32 Unknown1;
        private UInt32 Unknown2;
        private UInt32 Unknown3;
        private UInt32 Unknown4;
        private UInt32 LastOpened;
        public byte StatusMenuFlags;
        private byte Unknown5;
        public ushort LimitPoints;
        public byte MeritPoints; //0-127, 128 - 255 = 0-127
        public byte MeritFlags;
        public byte MaxMeritPoints;
        private byte Unknown6;
        private UInt32 Unknown7;
        private UInt32 Unknown8;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public JobPointStruct[] JobPoints;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct JobPointStruct
    {
        public ushort CapacityPoints;
        public ushort JobPoints;
        public ushort JobPointsSpent;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MagicSkillStruct
    {
        public UInt16 Divine;
        public UInt16 Healing;
        public UInt16 Enhancing;
        public UInt16 Enfeebling;
        public UInt16 Elemental;
        public UInt16 Dark;
        public UInt16 Summon;
        public UInt16 Ninjutsu;
        public UInt16 Singing;
        public UInt16 String;
        public UInt16 Wind;
        public UInt16 BlueMagic;
        public UInt16 Geomancy;
        public UInt16 Handbell;
        public UInt16 Unused1;
        public UInt16 Unused2;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct CraftingSkillStruct
    {
        public UInt16 Fishing;
        public UInt16 Woodworking;
        public UInt16 Smithing;
        public UInt16 Goldsmithing;
        public UInt16 Clothcraft;
        public UInt16 Leathercraft;
        public UInt16 Bonecraft;
        public UInt16 Alchemy;
        public UInt16 Cooking;
        public UInt16 Synergy;
        public UInt16 Riding;
        public UInt16 Unused1;
        public UInt16 Unused2;
        public UInt16 Unused3;
        public UInt16 Unused4;
    }


    public struct NPCStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] unk0;
        public float X;
        public float Z;
        public float Y;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] unk1;
        public float Rotation;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        byte[] unk2;
        public int ID;
        public int ServerID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 53)]
        byte[] unk3;

        byte unk4;
        public byte Type;
        public byte Race;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        byte[] unk5;
        public byte HPP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        byte[] u;
        public byte Drawn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        byte[] unk6;
        public byte Flag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        byte[] unk7;
        public byte Claimed;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 27)]
        byte[] unk8;
        public int Owner;

        public string Name
        {
            get
            {
                string n = Encoding.ASCII.GetString(name);
                int start = n.IndexOf('\0');

                if (start > 0)
                    return n.Substring(0, start);
                else
                    return n.TrimEnd('\0');
            }
        }
    }

    public struct InventoryItemStruct
    {
        public UInt16 ID;
        public UInt16 Index;
        public UInt32 Count;
        public UInt32 Flags; //5 = Equipped, 15 = Using, 25 = Bazaar,
        //27 = Equipped by Mannequin
        //(Usually means item is disabled if not 0)
        public UInt32 Price;
        private byte Unknown1; //0 = None, 1 = Display Charges, 2 = Aug Tag
        private byte Unknown2; //Furnishing: 64 = Displayed, Item: Charges
        //Aegis/Excalibur (Aug) & Estq. Houseaux +1 = 67
        //Behavior may vary from above bit
        private UInt16 Unknown3; //Used for latent with the above 2 bytes
        private UInt16 Unknown4;
        public byte FurnishingX;
        public byte FurnishingY;
        public byte FurnishingZ;
        public byte FurnishingDirection; //0 = North, 1 = East, 2 = South, 3 = West
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Info; //Signature, Fish Size, Item Charge Info
    }

    public struct EquipmentSlotStruct
    {
        public int EquipmentSlot;
        public byte ItemIndex;
        public byte BagID;
        public byte unk0;
        public byte unk1;

    }

    public struct EquipmentStruct
    {
        public EquipmentSlotStruct Main;
        public EquipmentSlotStruct Sub;
        public EquipmentSlotStruct Range;
        public EquipmentSlotStruct Ammo;
        public EquipmentSlotStruct Head;
        public EquipmentSlotStruct Body;
        public EquipmentSlotStruct Hands;
        public EquipmentSlotStruct Legs;
        public EquipmentSlotStruct Feet;
        public EquipmentSlotStruct Neck;
        public EquipmentSlotStruct Waist;
        public EquipmentSlotStruct LeftEar;
        public EquipmentSlotStruct RightEar;
        public EquipmentSlotStruct LeftRing;
        public EquipmentSlotStruct RightRing;
        public EquipmentSlotStruct Back;
    }


    public struct InventoryStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x9860)]
        private byte[] unk0;

        public InventoryItemStruct Gil;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Inventory;
        private InventoryItemStruct gil0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Safe;
        private InventoryItemStruct gil1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Storage;
        private InventoryItemStruct gil2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Temporary;
        private InventoryItemStruct gil3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Locker;
        private InventoryItemStruct gil4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Satchel;
        private InventoryItemStruct gil5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Sack;
        private InventoryItemStruct gil6;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Case;
        private InventoryItemStruct gil7;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Wardrobe;
        private InventoryItemStruct gil8;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Safe2;
        private InventoryItemStruct gil9;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Wardrobe2;
        private InventoryItemStruct gil10;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Wardrobe3;
        private InventoryItemStruct gil11;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public InventoryItemStruct[] Wardrobe4;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x591)]
        private byte[] unk1;

        public byte InventoryMax;
        public byte SafeMax;
        public byte StorageMax;
        public byte TemporaryMax;
        public byte LockerMax;
        public byte SatchelMax;
        public byte SackMax;
        public byte CaseMax;
        public byte WardrobeMax;
        public byte Safe2Max;
        public byte Wardrobe2Max;
        public byte Wardrobe3Max;
        public byte Wardrobe4Max;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x1A2)]
        private byte[] unk2;

        public EquipmentStruct Equipment;


    }
}
