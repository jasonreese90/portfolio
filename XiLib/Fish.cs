using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory;

namespace Kunihiro.FFXi
{
   public class Fish
    {
        private Process _polProcess;
        private Fishs _fish;
        private FishingInfo _fishinfo;
        private IntPtr ffxiMain;
        private int offset = 0x4742C0;

       
        public Fish(int pid)
        {
            this._polProcess = Process.GetProcessById(pid);

            foreach (ProcessModule pm in _polProcess.Modules)
            {
                if (pm.ModuleName.ToLower() == "ffximain.dll")
                {
                    ffxiMain = pm.BaseAddress;
                    break;
                }
            }
        }
       
        private void ReadFish()
        {
            this._fishinfo = MemTools.ReadProcessMemory<FishingInfo>(_polProcess.Handle, ((IntPtr)(int)(ffxiMain + offset)));
            if (this._fishinfo.fishPtr != 0)
            {
                this._fish = MemTools.ReadProcessMemory<Fishs>(_polProcess.Handle, (IntPtr)this._fishinfo.fishPtr);
            }
        }

        public int HP
        {
            get
            {
                ReadFish();

                return _fish.HP;
            }
        }

        public int MaxHP
        {
            get
            {
                ReadFish();

                return _fish.MaxHP;
            }
        }

        public int Pointer
        {
            get
            {
                ReadFish();
                return _fishinfo.fishPtr;
            }
        }

        public bool FishOn
        {
            get
            {
                ReadFish();
                return _fishinfo.fishPtr != 0;
            }
        }

        public int ID1
        {
            get
            {
                ReadFish();


                return _fish.ID1;
            }
        }
        public int ID2
        {
            get
            {
                ReadFish();


                return _fish.ID2;

            }
        }
        public int ID3
        {
            get
            {
                ReadFish();


                return _fish.ID3;


            }
        }
        public int ID4
        {
            get
            {
                ReadFish();


                return _fish.ID3;


            }
        }
        public Fishs fish
        {
            get
            {
                ReadFish();
                return _fish;
            }
        }

        public FishingInfo fishInfo
        {
            get
            {
                ReadFish();
                return _fishinfo;
            }
        }

        public int TimeRemaining
        {
            get
            {
                ReadFish();

                return _fish.timeout;
            }
        }

        public RodPosition Position
        {
            get
            {
                ReadFish();

                if (_fishinfo.rodPos == 1)
                    return RodPosition.Center;
                if (_fishinfo.rodPos == 2 && _fish.rodPos == 0)
                    return RodPosition.Left;
                if (_fishinfo.rodPos == 2 && _fish.rodPos == 1)
                    return RodPosition.Right;
                return RodPosition.Error;
            }
        }


    }
    public enum RodPosition
    {
        Error,
        Left,
        Center,
        Right
    }
}
