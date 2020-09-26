using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Kunihiro.Memory
{

    public static class MemTools
    {
        [DllImport("kernel32")]
        public static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, byte[] buffer, int size, int ignore);

        public static T ReadProcessMemory<T>(IntPtr handle, IntPtr address)
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];
            ReadProcessMemory(handle, address, buffer, size, 0);
            GCHandle gc = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            T t = (T)Marshal.PtrToStructure(gc.AddrOfPinnedObject(), typeof(T));

            gc.Free();

            return t;
        }
    }
}
