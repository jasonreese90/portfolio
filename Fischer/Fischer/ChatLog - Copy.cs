using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.IO;

namespace Fischer
{
    public class NewLineEventArgs
    {
        public NewLineEventArgs(string text)
        {
            Text = text;
        }

        public string Text{get;set;}
    }

    struct LineInfo
    {
        public int Color;
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=512)]
        public string Text;
    }

    public class ChatLog
    {
        private NamedPipeClientStream client;
        private BufferedStream bs;
        private Thread thread;
        private bool listen;
        private int pid;

        public ChatLog(int pid)
        {
            Connect(pid);
            this.pid = pid;
        }

        public delegate void NewLineEventHandler(object sender,NewLineEventArgs e);

        public event NewLineEventHandler NewLine;

        public void Listen()
        {
            listen = true;
            thread = new Thread(new ThreadStart(ListenThread));
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            listen = false;
        }

        private void Connect(int pid)
        {
            client = new NamedPipeClientStream("fishpipe_" + pid);

            client.Connect();

            bs = new BufferedStream(client);

            if (!client.IsConnected)
            {
                Stop();
                MessageBox.Show("Error connecting to hook");
            }
        }

        private void ListenThread()
        {
            while (listen)
            {
               
                byte[] buffer = new byte[Marshal.SizeOf(typeof(LineInfo))];

                if (!client.IsConnected)
                {
                    Connect(pid);
                }



                try
                {
                    bs.Read(buffer, 0, Marshal.SizeOf(typeof(LineInfo)));
                    
                }
                catch (ObjectDisposedException ex)
                {
                    try
                    {
                        Connect(pid);
                    }
                    catch (Exception e)
                    {
                        ErrorLog.OnError(e);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    try
                    {
                        Connect(pid);
                    }
                    catch (Exception e)
                    {
                        ErrorLog.OnError(e);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                LineInfo li;

                try
                {
                    li = (LineInfo)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(LineInfo));
                }
                finally
                {
                    handle.Free();
                }

                string s = li.Text;
                if (!string.IsNullOrEmpty(s))
                {
                    s = CleanLine(s.TrimEnd('\0'));
                    NewLine(this, new NewLineEventArgs(s));
                }

            }
        }


        #region CleanLine
        private string CleanLine(string line)
        {
            // change the dot to a [ for start of string
            string startingChars = System.Text.Encoding.GetEncoding(932).GetString(new byte[2] { 0x1e, 0xfc });
            if (line.StartsWith(startingChars))
                line = "[" + line.Substring(2);

            line = line.Replace("y", String.Empty);

            if (line.Contains(" "))
            {
                line = line.Replace(" ", "**&*&!!@#$@$#$");
                line = line.Replace("**&*&!!@#$@$#$", " ");
            }

            line = line.Replace("1", "");
            line = line.Replace(" ", " "); // green start
            line = line.Replace("", "");   // green end
            line = line.Replace("Ð", "");
            line = line.Replace("{", "");
            line = line.Replace("ﾐ", "");
            line = line.Replace("", "");
            line = line.Replace("・", "E");
            line = line.Replace("・", "[");
            line = line.Replace("・", "");
            line = line.Replace("巧", "I"); // Yellow colored lines, JP
            line = line.Replace("｡", ""); // Super Kupowers, JP
            line = line.Replace("垢", "C"); // Change job text.
            line = line.Replace("ü", "");
            line = line.Replace("¡", "■");
            line = line.Replace("‡²", "\"");
            line = line.Replace("‡³", "\"");
            line = line.Replace("ï'", "【");
            line = line.Replace("ï(", "】");

            // trim the 1 that occasionally shows up at the end
            if (line.EndsWith("1"))
                line = line.TrimEnd('1');

            line = line.TrimStart('');

            if (line.StartsWith("["))  // Detect and remove Windower Timestamp plugin text.
            {
                string text = line.Substring(1, 8);
                string re1 = ".*?";	// Non-greedy match on filler
                string re2 = "((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)";

                Regex r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Match m = r.Match(text);
                if (m.Success)
                {
                    line = line.Remove(0, 11);
                }
            } // Detect and remove Windower Timestamp plugin text.

            return line.TrimStart(' ');

        } // private CleanLine(string line)
        #endregion
    }
}
