using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory;
using Kunihiro.Memory.SigScan;

namespace Kunihiro.FFXi
{
    

    public class Inventory
    {
        private PolProcess _polProcess;
        private IntPtr _inventoryAddress;

        public Inventory(int pid)
        {
            this._polProcess = new PolProcess(pid);
            SignatureScan ss = new SignatureScan(_polProcess.Process, _polProcess.FFXiMain);
            IntPtr temp = ss.FindSignature(Signatures.INVENTORY_SIGNATURE);
            _inventoryAddress = (IntPtr)MemTools.ReadProcessMemory<int>(_polProcess.Handle, temp);
       
        }

        private InventoryStruct ReadInventory()
        {
            return MemTools.ReadProcessMemory<InventoryStruct>(_polProcess.Handle,_inventoryAddress);
        }

        public uint Gil
        {
            get
            {
                return ReadInventory().Gil.Count;
            }
        }

        public InventoryItemStruct? GetItemByIndex(Bag bag, int index)
        {
            InventoryItemStruct[] b = GetBag(bag);

            foreach (InventoryItemStruct ii in b)
            {
                if (ii.Index == index)
                    return ii;
            }
            return null;
        }

        public InventoryItemStruct? GetItemByID(Bag bag, int id)
        {
            InventoryItemStruct[] b = GetBag(bag);

            foreach (InventoryItemStruct ii in b)
            {
                if (ii.ID == id)
                    return ii;
            }
            return null;
        }

        public bool HasItem(Bag bag, int id)
        {
            return GetItemByID(bag, id) != null;
        }

        public bool HasItem(int id)
        {
            return HasItem(Bag.Inventory, id) || HasItem(Bag.Wardrobe, id) || HasItem(Bag.Wardrobe2, id) || HasItem(Bag.Wardrobe3, id) || HasItem(Bag.Wardrobe4, id);
        }

        public EquipmentStruct GetEquipped()
        {
            return ReadInventory().Equipment;
        }

        public int GetBagCount(Bag bag)
        {
            InventoryItemStruct[] items = GetBag(bag);

            int count = 0;

            foreach (InventoryItemStruct item in items)
            {
                if (item.ID != 0)
                {
                    count++;
                }
            }

            return count;
        }

        public int GetBagSize(Bag bag)
        {
            InventoryStruct inventory = ReadInventory();

            switch (bag)
            {
                case Bag.Inventory:
                    return inventory.InventoryMax - 1;
                case Bag.Locker:
                    return inventory.LockerMax - 1;
                case Bag.Case:
                    return inventory.CaseMax - 1;
                case Bag.Sack:
                    return inventory.SackMax - 1;
                case Bag.Satchel:
                    return inventory.SatchelMax - 1;
                case Bag.Safe:
                    return inventory.SafeMax - 1;
                case Bag.Safe2:
                    return inventory.Safe2Max - 1;
                case Bag.Wardrobe:
                    return inventory.WardrobeMax - 1;
                case Bag.Wardrobe2:
                    return inventory.Wardrobe2Max - 1;
                case Bag.Wardrobe3:
                    return inventory.Wardrobe3Max - 1;
                case Bag.Wardrobe4:
                    return inventory.Wardrobe4Max - 1;
                case Bag.Storage:
                    return inventory.StorageMax - 1;
                case Bag.Temporary:
                    return inventory.TemporaryMax - 1;
            }

            return 0;
        }



        public InventoryItemStruct[] GetBag(Bag bag)
        {
            InventoryStruct inventory = ReadInventory();
            switch (bag)
            {
                case Bag.Inventory:
                    return inventory.Inventory;
                case Bag.Locker:
                    return inventory.Locker;
                case Bag.Case:
                    return inventory.Case;
                case Bag.Sack:
                    return inventory.Sack;
                case Bag.Satchel:
                    return inventory.Satchel;
                case Bag.Safe:
                    return inventory.Safe;
                case Bag.Safe2:
                    return inventory.Safe2;
                case Bag.Wardrobe:
                    return inventory.Wardrobe;
                case Bag.Wardrobe2:
                    return inventory.Wardrobe2;
                case Bag.Wardrobe3:
                    return inventory.Wardrobe3;
                case Bag.Wardrobe4:
                    return inventory.Wardrobe4;
                case Bag.Storage:
                    return inventory.Storage;
                case Bag.Temporary:
                    return inventory.Temporary;
            }

            return null;
        }
    }
}
