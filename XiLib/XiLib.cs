using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.FFXi
{
    public class XiLib
    {
        public Chat Chat { get; private set; }
        public Fish Fish { get; private set; }
        public Player Player { get; private set; }

        public Party Party { get; private set; }

        public Inventory Inventory { get; private set; }

        public Windower Windower { get; private set; }
        public NPC NPC { get; private set; }
        public NaHookHelper NaHook { get; private set; }
        public XiLib(int pid)
        {
            Chat = new Chat(pid);
            Fish = new Fish(pid);
            Player = new Player(pid);
            NPC = new NPC(pid);
            //Windower = new Windower(pid);
            Inventory = new Inventory(pid);
            Party = new Party(pid);
            NaHook = new NaHookHelper(pid);
        }
    }
}
