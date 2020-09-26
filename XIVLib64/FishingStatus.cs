using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.XIV
{
    public enum FishingStatus : int
    { 
        Error = -1,
        Idle = 0,
        NotFishing = 17,
        PostCatch_LostCatch = 15,
        Fishing = 18,
        LostFish = 27,
        CaughtFish = 28,
        FishBite1 = 36,
        FishBite2 = 37,

    }
}
