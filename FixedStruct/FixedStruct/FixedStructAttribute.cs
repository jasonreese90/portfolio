﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.FixedStruct
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class FixedStructAttribute : Attribute
    {
        public int Size { get; set; }
    }
}
