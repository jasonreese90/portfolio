// -----------------------------------------------------------------------
// <copyright file="Fischer.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fischer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Kunihiro.FFXi;
    using Windower;    /// <summary>
                            /// TODO: Update summary.
                            /// </summary>
    public class Fischer
    {
        /// <summary>
        ///  How long to wait before using a ring when it wears off.
        /// </summary>
        private const int RING_WAIT = 8000;
        /// <summary>
        ///  How long to wait before using a second ring.
        /// </summary>
        private const int RING2_WAIT = 13000;
        /// <summary>
        /// How long to wait on after an unsuccesful fish attempt.
        /// </summary>
        private const int FISH_RETRY = 3000;

        private Thread fishThread;
        private Thread zoneThread;
        private Thread gearThread;
        private Thread reelThread;
        private XiLib ffxi;
        private ChatLog chatLog;
        private FishDictionary fishDict;
        //private Alarm alarm;

        private bool ignoreCatchList = false;
        private bool releaseChecked = false;
        private bool releaseBig = false;
        private bool releaseSmall = false;
        private bool releaseMonster = false;
        private bool releaseItem = false;
        private bool release = false;
        private bool useRightRing = false;
        private bool useLeftRing = false;
        private bool isRunning = false;
        private bool stopOnMonster = false;
        private bool pause = false;

        private int recastDelay = 8000;
        private int reelInDelay = 0;
        private int rodID = 0;
        private int baitID = 0;
        private int id = 0;

        private string rightRing = "";
        private string leftRing = "";   

        private FischerSettings settings;

        private LuaScript script;
        private LuaScript fishScript; //thread script

        private List<CatchListEntry> catchList = new List<CatchListEntry>();

        /// <summary>
        ///  TODO: Update summary.
        /// </summary>
        /// <param name="pid">Process ID to attach to.</param>
        public Fischer(int pid,XiLib ffxi)
        {
                this.ffxi = ffxi;


                this.script = new LuaScript(ffxi, this);
                this.fishScript = new LuaScript(ffxi, this);
                this.settings = new FischerSettings();

                this.chatLog = new ChatLog(ffxi);
                this.chatLog.NewLine += new ChatLog.NewLineEventHandler(chatLog_NewLine);
                this.chatLog.Listen();

                //this.alarm = new Alarm(chatLog, this, ffxi);
        }

        public delegate void NewFishHandler(object sender, NewFishEventArgs e);
        public delegate void FishCaughtHandler(object sender, FishCaughtEventArgs e);
        public delegate void SkillUpHandler(object sender, SkillUpEventArgs e);
        public delegate void RunStateChangeHandler(object sender, RunStateChangeEventArgs e);

        public event NewFishHandler NewFish;
        public event FishCaughtHandler FishCaught;
        public event SkillUpHandler SkillUp;
        public event RunStateChangeHandler RunStateChanged;

        //public Alarm Alarm
        //{
        //    get { return alarm; }
        //}

        public bool IgnoreCatchList
        {
            get { return this.ignoreCatchList; }
            set { this.ignoreCatchList = value; }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.isRunning = value; }
        }

        public bool ReleaseChecked
        {
            get { return this.releaseChecked; }
            set { this.releaseChecked = value; }
        }

        public bool ReleaseBig
        {
            get { return this.releaseBig; }
            set { this.releaseBig = value; }
        }

        public bool ReleaseSmall
        {
            get { return this.releaseSmall; }
            set { this.releaseSmall = value; }
        }

        public bool ReleaseMonster
        {
            get { return this.releaseMonster; }
            set { this.releaseMonster = value; }
        }

        public bool ReleaseItem
        {
            get { return this.releaseItem; }
            set { this.releaseItem = value; }
        }

        public bool Release
        {
            get { return this.release; }
            set { this.release = value; }
        }

        public bool UseRightRing
        {
            get { return this.useRightRing; }
            set { this.useRightRing = value; }
        }

        public bool UseLeftRing
        {
            get { return this.useLeftRing; }
            set { this.useLeftRing = value; }
        }

        public bool StopOnMonster
        {
            get { return this.stopOnMonster; }
            set { this.stopOnMonster = value; }
        }

        public bool Pause
        {
            get { return this.pause; }
            set { pause = value; }
        }

        public int RecastDelay
        {
            get { return recastDelay; }
            set { recastDelay = value; }
        }

        public int ReelInDelay
        {
            get { return reelInDelay; }
            set { reelInDelay = value; }
        }

        public int BaitID
        {
            get { return baitID; }
            set { baitID = value; }
        }

        public int RodID
        {
            get { return rodID; }
            set { rodID = value; }
        }

        public string RightRing
        {
            get { return rightRing; }
            set { rightRing = value; }
        }

        public string LeftRing
        {
            get { return leftRing; }
            set { leftRing = value; }
        }


        public FischerSettings Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        public List<CatchListEntry> CatchList
        {
            get { return catchList; }
            set { catchList = value; }
        }

        public FishDictionary FishDict
        {
            get { return fishDict; }
            set { fishDict = value; }
        }

        /// <summary>
        ///  TODO: Update summary.
        /// </summary>
        public void Start()
        {
            if (!isRunning)
            {
                if (this.fishThread == null)
                {
                    this.isRunning = true;

                    this.fishThread = new Thread(new ThreadStart(fishWorker));
                    this.fishThread.IsBackground = true;
                    this.fishThread.Start();

                    this.zoneThread = new Thread(new ThreadStart(zoneWorker));
                    this.zoneThread.IsBackground = true;
                    this.zoneThread.Start();

                    this.gearThread = new Thread(new ThreadStart(gearWorker));
                    this.gearThread.IsBackground = true;
                    this.gearThread.Start();

                    this.reelThread = new Thread(new ThreadStart(reelWorker));
                    this.reelThread.IsBackground = true;

                    // this.alarm.Start();


                    RunStateChanged(this, new RunStateChangeEventArgs(isRunning));

                    try
                    {
                        if (script.Loaded)
                            script.OnStart();

                        if (fishScript.Loaded)
                            fishScript.OnStart();
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.OnError(ex);
                    }
                }
            }
        }

        public void Stop()
        {
            this.Stop("");
        }
        /// <summary>
        ///  TODO: Update summary.
        /// </summary>
        public void Stop(string message)
        {
            if (isRunning)
            {
                isRunning = false;
                this.fishThread = null;
                RunStateChanged(this, new RunStateChangeEventArgs(isRunning,message));
                // this.alarm.Stop();

                try
                {
                    if (script.Loaded)
                        script.OnStop();

                    if (fishScript.Loaded)
                        fishScript.OnStop();
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void fishWorker()
        {
            while (isRunning)
            {
                if (!isRunning)
                    break;

                bool fishing = ffxi.Fish.FishOn || ffxi.Player.Status == Status.Fishing;

                if (!fishing && !pause)
                {
                    Thread.Sleep(recastDelay);
                }

                if (ffxi.Inventory.GetBagCount(Bag.Inventory) == ffxi.Inventory.GetBagSize(Bag.Inventory))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(settings.FullInventoryScript))
                        {
                            fishScript.Load(settings.FullInventoryScript);
                            fishScript.OnFullInventory();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.OnError(ex);
                    }
                    //break;
                }


                if (!isRunning)
                    break;

                if (!pause)
                {
                    if (useRightRing && !useLeftRing && !fishing)
                    {
                        if (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) == 0)
                        {
                            Thread.Sleep(RING_WAIT);

                            if (!string.IsNullOrEmpty(rightRing))
                            {
                                ffxi.Chat.SendString(string.Format("/item \"{0}\" <me>", rightRing));

                                while (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) != 1)
                                    Thread.Sleep(1);
                            }
                        }
                    }

                    if (useLeftRing && !useRightRing && !fishing)
                    {
                        if (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) == 0)
                        {
                            if (!string.IsNullOrEmpty(leftRing))
                            {
                                ffxi.Chat.SendString(string.Format("/item \"{0}\" <me>", leftRing));

                                while (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) != 1)
                                    Thread.Sleep(1);
                            }
                        }
                    }


                    if (useRightRing && useLeftRing && !fishing)
                    {
                        if (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) == 0)
                        {
                            if (!string.IsNullOrEmpty(rightRing))
                            {
                                ffxi.Chat.SendString(string.Format("/item \"{0}\" <me>", rightRing));

                                while (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) != 1)
                                    Thread.Sleep(1);

                                Thread.Sleep(RING2_WAIT);
                            }

                            if (!string.IsNullOrEmpty(leftRing))
                            {
                                ffxi.Chat.SendString(string.Format("/item \"{0}\" <me>", leftRing));

                                while (ffxi.Player.GetActiveBuffCount(Buff.Enchantment) != 2)
                                    Thread.Sleep(1);
                            }
                        }
                    }

                    while (ffxi.Player.Status != Status.Fishing && !ffxi.Fish.FishOn)
                    {
                        if (!isRunning)
                            break;

                        ffxi.Chat.SendString("/fish");
                        Thread.Sleep(FISH_RETRY);
                    }


                    while (!ffxi.Fish.FishOn)
                    {
                        if (!isRunning)
                            break;

                        if (ffxi.Player.Status == Status.Standing || ffxi.Player.Status == Status.LostCatch)  //didn't catch anything
                            break;

                        Thread.Sleep(1);
                    }


                    //while (ffxi.Player.Status == eActivity.FishBite)
                    //{
                    //    int fishId = Utils.GetID(ffxi.Fish.ID.ID1, ffxi.Fish.ID.ID2, ffxi.Fish.ID.ID3);

                    //    if (id != fishId)
                    //        id = fishId;

                    //    if (!isRunning)
                    //        break;

                    //    if (release)
                    //    {
                    //        Utils.Wait(settings.ReleaseDelayMin, settings.ReleaseDelayMax);


                    //        while (ffxi.Player.Status == eActivity.FishBite)
                    //        {
                    //            ffxi.Keyboard.SendKey(Key.EscapeKey);
                    //            Thread.Sleep(1000);
                    //        }

                    //        release = false;
                    //    }



                    //    if (ignoreCatchList)
                    //        FightFish(ffxi.Fish.RodPosition);
                    //    else
                    //    {
                    //        if (releaseChecked)
                    //        {
                    //            if (!CatchCurrentFish(id)) //&& ListViewContainsFish(id))
                    //            {
                    //                if (!reelThread.IsAlive)
                    //                {
                    //                    this.reelThread = new Thread(new ThreadStart(reelWorker));
                    //                    this.reelThread.IsBackground = true;
                    //                    reelThread.Start();
                    //                }
                    //            }
                    //            else
                    //            {

                    //                ffxi.Keyboard.SendKey(Key.EscapeKey);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if (CatchCurrentFish(id))
                    //            {
                    //                if (!reelThread.IsAlive)
                    //                {
                    //                    this.reelThread = new Thread(new ThreadStart(reelWorker));
                    //                    this.reelThread.IsBackground = true;
                    //                    reelThread.Start();
                    //                }
                    //            }
                    //            else
                    //            {
                    //                Utils.Wait(settings.ReleaseDelayMin, settings.ReleaseDelayMax);
                    //                ffxi.Keyboard.SendKey(Key.EscapeKey);
                    //            }
                    //        }
                    //    }

                    //    if (ffxi.Player.Status == eActivity.FishBite)
                    //    {
                    //        if (((ffxi.Fish.HP * 100) / ffxi.Fish.MaxHP <= settings.ReelInPercent))
                    //        {
                    //            Thread.Sleep(reelInDelay);
                    //            ffxi.Keyboard.SendKey(Key.EnterKey);
                    //        }
                    //    }
                    //}


                    while (ffxi.Fish.FishOn)
                    {
                        int fishId = Utils.GetID((int)this.ffxi.Fish.ID1, (int)this.ffxi.Fish.ID2, (int)this.ffxi.Fish.ID3);
                        if (this.id != fishId)
                        {
                            this.id = fishId;
                        }
                        if (!this.isRunning)
                        {
                            break;
                        }
                        if (this.release)
                        {
                            Utils.Wait(this.settings.ReleaseDelayMin, this.settings.ReleaseDelayMax);
                            while (ffxi.Fish.FishOn)
                            {
                                this.ffxi.Keyboard.SendKey(Kunihiro.FFXi.Key.Escape);
                                Thread.Sleep(0x3e8);
                            }
                            this.release = false;
                        }
                        if (this.ignoreCatchList)
                        {
                            this.FightFish(this.ffxi.Fish.Position);
                        }
                        else if (this.releaseChecked)
                        {
                            if (!this.CatchCurrentFish(this.id))
                            {
                                this.FightFish(this.ffxi.Fish.Position);
                            }
                            else
                            {
                                this.ffxi.Keyboard.SendKey(Kunihiro.FFXi.Key.Escape);
                            }
                        }
                        else if (this.CatchCurrentFish(this.id))
                        {
                            this.FightFish(this.ffxi.Fish.Position);
                        }
                        else
                        {
                            Utils.Wait(this.settings.ReleaseDelayMin, this.settings.ReleaseDelayMax);
                            this.ffxi.Keyboard.SendKey(Kunihiro.FFXi.Key.Escape);
                        }
                        if ((ffxi.Fish.FishOn) && (((this.ffxi.Fish.HPDisplay * 100) / this.ffxi.Fish.MaxHP) <= this.settings.ReelInPercent))
                        {
                            Thread.Sleep(this.reelInDelay);
                            this.ffxi.Keyboard.SendKey(Kunihiro.FFXi.Key.Enter);
                        }
                    }

                    //ffxi.Keyboard.SetKey(KeyCode.EnterKey, false);
                    //ffxi.Keyboard.SetKey(KeyCode.EscapeKey, false);
                    Thread.Sleep(1);
                }
            }
        }


        private void zoneWorker()
        {
            int startZone = ffxi.Player.ZoneID;

            while (isRunning)
            {
                if (ffxi.Player.ZoneID != startZone)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(settings.ZoneChangeScript))
                        {
                            fishScript.Load(settings.ZoneChangeScript);
                            fishScript.OnZoneChange(ffxi.Player.ZoneID);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.OnError(ex);
                    }
                }

                Thread.Sleep(1);
            }
        }

        private void gearWorker()
        {
            while (isRunning)
            {
                if (ffxi.Inventory.GetEquipped().Ammo.ItemIndex == 0)
                {
                    if (ffxi.Inventory.HasItem(baitID))
                    {
                        while (ffxi.Player.Status != Status.Standing)
                            Thread.Sleep(1);

                        ffxi.Chat.SendString(string.Format("/equip ammo \"{0}\"", ResourceParser.GetWeaponName(baitID)));
                        Thread.Sleep(1000);
                    }
                    else

                        if (string.IsNullOrEmpty(settings.NoBaitScript))
                        {
                            this.Stop("Out of Bait");
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(settings.NoBaitScript))
                                {
                                    fishScript.Load(settings.NoBaitScript);
                                    fishScript.OnNoBait();
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.OnError(ex);
                            }
                        }
                }

                if (ffxi.Inventory.GetEquipped().Range.ItemIndex == 0)
                {
                    if (ffxi.Inventory.HasItem(rodID))
                    {
                        while (ffxi.Player.Status != Status.Standing)
                            Thread.Sleep(1);

                        ffxi.Chat.SendString(string.Format("/equip range \"{0}\"", ResourceParser.GetWeaponName(rodID)));
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(settings.NoRodScript))
                        {
                            this.Stop("No Rod");
                            break;
                        }
                        else
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(settings.NoRodScript))
                                {
                                    fishScript.Load(settings.NoRodScript);
                                    fishScript.OnNoRod();
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.OnError(ex);
                            }
                        }
                    }
                }

                Thread.Sleep(1);
            }
        }

        private void reelWorker()
        {
            while (ffxi.Fish.FishOn)
            {
                FightFish(ffxi.Fish.Position);
                Thread.Sleep(100);
            }
        }

        private void chatLog_NewLine(object sender, NewLineEventArgs e)
        {
            if (e.Text.Contains("Something caught the hook!!!"))
            {
                if (releaseBig)
                    release = true;
            }
            else  if (e.Text.Contains("Something caught the hook!"))
            {
                if (releaseSmall)
                    release = true;
            }
            else if (e.Text.Contains("You feel something pulling at your line."))
            {
                if (releaseItem)
                    release = true;
            }
            else if (e.Text.Contains("Something clamps onto your line ferociously!"))
            {
                if (releaseMonster)
                    release = true;
            }

            else if(e.Text.Contains(string.Format("{0} caught a monster!",ffxi.Player.Name)))
            {
                if(stopOnMonster)
                {
                    this.Stop("Caught a monster.");
                }
            }

            else if ((e.Text.Contains(string.Format("{0} caught ", ffxi.Player.Name))))
            {
                string cleaned = e.Text.Replace(string.Format("{0} caught an ", ffxi.Player.Name), "").Replace(string.Format("{0} caught a ", ffxi.Player.Name), "").Replace(string.Format("{0} caught ", ffxi.Player.Name), "").Replace(".", "").
          Replace("!", "").Replace("\0,", "").Replace("\x1E", "").TrimStart(' ');

                string[] split = cleaned.Split(',');

                cleaned = Regex.Replace(split[0], @"\b(\w)", m => m.Value.ToUpper());

                if (string.IsNullOrEmpty(fishDict.GetFishName(id)))
                {
                    NewFish(this, new NewFishEventArgs(id, cleaned));
                }

                if (!e.Text.Contains("but cannot carry any more items."))
                {
                    FishCaught(this, new FishCaughtEventArgs(id, cleaned));
                }
            }
            else if (e.Text.Contains(string.Format("{0}'s fishing skill rises ", ffxi.Player.Name)))
            {
                string cleaned = e.Text.Replace(string.Format("{0}'s fishing skill rises ", ffxi.Player.Name), "").
                    Replace("!", "");

                cleaned = string.Format("Skill rises {0}", cleaned);

                SkillUp(this, new SkillUpEventArgs(cleaned));
            }


            else if (e.Text.Contains(string.Format("{0}'s fishing skill reaches ", ffxi.Player.Name)))
            {
                string cleaned = e.Text.Replace(string.Format("{0}'s fishing skill reaches ", ffxi.Player.Name), "").Replace(".", "").
                    Replace("!", "");

                cleaned = string.Format("Skill reaches {0}", cleaned);

                SkillUp(this, new SkillUpEventArgs(cleaned));
            }


            if (!string.IsNullOrEmpty(e.Text))
            {
                try
                {
                    if (!string.IsNullOrEmpty(settings.NewChatLineScript))
                    {
                        script.Load(settings.NewChatLineScript);
                        script.OnNewChatLine(e.Text);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void FightFish(RodPosition pos)
        {
            if (pos == RodPosition.Left)
                ffxi.Keyboard.SendKey(Kunihiro.FFXi.Key.NumPad6);
            else if (pos == RodPosition.Right)
                ffxi.Keyboard.SendKey(Kunihiro.FFXi.Key.NumPad4);

            ffxi.Keyboard.SetKey(Kunihiro.FFXi.Key.NumPad6, false);
            ffxi.Keyboard.SetKey(Kunihiro.FFXi.Key.NumPad4, false);
        }

        private bool CatchCurrentFish(int id)
        {
            if (catchList == null)
                return false;

            foreach (CatchListEntry c in catchList)
            {
                if (c.ID == id && c.Checked)
                    return true;
            }

            return false;
        }

        private bool CatchListContainsFish(int id)
        {
            if (catchList == null)
                return false;

            foreach (CatchListEntry c in catchList)
            {
                if (c.ID == id)
                    return true;
            }

            return false;
        }

    }
}
