using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Kunihiro.XIV
{
    public class XIVLib
    {
        private XIVProcess _process;

        private Chat _chat;
        private Fish _fish;
        private Input _input;
        private Player _player;
        private Inventory _inventory;

        public XIVLib(XIVProcess proc)
        {
            _process = proc;

            _chat = new Chat(proc);
            _fish = new Fish(proc);
            _input = new Input(proc);
            _player = new Player(proc);
            _inventory = new Inventory(proc);
        }
       
        public Chat Chat
        {
            get
            {
                return _chat;
            }
        }

        public Fish Fish
        {
            get
            {
                return _fish;
            }
        }

        public Input Input
        {
            get
            {
                return _input;
            }
        }

        public Player Player
        {
            get
            {
                return _player;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

    }
}
