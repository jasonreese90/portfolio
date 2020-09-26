using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Fischer.Properties;
using WeifenLuo.WinFormsUI.Docking;
using Kunihiro.FFXi;
using Windower;

namespace Fischer
{

    public partial class BotForm : DockContent
    {

        private PolProcess[] pol;
        private XiLib ffxi;
        private Fischer fischer;

        private int lastPid = 0;
        private int loadedZone = 0;
        private int timeoutMax = 0;

        private int fishCountToday = 0;

        private CatchHistory catchHistory = new CatchHistory();
        private SkillHistory skillHistory = new SkillHistory();
        private DateTime startTime;
        private FischerSettings settings = new FischerSettings();

        public BotForm()
        {
            InitializeComponent();
            updateComboBox();

            label4.Text = label1.Text = label2.Text = label3.Text = "";
            circleProgress1.Visible = false;
            startTime = DateTime.Now;
        }

        public Fischer Fischer
        {
            get { return fischer; }
        }

       
        private int GetTodaysFishCount(List<CatchInfo> histroy)
        {
            int fishCount = 0;

            if (histroy == null)
                return 0;

            foreach (CatchInfo ci in histroy)
            {

                DateTime then = Utils.ConvertDateTime("Tokyo Standard Time", ci.TimeStamp);
                DateTime now = Utils.ConvertDateTime("Tokyo Standard Time", DateTime.Now);

                if (then.Day == now.Day && then.Month == now.Month && then.Year == now.Year)
                    ++fishCount;
            }

            return fishCount;
        }

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            circleProgress1.Value = 0;

            string fishId = "0";

            circleProgress1.Visible = false;

            if (fishCountToday >= settings.Fatigue && settings.UseFatigue)
                fischer.Stop("Hit Fatigue Limit");

            if (ffxi.Fish.TimeRemaining == 0)
                timeoutMax = 0;

            if (timeoutMax == 0 && ffxi.Fish.TimeRemaining != 0)
                timeoutMax = ffxi.Fish.TimeRemaining;

            if (ffxi.Fish.FishOn)
            {
                circleProgress1.Visible = true;

                circleProgress1.Max = (int)timeoutMax;

                circleProgress1.Value = (int)ffxi.Fish.TimeRemaining;

                circleProgress1.Text = Convert.ToString(ffxi.Fish.TimeRemaining / 60);

                fishId = ffxi.Fish.ID1.ToString("X") + ffxi.Fish.ID2.ToString("X");

                label4.Text = string.Format("HP: {0}/{1}\nID: {2} ({3})\nRod Position:{4}", ffxi.Fish.HP, ffxi.Fish.MaxHP, fishId, fischer.FishDict != null ? fischer.FishDict.GetFishName(int.Parse(fishId, NumberStyles.HexNumber)) : ""
        , ffxi.Fish.Position);

            }
            else
            {
                label4.Text = "";
            }

            label1.Text = string.Format("{0} [{1:X}]\n{2}{3}/{4}{5}\nX:{6} Y:{7} Z:{8}", ffxi.Player.Name, ffxi.Player.ID, ffxi.Player.MainJob, ffxi.Player.MainJobLevel,
                ffxi.Player.SubJob, ffxi.Player.SubJobLevel, ffxi.Player.X, ffxi.Player.Y, ffxi.Player.Z);

            label2.Text = string.Format("Rotation: {0}\nStatus: {1}\nZone: {2} ({3:X2})", (int)(ffxi.Player.Rotation * (360 / Math.PI)), ffxi.Player.Status, ResourceParser.GetZoneName(ffxi.Player.ZoneID), ffxi.Player.ZoneID);


            label3.Text = string.Format("Inventory: {0}/{1}", ffxi.Inventory.GetBagCount(Bag.Inventory), ffxi.Inventory.GetBagSize(Bag.Inventory));


            if (loadedZone != ffxi.Player.ZoneID)
            {
                LoadZoneList();

                loadedZone = ffxi.Player.ZoneID;
            }
                
            DateTime then = Utils.ConvertDateTime("Tokyo Standard Time", startTime);
            DateTime now = Utils.ConvertDateTime("Tokyo Standard Time", DateTime.Now);

