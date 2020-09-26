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
        public static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, byte[] buffer, uint size, int ignore);

        private static T ByteArrayToStruct<T>(byte[] buffer) where T : struct
        {
            GCHandle gc = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            T t = (T)Marshal.PtrToStructure(gc.AddrOfPinnedObject(), typeof(T));

            gc.Free();

            return t;
        }
        public static T ReadProcessMemory<T>(IntPtr handle, IntPtr address) where T: struct
        {
            uint size = (uint)Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];
            ReadProcessMemory(handle, address, buffer, size, 0);
            return ByteArrayToStruct<T>(buffer);
        }


        public static T[] ReadProcessMemoryArray<T>(IntPtr handle, IntPtr address, uint arraySize) where T : struct
        {
            uint itemSize = (uint)Marshal.SizeOf(typeof(T));
            uint bufferSize = itemSize * arraySize;

            byte[] buffer = new byte[bufferSize];
            T[] t = new T[arraySize];

            ReadProcessMemory(handle, address, buffer, bufferSize, 0);
   
            for(int i = 0; i < arraySize;i++)
            {
                byte[] item = new byte[itemSize];
           
                Buffer.BlockCopy(buffer, ((int)itemSize * i), item, 0, (int)itemSize);
                t[i] = ByteArrayToStruct<T>(item);
            }

            return t;
        }

        public static byte ReadByte(IntPtr handle, IntPtr address) 
        {
            byte[] buffer = new byte[1];
            ReadProcessMemory(handle, address, buffer, 1,0);

            return buffer[0];
        }
        public static short ReadShort(IntPtr handle, IntPtr address)
        {
            byte[] buffer = new byte[2];
            ReadProcessMemory(handle, address, buffer, 2, 0);

            return BitConverter.ToInt16(buffer, 0);
        }

        public static int ReadInt(IntPtr handle, IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(handle, address, buffer, 4, 0);

            return BitConverter.ToInt32(buffer, 0);
        }

        public static string ReadString(IntPtr handle, IntPtr address, uint strlen)
        {
            byte[] buffer = new byte[strlen];
            ReadProcessMemory(handle, address, buffer, strlen, 0);

            return Encoding.ASCII.GetString(buffer);
        }

        //public static T[] ReadArray<T>(IntPtr handle, IntPtr address, int size)
        //{
        //    T[] t = new T[size];



        //    return t;
        //}

        public static IntPtr ReadPointer(IntPtr handle, IntPtr address, params int[] offsets)
        {
            long addr = (long)address;

            for(int i = 0; i < offsets.Length; i++)
            {
                addr = ReadProcessMemory<long>(handle,(IntPtr)addr);
                addr += offsets[i];
            }

            return (IntPtr)addr;
        }
    }
}
