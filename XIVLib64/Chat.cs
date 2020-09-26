using System;
using System.Runtime.InteropServices;
using Kunihiro.Memory;
using System.Text;
using System.Collections.Generic;
using Kunihiro.Memory.SigScan;
using System.Text.RegularExpressions;

namespace Kunihiro.XIV
{
    public class Chat
    {
        private XIVProcess _process;
        private SignatureScan _scan;
        private IntPtr _chatlogPtr;
        private List<ChatLine> _chatlog = new List<ChatLine>();

        public Chat(XIVProcess proc)
        {
            _process = proc;
            _scan = new SignatureScan(proc,proc.MainModule);
         
            _chatlogPtr = _scan.FindRelativeSignature("4585C07829488B05");
        }

        public uint Count
        {
            get
            {
                return GetCount(ReadChatLogHeader()) + 1;
            }
        }

        //public int GlobalCount
        //{
        //    get
        //    {
        //        return ReadChatLogHeader().count;
        //    }
        //}

        private uint GetCount(ChatLogHeader clh)
        {
            uint[] offsets = ReadChatLogOffsets(clh);

            uint i = 0;

            while(((ulong)clh.startOfLogPtr + offsets[i]) < (ulong)clh.endofLogPtr)
            {
                i++;
            }

            return i;
        }

        private uint[] ReadChatLogOffsets(ChatLogHeader header)
        {
            IntPtr offsetPtr = header.offsetsPtr;
            uint[] offsets = new uint[header.count];

            for (uint i = 0; i < header.count; i++)
            {
                offsets[i] = MemTools.ReadProcessMemory<uint>(_process.Handle, (IntPtr)((ulong)offsetPtr + (i * 4)));
            }

            return offsets;
        }

        public ChatLine[] GetNewLines()
        {
            ChatLine[] lines = ReadChatLines(ReadChatLogHeader());
            List<ChatLine> newLines = new List<ChatLine>();

            foreach (ChatLine c in lines)
            {
                if(!_chatlog.Contains(c))
                {
                    _chatlog.Add(c);
                    newLines.Add(c);
                }
            }

            return newLines.ToArray();
        }

        //public byte[][] GetChatLinesRaw()
        //{
        //    return ReadChatLinesRaw(ReadChatLogHeader());
        //}

        private byte[][] ReadChatLinesRaw(ChatLogHeader clh)
        {
            uint[] offsets = ReadChatLogOffsets(clh);
            uint chatlogSize = (uint)((ulong)clh.endofLogPtr - (ulong)clh.startOfLogPtr);

            uint count = GetCount(clh);

            List<byte[]> rawstrings = new List<byte[]>();

            byte[] chatLogRaw = new byte[chatlogSize];
            MemTools.ReadProcessMemory(_process.Handle, clh.startOfLogPtr, chatLogRaw, chatlogSize, 0);

            if(count > 0)
            {
                uint chunkSize = count > 1 ? offsets[0] :  (uint)((ulong)clh.endofLogPtr - (ulong)clh.startOfLogPtr);

                byte[] raw = new byte[chunkSize];
                Buffer.BlockCopy(chatLogRaw, 0, raw, 0, (int)chunkSize);

                rawstrings.Add(raw);
            }

            for (int i = 0; i < count; i++)
            {
                uint chunkSize = i < count - 1 ? (offsets[i + 1] - offsets[i]) :
                    (uint)((ulong)clh.endofLogPtr - ((ulong)clh.startOfLogPtr + offsets[i]));

                byte[] raw = new byte[chunkSize];

                Buffer.BlockCopy(chatLogRaw, (int)offsets[i], raw, 0, (int)chunkSize);

                rawstrings.Add(raw);
            }

            return rawstrings.ToArray();
        }

        public ChatLine[] GetChatLines()
        {
            return ReadChatLines(ReadChatLogHeader());
        }

        private ChatLine[] ReadChatLines(ChatLogHeader clh)
        {
            byte[][] linesRaw = ReadChatLinesRaw(clh);
            List<ChatLine> lines = new List<ChatLine>();

            foreach(byte[] b in linesRaw)
            {
                ChatLine c = new ChatLine();
                if (b.Length > 0)
                {
                    c.Stuff = BitConverter.ToInt32(b, 0);
                    c.Mode = BitConverter.ToInt32(b, 4);
                    c.Line = CleanString(Encoding.Default.GetString(b, 8, b.Length - 8));
                    c.Raw = b;
                    c.RawLine = Encoding.ASCII.GetString(b, 8, b.Length - 8);
                    //string[] parts = c.Line.Split('');

                    //if(parts.Length > 1 && parts[0] == parts[1])
                    //{
                    //    c.Line = c.Line.Replace(parts[0] + "" + parts[1], parts[0]);
                    //}

                    lines.Add(c);
                }
            }

            return lines.ToArray();
        }
        private ChatLogHeader ReadChatLogHeader()
        {
            IntPtr headerAddr = MemTools.ReadPointer(_process.Handle, _chatlogPtr, 0x40, 0x38C);

            return MemTools.ReadProcessMemory<ChatLogHeader>(_process.Handle, headerAddr);
        }

        //wip
        private string CleanString(string s)
        {
            string[] c = s.Split('');

            if (c.Length > 1)
            {
                string s1 = Regex.Replace(c[0], @"[^\u0020-\u007E]", string.Empty).TrimStart(':').TrimStart('\'');
                int i = s.IndexOf(s1);

                //while (i != -1 && i != 0)
                //{
                //    s = s.Remove(i, s1.Length);
                //    i = s.IndexOf(s1, i + s1.Length);
                //}
            }

            return Regex.Replace(s, @"[^\u0020-\u007E]", string.Empty).TrimStart(':');
        }

        
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct ChatLogHeader
        {
            public uint count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x30)]
            private byte[] unk0;
            public IntPtr offsetsPtr;
            private IntPtr unk1;
            private IntPtr unk2;
            public IntPtr startOfLogPtr;
            public IntPtr endofLogPtr;
        }
    }

   
}
