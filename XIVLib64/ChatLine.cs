using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.XIV
{
    public class ChatLine : IEquatable<ChatLine>
    {
        private int unk;
        private int unk2;

        private string line;
        private string rawLine;

        private byte[] raw;

        public int Stuff
        {
            get
            {
                return unk;
            }
            internal set
            {
                unk = value;
            }
        }

        public int Mode
        {
            get
            {
                return unk2;
            }
            internal set
            {
                unk2 = value;
            }
        }

        public string Line
        {
            get
            {
                return line;
            }
            internal set
            {
                line = value;
            }
        }

        public string RawLine
        {
            get
            {
                return rawLine;
            }
            internal set
            {
                rawLine = value;
            }
        }

        public byte[] Raw
        {
            get
            {
                return raw;
            }
            internal set
            {
                raw = value;
            }
        }

        public bool Equals(ChatLine other)
        {
            return this.raw.SequenceEqual(other.raw);
        }
    }
}