            if (then.Day != now.Day)
            {
                string path = Application.StartupPath + "/history/" + ffxi.Player.Name + "_chistory.dat";
                List<CatchInfo> ci = catchHistory.Load(path);
                fishCountToday = GetTodaysFishCount(ci);

                startTime = DateTime.Now;
            }

            lblFishCaught.Text = string.Format("Fish Caught Today: {0}", fishCountToday);
        }

        private void LoadZoneList()
        {
            lvCatchList.Items.Clear();

            if (fischer.FishDict != null)
            {
                try
                {
                    fischer.FishDict.SetZone(ffxi.Player.ZoneID);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                try
                {
                    FishEntry[] fishEntries = fischer.FishDict.GetAllEntries();

                    if (fishEntries != null)
                    {
                        foreach (FishEntry f in fishEntries)
                        {
                            string[] elements = new string[2];

                            elements[0] = f.ID.ToString("X");
                            elements[1] = f.Name;

                            ListViewItem lvi = new ListViewItem(elements);
                            lvi.Checked = f.Checked;

                            lvCatchList.Items.Add(lvi);
                        }

                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }

        }

        private void updateComboBox()
        {
            pol = PolProcess.GetProcesses("pol","xiloader","edenxi","boot");

            cmbProcs.Items.Clear();

            foreach (Process p in pol)
            {
                XiLib xi = new XiLib(p.Id);
                cmbProcs.Items.Add(string.Format("{0} [{1}({2})]",xi.Player.Name,p.ProcessName, p.Id));
            }
        }

        private void ApplySettings(FischerSettings settings)
        {
            chkIgnoreList.Checked = settings.IgnoreCatchList;
            chkReleaseBig.Checked = settings.ReleaseBig;
            chkReleaseChecked.Checked = settings.ReleaseChecked;
            chkReleaseItem.Checked = settings.ReleaseItem;
            chkReleaseMonster.Checked = settings.ReleaseMonster;
            chkReleaseSmall.Checked = settings.ReleaseSmall;
            stpOnMn.Checked = settings.StopOnMonster;
            chkUseLeftRing.Checked = settings.UseLeftRing;
            chkUseRightRing.Checked = settings.UseRightRing;
            txtRecastDelay.Text = settings.RecastDelay.ToString();
            txtReelInDelay.Text = settings.ReelInDelay.ToString();
            fischer.Settings = settings;
        }

        private void SaveSettings(FischerSettings settings,string name)
        {
            settings.IgnoreCatchList = chkIgnoreList.Checked;
            settings.ReleaseBig = chkReleaseBig.Checked;
            settings.ReleaseChecked = chkReleaseChecked.Checked;
            settings.ReleaseItem = chkReleaseItem.Checked;
            settings.ReleaseMonster = chkReleaseMonster.Checked;
            settings.ReleaseSmall = chkReleaseSmall.Checked;
            settings.UseLeftRing = chkUseLeftRing.Checked;
            settings.UseRightRing = chkUseRightRing.Checked;
            settings.RecastDelay = int.Parse(txtRecastDelay.Text);
            settings.ReelInDelay = int.Parse(txtReelInDelay.Text);
            FischerSettings.Save(settings, name);
        }

        private void cmbProcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pid = pol[cmbProcs.SelectedIndex].Pid;

            if (lastPid != pid)
            {
                List<CatchInfo> catchInfo = null;

                try
                {
                    ffxi = new XiLib(pid,false);
                    fischer = new Fischer(pid, ffxi);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                fischer.NewFish += new Fischer.NewFishHandler(fischer_NewFish);
                fischer.FishCaught += new Fischer.FishCaughtHandler(fischer_FishCaught);
                fischer.SkillUp += new Fischer.SkillUpHandler(fischer_SkillUp);
                fischer.RunStateChanged += new Fischer.RunStateChangeHandler(fischer_RunStateChanged);

                uiTimer.Start();
                lastPid = pid;

               EquipmentStruct equip = ffxi.Inventory.GetEquipped();
              


                if (equip.Range.ItemIndex != 0)
                    cmbRange.Text = ResourceParser.GetWeaponName(ffxi.Inventory.GetItemByIndex((Bag)equip.Range.BagID, equip.Range.ItemIndex).Value.ID);

                if (equip.Ammo.ItemIndex != 0)
                    cmbAmmo.Text = ResourceParser.GetWeaponName(ffxi.Inventory.GetItemByIndex((Bag)equip.Ammo.BagID, equip.Ammo.ItemIndex).Value.ID);

                if (equip.LeftRing.ItemIndex != 0)
                    cmbLeftRing.Text = ResourceParser.GetArmorName(ffxi.Inventory.GetItemByIndex((Bag)equip.LeftRing.BagID, equip.LeftRing.ItemIndex).Value.ID);

                if (equip.RightRing.ItemIndex != 0)
                    cmbRightRing.Text = ResourceParser.GetArmorName(ffxi.Inventory.GetItemByIndex((Bag)equip.RightRing.BagID, equip.RightRing.ItemIndex).Value.ID);

                this.Text = ffxi.Player.Name;

                //try
                //{
                    settings = FischerSettings.Load(ffxi.Player.Name);
                //}
                //catch (Exception ex)
                //{
                //    ErrorLog.OnError(ex);
                //}

                if (settings != null)
                {
                    ApplySettings(settings);
                }
                else
                {
                    settings = new FischerSettings();
                    settings.ReleaseDelayMax = 5000;
                    settings.ReleaseDelayMin = 2000;
                    settings.ReelInPercent = 0;
                    settings.Fatigue = 200;
                    settings.UseFatigue = true;
                    settings.RecastDelay = 8000;
                    settings.NewChatLineScript = "scripts/default.lua";
                    settings.ZoneChangeScript = "scripts/default.lua";
                    settings.FullInventoryScript = "scripts/default.lua";
                    settings.NoBaitScript= "scripts/default.lua";
                    settings.NoRodScript = "scripts/default.lua";
                }

                string path = string.Format("{0}/history/{1}_chistory.dat", Application.StartupPath, ffxi.Player.Name);

                if (File.Exists(path))
                {
                    if (lvCatchHistory.Items.Count > 0)
                        lvCatchHistory.Items.Clear();

                    //try
                    //{
                        catchInfo = catchHistory.Load(path);

                        foreach (CatchInfo ci in catchInfo)
                        {
                            string[] items = new string[3];

                            items[0] = ci.ID.ToString("X");
                            items[1] = ci.Name;
                            items[2] = ci.TimeStamp.ToString();

                            try
                            {
                                lvCatchHistory.Items.Add(new ListViewItem(items));
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.OnError(ex);
                            }

                        }
                    //}
                    //catch (Exception ex)
                    //{
                    //    ErrorLog.OnError(ex);
                    //}

                    //try
                    //{
                        lvCatchHistory.Items[lvCatchHistory.Items.Count - 1].EnsureVisible();
                    //}
                    //catch (Exception ex)
                    //{
                    //    ErrorLog.OnError(ex);
                    //}
                }


                string path2 = string.Format("{0}/history/{1}_shistory.dat", Application.StartupPath, ffxi.Player.Name);

                if (File.Exists(path2))
                {
                    if (lvSkillHistory.Items.Count > 0)
                        lvSkillHistory.Items.Clear();

                    //try
                    //{
                        List<SkillInfo> skillInfo = skillHistory.Load(path2);

                        foreach (SkillInfo si in skillInfo)
                        {
                            string[] items = new string[2];

                            items[0] = si.Description;
                            items[1] = si.TimeStamp.ToString();

                            //try
                            //{
                                lvSkillHistory.Items.Add(new ListViewItem(items));
                            //}
                            //catch (Exception ex)
                            //{
                            //    ErrorLog.OnError(ex);
                            //}
                        }
                    //}
                    //catch (Exception ex)
                    //{
                    //    ErrorLog.OnError(ex);
                    //}

                    try
                    {
                        lvSkillHistory.Items[lvSkillHistory.Items.Count - 1].EnsureVisible();
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.OnError(ex);
                    }
                }

                try
                {
                    if (catchHistory != null)
                        fishCountToday = GetTodaysFishCount(catchInfo);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                updateComboBox();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ffxi.Chat.SendString(string.Format("/equip range \"{0}\"", cmbRange.Text));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }


            if (!string.IsNullOrEmpty(cmbRange.Text))
            {
                string path = string.Format("{0}/fish/{1}.xml", Application.StartupPath, cmbRange.Text);

                try
                {
                    if (fischer.FishDict == null)
                        fischer.FishDict = new FishDictionary(ffxi.Player.ZoneID, path);

                    if (!File.Exists(path))
                        fischer.FishDict.CreateNewFile(path, ffxi.Player.ZoneID);

                    fischer.FishDict.SetFile(path);

                    if (!toolStripButton2.Enabled)
                        toolStripButton2.Enabled = true;

                    LoadZoneList();
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ffxi.Chat.SendString(string.Format("/equip ammo \"{0}\"", cmbAmmo.Text));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!fischer.IsRunning)
            {
                try
                {
                    EquipmentStruct equip = ffxi.Inventory.GetEquipped();

                    if (equip.Ammo.ItemIndex != 0 && equip.Range.ItemIndex != 0)
                    {
                        fischer.Start();
                        fischer.BaitID = ffxi.Inventory.GetItemByIndex((Bag)equip.Ammo.BagID, equip.Ammo.ItemIndex).Value.ID;
                        fischer.RodID = ffxi.Inventory.GetItemByIndex((Bag)equip.Range.BagID, equip.Range.ItemIndex).Value.ID;
                        fischer.Settings = settings;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
            else
            {
                try
                {
                    fischer.Stop();
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.IgnoreCatchList = chkIgnoreList.Checked;
                settings.IgnoreCatchList = chkIgnoreList.Checked;

                if (chkIgnoreList.CheckState == CheckState.Checked)
                {
                    fischer.ReleaseChecked = false;
                    chkReleaseChecked.Checked = false;
                    settings.ReleaseChecked = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.ReleaseChecked = chkReleaseChecked.Checked;
                settings.ReleaseChecked = chkReleaseChecked.Checked;

                if (chkReleaseChecked.CheckState == CheckState.Checked)
                {
                    fischer.IgnoreCatchList = false;
                    chkIgnoreList.Checked = false;
                    settings.IgnoreCatchList = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.ReleaseBig = chkReleaseBig.Checked;
                settings.ReleaseBig = chkReleaseBig.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.ReleaseSmall = chkReleaseSmall.Checked;
                settings.ReleaseSmall = chkReleaseSmall.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.ReleaseItem = chkReleaseItem.Checked;
                settings.ReleaseItem = chkReleaseItem.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.ReleaseMonster = chkReleaseMonster.Checked;
                settings.ReleaseMonster = chkReleaseMonster.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.UseRightRing = chkUseRightRing.Checked;
                settings.UseRightRing = chkUseRightRing.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.UseLeftRing = chkUseLeftRing.Checked;
                settings.UseLeftRing = chkUseLeftRing.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void fischer_FishCaught(object sender, FishCaughtEventArgs e)
        {
            CatchInfo ci = new CatchInfo();
            ci.ID = e.ID;
            ci.Name = e.Name;
            ci.TimeStamp = DateTime.Now;

            try
            {
                catchHistory.Add(ci);
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            string[] items = new string[3];

            items[0] = e.ID.ToString("X");
            items[1] = e.Name;
            items[2] = ci.TimeStamp.ToString();

            try
            {
                Invoke(new MethodInvoker(delegate { lvCatchHistory.Items.Add(new ListViewItem(items)); }));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            try
            {
                Invoke(new MethodInvoker(delegate { lvCatchHistory.Items[lvCatchHistory.Items.Count - 1].EnsureVisible(); }));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            try
            {
                catchHistory.Save(string.Format("{0}/history/{1}_chistory.dat", Application.StartupPath, ffxi.Player.Name));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            ++fishCountToday;
        }

        private void fischer_RunStateChanged(object sender, RunStateChangeEventArgs e)
        {
            if (e.Running)
            {
                try
                {
                    Invoke(new MethodInvoker(delegate { this.toolStripButton2.Image = Resources.Close_2; }));
                    notifyIcon1.ShowBalloonTip(1000, "Starting", string.Format("{0}: Fischer Starting\n{1}", ffxi.Player.Name,e.Message), ToolTipIcon.Info);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
            else
            {
                try
                {
                    Invoke(new MethodInvoker(delegate { this.toolStripButton2.Image = Resources.Actions_media_playback_start; }));
                    notifyIcon1.ShowBalloonTip(1000, "Stopping", string.Format("{0}: Fischer Stopping\n{1}", ffxi.Player.Name,e.Message), ToolTipIcon.Info);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                try
                {

                    ffxi.Keyboard.SetKey(Kunihiro.FFXi.Key.NumPad6, false);
                    ffxi.Keyboard.SetKey(Kunihiro.FFXi.Key.NumPad4, false);
                    ffxi.Keyboard.SetKey(Kunihiro.FFXi.Key.Enter, false);
                    ffxi.Keyboard.SetKey(Kunihiro.FFXi.Key.Escape, false);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void fischer_SkillUp(object sender, SkillUpEventArgs e)
        {
            SkillInfo si = new SkillInfo();

            si.Description = e.Description;
            si.TimeStamp = DateTime.Now;

            try
            {
                skillHistory.Add(si);
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            string[] items = new string[2];

            items[0] = e.Description;
            items[1] = si.TimeStamp.ToString();

            try
            {
                Invoke(new MethodInvoker(delegate { lvSkillHistory.Items.Add(new ListViewItem(items)); }));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            try
            {
                Invoke(new MethodInvoker(delegate { lvSkillHistory.Items[lvSkillHistory.Items.Count - 1].EnsureVisible(); }));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            try
            {
                skillHistory.Save(string.Format("{0}/history/{1}_shistory.dat", Application.StartupPath, ffxi.Player.Name));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void fischer_NewFish(object sender, NewFishEventArgs e)
        {
            try
            {
                fischer.FishDict.WriteFish(e.ID, e.Name);
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            string[] elements = new string[2];

            elements[0] = e.ID.ToString("X");
            elements[1] = e.Name;
            try
            {
                Invoke(new MethodInvoker(delegate { lvCatchList.Items.Add(new ListViewItem(elements)); }));
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void lvCatchList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            List<CatchListEntry> catchEntries = new List<CatchListEntry>();
         
            foreach (ListViewItem lvi in lvCatchList.Items)
            {
                CatchListEntry cle = new CatchListEntry();
                cle.Checked = lvi.Checked;

                try
                {
                    cle.ID = int.Parse(lvi.Text, NumberStyles.HexNumber);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(Errors.ERROR_FORMAT_INT, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                try
                {
                    catchEntries.Add(cle);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
                
            }

            try
            {
                fischer.CatchList = catchEntries;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            try
            {
                int id = int.Parse(e.Item.Text, NumberStyles.HexNumber);
                fischer.FishDict.SetChecked(id, e.Item.Checked);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(Errors.ERROR_FORMAT_INT, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRecastDelay.Text))
            {
                try
                {
                    fischer.RecastDelay = int.Parse(txtRecastDelay.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(Errors.ERROR_FORMAT_INT, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                try
                {
                    settings.RecastDelay = int.Parse(txtRecastDelay.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(Errors.ERROR_FORMAT_INT, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber) && e.KeyChar != (Char)Keys.Back;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReelInDelay.Text))
            {
                try
                {
                    fischer.ReelInDelay = int.Parse(txtReelInDelay.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(Errors.ERROR_FORMAT_INT, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

                try
                {
                    settings.ReelInDelay = int.Parse(txtReelInDelay.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(Errors.ERROR_FORMAT_INT, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber) && e.KeyChar != (Char)Keys.Back;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.RightRing = cmbRightRing.Text;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.LeftRing = cmbLeftRing.Text;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        public void OnClosing()
        {
            try
            {
                FischerSettings.Save(settings, ffxi.Player.Name);
                fischer.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        public void ShowSettings()
        {
            try
            {
                Settings s = new Settings(settings, ffxi);
                s.ShowDialog();
                settings = FischerSettings.Load(ffxi.Player.Name);
                fischer.Settings = settings;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void lvCatchList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            fischer.Pause = !fischer.Pause;
        }

        private void BotForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbProcs_Click(object sender, EventArgs e)
        {

        }

        private void StpOnMn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fischer.StopOnMonster = stpOnMn.Checked;
                settings.StopOnMonster = stpOnMn.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }
    }

}