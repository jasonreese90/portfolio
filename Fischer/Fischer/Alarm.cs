//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Kunihiro.FFXI.FFXiLib;
//using System.Media;
//using Fischer.Properties;
//using System.Threading;

//namespace Fischer
//{
//    public class Alarm
//    {
//        private const int GM_FLAG = 536870912;

//        private ChatLog chatLog;
//        private FFXiLib ffxi;
//        private Fischer fischer;
//        private SoundPlayer sound;
//        private bool running = false;
//        private Thread zoneThread;
//        private Thread menuThread;
//        private Thread scannerThread;

//        private string[] menuWhiteList = { "logwindo", "fulllog", "playermo", "wind", "socialme", "statcom2", "merit1", "merit2", "meritcat", "equip", "inventor", 
//                                             "mgc", "magic", "mgcsortw", "blusortwc", "itmsortw", "sortyn", "iuse", "ability", "abisortw", "prty3", "scresult", "prty8", "partywin", "prty4", "levelsyn", 
//                                             "handover", "comgenre", "sccompar", "comment9", "link4", "link5", "link12", "link13", "flistmai", "msglist", "friend", "olstat", "region", "cnqframe", "missionm9", 
//                                             "miss00", "quest00", "quest01", "evitem", "mogcont", "bank", "bazaar", "shop", "mcrselec", "mcr1edit", "mcr2edit", "mcrbedit2", "mcrselop", "macro", "conf2win", "configwi", 
//                                             "cfilter", "conftxtc", "textcol1", "textcol3", "confyn", "conf5win", "conf6win2", "conf3win", "fxfilter", "conf7", "conf4", 
//                                             "comyn", "faqsub", "faqmain", "map0", "inline", "mapv3", "chatctrl", "magselec", "inspect", "moneyctr", "shopsell", "itemctrl", "trade", "gift", "shopbuy","mcr1pall","mcr2pall" };

//        public Alarm(ChatLog chatLog, Fischer fischer,FFXiLib ffxi)
//        {
//            this.chatLog = chatLog;
//            this.ffxi = ffxi;
//            this.fischer = fischer;
//            this.sound = new SoundPlayer(Resources.alarm);
            
//        }

//        private void chatLog_NewLine(object sender, NewLineEventArgs e)
//        {
//            if (e.Text.Contains("[GM]"))
//            {
//                sound.PlayLooping();
//                fischer.Stop();
//            }
//        }

//        private void ScannerWorker()
//        {
//            while (running)
//            {
//                for (int i = 0; i < 2400; i++)
//                {
//                    if (!string.IsNullOrEmpty(ffxi.NPC.Name(i)) && ffxi.NPC.Pointer(i) != 0)
//                    {
//                        if (i != ffxi.Player.ID)
//                        {
//                            if ((ffxi.NPC.GetFlagBits(i) & GM_FLAG) == GM_FLAG)
//                            {
//                                sound.PlayLooping();
//                                fischer.Stop();
//                            }
//                        }
//                    }
//                }

//                Thread.Sleep(10);
//            }
//        }

//        private void ZoneWorker()
//        {
//            while (running)
//            {
//                if (ffxi.Player.ZoneID == (short)eZone.Mordion_Gaol)
//                {
//                    sound.PlayLooping();
//                    fischer.Stop();
//                }

//                Thread.Sleep(10);
//            }
//        }

//        private void MenuWorker()
//        {
//            while (running)
//            {
//                if (!IsSafeMenu())
//                {
//                    sound.PlayLooping();
//                    fischer.Stop();
//                }

//                Thread.Sleep(10);
//            }
//        }

//        private bool IsSafeMenu()
//        {
//            bool safe = false;

//            if (ffxi.Player.TopMenu.OpenMenuPointer == IntPtr.Zero)
//                return true;

//            foreach (string menu in menuWhiteList)
//            {
//                if (ffxi.Player.TopMenu.OpenMenu.Contains(menu) || ffxi.Player.TopMenu.OpenMenuPointer == IntPtr.Zero)
//                {
//                    safe = true;
//                    break;
//                }
//            }

//            return safe;
//        }

//        public void Start()
//        {
//            running = true;

//            zoneThread = new Thread(new ThreadStart(ZoneWorker));
//            zoneThread.IsBackground = true;
//            zoneThread.Start();

//            menuThread = new Thread(new ThreadStart(MenuWorker));
//            menuThread.IsBackground = true;
//            menuThread.Start();

//            //scannerThread = new Thread(new ThreadStart(ScannerWorker));
//            //scannerThread.IsBackground = true;
//            //scannerThread.Start();

//            this.chatLog.NewLine += new ChatLog.NewLineEventHandler(chatLog_NewLine);

//        }

//        public void Stop()
//        {
//            running = false;
//            this.chatLog.NewLine -= new ChatLog.NewLineEventHandler(chatLog_NewLine);
//        }

//        public void StopSound()
//        {
//            sound.Stop();
//        }

//    }
//}
