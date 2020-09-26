using Kunihiro.Memory.SigScan;
using System;
using Kunihiro.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;

namespace Kunihiro.XIV
{
    public class Inventory
    {
        private XIVProcess _process;
        private SignatureScan _scan;
        public IntPtr _invPtr;

        public Inventory(XIVProcess proc)
        {
            _process = proc;
            _scan = new SignatureScan(proc, proc.MainModule);

            _invPtr = MemTools.ReadProcessMemory<IntPtr>(proc.Handle, _scan.FindRelativeSignature("4C897C2430448D630C4C8B3D"));
        }


        public MainInventory Main
        {
            get
            {
                return new MainInventory(_process, ReadInventoryHeader(), this);
            }
        }

        public InventoryItem[] Equipped
        {
            get
            {
                InventoryHeader header = ReadInventoryHeader();

                return ReadPage(header.equipped.slotPtr, header.equipped.slotCapacity);
            }
        }

        public InventoryItem[] ArmoryChestMain
        {
            get
            {
                InventoryHeader header = ReadInventoryHeader();

                return ReadPage(header.chestMain.slotPtr, header.chestMain.slotCapacity);
            }
        }


        public InventoryItem[] Currency
        {
            get
            {
                InventoryHeader header = ReadInventoryHeader();

                return ReadPage(header.currency.slotPtr, header.currency.slotCapacity);
            }
        }

        private InventoryHeader ReadInventoryHeader()
        {
            return MemTools.ReadProcessMemory<InventoryHeader>(_process.Handle, _invPtr);
        }


        internal InventoryItem[] ReadPage(IntPtr slotPtr, uint count)
        {
            return MemTools.ReadProcessMemoryArray<InventoryItem>(_process.Handle, slotPtr, count);
        }


        public class MainInventory : IEnumerable<InventoryItem>
        {
            private XIVProcess _proc;
            private InventoryHeader _header;
            private Inventory inv;

            internal MainInventory(XIVProcess proc, InventoryHeader header, Inventory inv)
            {
                this._proc = proc;
                this._header = header;
                this.inv = inv;
            }

            public IEnumerator<InventoryItem> GetEnumerator()
            {
                return ((IEnumerable<InventoryItem>)All).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<InventoryItem>)All).GetEnumerator();
            }

            private InventoryItem[] All
            {
                get
                {
                    List<InventoryItem> items = new List<InventoryItem>();
                    items.AddRange(this.Page1);
                    items.AddRange(this.Page2);
                    items.AddRange(this.Page3);
                    items.AddRange(this.Page4);

                    return items.ToArray();
                }
            }

            public InventoryItem[] Page1
            {
                get
                {
                    return inv.ReadPage(_header.page1.slotPtr, _header.page1.slotCapacity);
                }
            }

            public InventoryItem[] Page2
            {
                get
                {
                    return inv.ReadPage(_header.page2.slotPtr, _header.page2.slotCapacity);
                }
            }

            public InventoryItem[] Page3
            {
                get
                {
                    return inv.ReadPage(_header.page3.slotPtr, _header.page3.slotCapacity);
                }
            }
            public InventoryItem[] Page4
            {
                get
                {
                    return inv.ReadPage(_header.page4.slotPtr, _header.page4.slotCapacity);
                }
            }
        }



    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InventorySlot
    {
        public IntPtr slotPtr;
        public uint slotIndex;
        public uint slotCapacity;
        private uint slotunk;
        private uint slotUnk0;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InventoryHeader
    {
        public InventorySlot page1;
        public InventorySlot page2;
        public InventorySlot page3;
        public InventorySlot page4;

        public InventorySlot equipped;
        public InventorySlot currency;
        public InventorySlot crystals;

        private InventorySlot unk1;
        private InventorySlot unk2;

        public InventorySlot keyItems;

        public InventorySlot unk4;
        public InventorySlot unk5;
        private InventorySlot unk6;
        private InventorySlot unk7;
        private InventorySlot unk8;
        private InventorySlot unk9;
        private InventorySlot unk10;
        private InventorySlot unk11;
        private InventorySlot unk12;
        private InventorySlot unk13;
        private InventorySlot unk14;
        private InventorySlot unk15;
        private InventorySlot unk16;
        private InventorySlot unk17;
        private InventorySlot unk18;
        private InventorySlot unk19;
        private InventorySlot unk20;
        private InventorySlot unk21;
        private InventorySlot unk22;
        private InventorySlot unk23;

        public InventorySlot chestMain;
        public InventorySlot chestSecondary;
        public InventorySlot chestHead;
        public InventorySlot chestBody;
        public InventorySlot chestHands;
        public InventorySlot chestWaist;
        public InventorySlot chestLegs;
        public InventorySlot chestFeet;
        public InventorySlot chestEarring;
        public InventorySlot chestNeck;
        public InventorySlot chestWrist;
        public InventorySlot chestRing;
        public InventorySlot chestSoul;


        private InventorySlot unk24;
        private InventorySlot unk25;
        private InventorySlot unk26;
        private InventorySlot unk27;
        private InventorySlot unk28;
        private InventorySlot unk29;
        private InventorySlot unk30;
        private InventorySlot unk31;
        private InventorySlot unk32;
        private InventorySlot unk33;
        private InventorySlot unk34;
        private InventorySlot unk35;
        private InventorySlot unk36;
        private InventorySlot unk37;
        private InventorySlot unk38;
        private InventorySlot unk39;
        private InventorySlot unk40;
        private InventorySlot unk41;
        private InventorySlot unk42;
        private InventorySlot unk43;
        private InventorySlot unk44;
        private InventorySlot unk45;
        private InventorySlot unk46;
        private InventorySlot unk47;
        private InventorySlot unk48;
        private InventorySlot unk49;
        private InventorySlot unk50;
        private InventorySlot unk51;
        private InventorySlot unk52;
        private InventorySlot unk53;

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InventoryItem
    {
        public uint index;
        public uint invIndex;
        public uint itemId;
        public uint count;
        private int unk2;
        public uint hq;
        public uint sig1;
        public uint sig2;
        private int unk3;
        private int unk4;
        private int unk5;
        private int unk6;
        public uint glamourId;
        private int unk7;
    }
}
