using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kunihiro.Memory;
using Kunihiro.Memory.SigScan;

namespace Kunihiro.FFXi
{
    public class ChatLine
    {
        public string Text { get; internal set; }
        public int Color { get; internal set; }
        public string Raw { get; internal set; }
        public int Count { get; internal set; }


        public override bool Equals(object obj)
        {
            ChatLine c = (ChatLine)obj;
            return this.Count == c.Count && this.Text == c.Text;
        }
    }

    public class Chat
    {
        private PolProcess FFXi;
       

        public IntPtr chatLogAddress;

        private List<ChatLine> chatHistory = new List<ChatLine>();
        private int count = 0;

        public Chat(int pid)
        {
            FFXi = new PolProcess(pid);

            SignatureScan ss = new SignatureScan(FFXi.Process, FFXi.FFXiMain);
            chatLogAddress = ss.FindSignature(Signatures.CHAT_SIGNATURE) + 8;
        }

        private ChatLogStruct Read()
        {
            IntPtr firstAddr = (IntPtr)(MemTools.ReadProcessMemory<int>(FFXi.Handle, chatLogAddress) + 4);
            IntPtr secondAddr = MemTools.ReadProcessMemory<IntPtr>(FFXi.Handle, firstAddr);
            return MemTools.ReadProcessMemory<ChatLogStruct>(FFXi.Handle, secondAddr);
        }

        private string CleanLine(string text)
        {
            return text.TrimEnd('\0').Replace("??", "").Replace("?", "").Replace("?", "").Replace("", "").Replace("y", "").Replace("?'", "{").Replace("?(", "}").Replace("?@?", "");
        }

        public ChatLine GetNextLine()
        {
            ChatLine[] lines = ReadChatLog();
           
            bool empty = false;

            if (chatHistory.Count == 0)
                empty = true;
           
            foreach(ChatLine line in lines)
            {
                if(!chatHistory.Contains(line))
                {
                    chatHistory.Add(line);

                    if (empty)
                        count++;
                    
                }
            }
            
            if(count < chatHistory.Count)
            {
                ChatLine c = chatHistory[count];
                count++;
                return c;
            }

            return null;
        }

        public ChatLine[] ReadChatLog()
        {
            ChatLogStruct cls = Read();
            List<ChatLine> lines = new List<ChatLine>();

            for (int i = 0; i < cls.NumberOfLines; i++)
            {
                byte[] buffer;

                if (i == cls.NumberOfLines - 1)
                {
                    buffer = new byte[cls.FinalOffset - cls.NewChatLogOffsets[i]];
                }
                else
                {
                    buffer = new byte[cls.NewChatLogOffsets[i + 1] - cls.NewChatLogOffsets[i]];
                }
                MemTools.ReadProcessMemory(FFXi.Handle, (IntPtr)((int)cls.NewChatLogPtr + cls.NewChatLogOffsets[i]), buffer, buffer.Length, 0);

                string s = Encoding.GetEncoding("shift-jis").GetString(Encoding.ASCII.GetBytes(CleanLine(Encoding.ASCII.GetString(buffer))));

                string[] split = s.Split(',');

                string text = "";

                for (int x = 0; x < (split.Length - 21); x++)
                {
                    text += split[21 + x] + ",";
                }
               
                ChatLine cl = new ChatLine();
                cl.Text = text.TrimEnd('\0').Replace("ﾉ", "").Replace("", "").Replace("", "").Replace("梗", "[");


                int second = cl.Text.IndexOf(']') + 1;

                cl.Text = cl.Text.Substring(second);

                int first = cl.Text.LastIndexOf("1");
                if(first > 0)
                cl.Text = cl.Text.Remove(first,1);


                cl.Raw = s;
                cl.Color = int.Parse(split[3], NumberStyles.HexNumber);
                cl.Count = int.Parse(split[5],NumberStyles.HexNumber);
                lines.Add(cl);
            }


            return lines.ToArray();
        }

        private ChatLine[] TestRead()
        {
            ChatLogStruct cls = Read();
            List<ChatLine> lines = new List<ChatLine>();

            if (cls.OldChatLogPtr != IntPtr.Zero)
            {
                for (int i = 0; i < 49; i++)
                {
                    byte[] buffer;

                    buffer = new byte[cls.OldChatLogOffsets[i + 1] - cls.OldChatLogOffsets[i]];


                    MemTools.ReadProcessMemory(FFXi.Handle, (IntPtr)((int)cls.OldChatLogPtr + cls.OldChatLogOffsets[i]), buffer, buffer.Length, 0);

                    string s = Encoding.GetEncoding("shift-jis").GetString(buffer);

                    string[] split = s.Split(',');


                    ChatLine cl = new ChatLine();
                    cl.Text = split[split.Length - 1].TrimEnd('\0');
                    cl.Color = int.Parse(split[3], NumberStyles.HexNumber);
                    lines.Add(cl);
                }
            }

            for (int i = 0; i < cls.NumberOfLines; i++)
            {
                byte[] buffer;

                if (i == cls.NumberOfLines - 1)
                {
                    buffer = new byte[cls.FinalOffset - cls.NewChatLogOffsets[i]];
                }
                else
                {
                    buffer = new byte[cls.NewChatLogOffsets[i + 1] - cls.NewChatLogOffsets[i]];
                }
                MemTools.ReadProcessMemory(FFXi.Handle, (IntPtr)((int)cls.NewChatLogPtr + cls.NewChatLogOffsets[i]), buffer, buffer.Length, 0);

                string s = Encoding.GetEncoding("shift-jis").GetString(buffer);

                string[] split = s.Split(',');

                string text = "";

                for (int x = 0; x < (split.Length - 21); x++)
                {
                    text += split[21 + x] + ",";
                }

                ChatLine cl = new ChatLine();
                cl.Text = text.TrimEnd('\0').Replace("ﾉ", "").Replace("", "").Replace("", "");
                cl.Color = cl.Color = int.Parse(split[3], NumberStyles.HexNumber);
                lines.Add(cl);
            }


            return lines.ToArray();
        }
    }
}
