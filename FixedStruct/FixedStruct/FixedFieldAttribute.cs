using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.FixedStruct
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FixedFieldAttribute : Attribute
    {
        public int Offset { get; set; } = 0;
        public int Size { get; set; } = 0;
        public FixedFieldType Type { get; set; } = FixedFieldType.Value;
        public int BitOffset { get; set; } = 0;
        public Type BitFieldType { get; set; }
    }
}
