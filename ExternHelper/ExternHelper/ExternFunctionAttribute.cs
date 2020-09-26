using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.ExternHelper
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple=false,Inherited=false)]
    public class ExternFunctionAttribute : Attribute
    {
        public int Offset { get; set; }
        public string Module { get; set; }
        public int Address { get; set; }
        public bool UseStaticAddress {get;set;}
        public CallingConvention CallingConvention { get; set; }
    }
}
