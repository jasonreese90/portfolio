using Kunihiro.FixedStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedStructTest
{   
    [FixedStruct(Size =500)]
    public struct Entity
    {


        [FixedField(Offset = 0x48)]
        public float rotation;

        [FixedField(Offset = 0x74)]
        public int id;

        [FixedField(Offset = 0x78)]
        public int serverId;

        [FixedField(Offset = 0x7C, Size =20)]
        public string name;

        [FixedField(Offset =0x129,BitOffset = 0x2,BitFieldType = typeof(int),Type = FixedFieldType.BitField)]
        public bool hasBazaar;
    }
}
