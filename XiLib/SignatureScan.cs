// -----------------------------------------------------------------------
// <copyright file="SignatureScan.cs" company="Kunihiro">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Kunihiro.Memory.SigScan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Globalization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SignatureScan
    {
        private Process process;
        private ProcessModule targetModule;
        private bool moduleDumped = false;
        private byte[] dumpBuffer;

        public SignatureScan(Process process, ProcessModule targetModule)
        {
            this.process = process;
            this.targetModule = targetModule;
        }

        public void DumpMemory()
        {
            dumpBuffer = new byte[targetModule.ModuleMemorySize];
            ReadProcessMemory(process.Handle, targetModule.BaseAddress, dumpBuffer, (uint)targetModule.ModuleMemorySize, 0);
            moduleDumped = true;
        }

        private int IndexOf(byte[] haystack, byte[] needle)
        {
            int[] lookup = new int[256];
            for (int i = 0; i < lookup.Length; i++) { lookup[i] = needle.Length; }

            for (int i = 0; i < needle.Length; i++)
            {
                lookup[needle[i]] = needle.Length - i - 1;
            }

            int index = needle.Length - 1;
            var lastByte = needle.Last();
            while (index < haystack.Length)
            {
                var checkByte = haystack[index];
                if (haystack[index] == lastByte)
                {
                    bool found = true;
                    for (int j = needle.Length - 2; j >= 0; j--)
                    {
                        if (haystack[index - needle.Length + j + 1] != needle[j])
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                        return index - needle.Length + 1;
                    else
                        index++;
                }
                else
                {
                    index += lookup[checkByte];
                }
            }
            return -1;
        }

        private byte[] ParseBytes(string pattern)
        {
            if (pattern.Length % 2 != 0 || pattern.Length < 2)
                return null;

            byte[] buffer = new byte[pattern.Length / 2];

            for (int i = 0; i < pattern.Length; i += 2)
            {
                buffer[i / 2] = ParseByte(pattern[i], pattern[i + 1]);
            }

            return buffer;
        }

        public IntPtr FindSignature(string pattern, int offset = 0, bool dereference = true, bool addSigLen = true)
        {
            if (pattern.Length % 2 != 0 || pattern.Length < 2)
                return IntPtr.Zero;

            if (!moduleDumped)
                DumpMemory();


            byte[] bPattern = ParseBytes(pattern);

            int index = IndexOf(dumpBuffer, bPattern);

            if (index != -1)
            {
                int len = addSigLen ? pattern.Length / 2 : 0;
                IntPtr addr = (IntPtr)(int)targetModule.BaseAddress + index + len;

                if (dereference)
                {
                    byte[] buff = new byte[4];
                    ReadProcessMemory(process.Handle, addr + offset, buff, 4, 0);
                    int x = BitConverter.ToInt32(buff, 0);
                    return (IntPtr)x;
                }

                return addr;
            }

            return IntPtr.Zero;
        }

        private byte ParseByte(char c1, char c2)
        {
            string s = c1.ToString() + c2.ToString();
            return byte.Parse(s, NumberStyles.HexNumber);
        }


        [DllImport("kernel32")]
        static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, byte[] buffer, uint size, int bytesRead);
    }
}