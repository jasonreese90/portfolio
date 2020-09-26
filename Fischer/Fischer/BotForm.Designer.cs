namespace Fischer
{
    partial class BotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFishCaught = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.circleProgress1 = new WindowsFormsApplication104.CircleProgress();
            this.grpCatchHistory = new System.Windows.Forms.GroupBox();
            this.lvCatchHistory = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmbProcs = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.uiTimer = new System.Windows.Forms.Timer(this.components);
            this.grpCatchList = new System.Windows.Forms.GroupBox();
            this.lvCatchList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpGear = new System.Windows.Forms.GroupBox();
            this.chkUseLeftRing = new System.Windows.Forms.CheckBox();
            this.chkUseRightRing = new System.Windows.Forms.CheckBox();
            this.lblLeftRing = new System.Windows.Forms.Label();
            this.lblRightRing = new System.Windows.Forms.Label();
            this.cmbLeftRing = new System.Windows.Forms.ComboBox();
            this.cmbRightRing = new System.Windows.Forms.ComboBox();
            this.lblAmmo = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.cmbAmmo = new System.Windows.Forms.ComboBox();
            this.cmbRange = new System.Windows.Forms.ComboBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.stpOnMn = new System.Windows.Forms.CheckBox();
            this.chkReleaseMonster = new System.Windows.Forms.CheckBox();
            this.chkReleaseItem = new System.Windows.Forms.CheckBox();
            this.chkReleaseSmall = new System.Windows.Forms.CheckBox();
            this.chkReleaseBig = new System.Windows.Forms.CheckBox();
            this.chkReleaseChecked = new System.Windows.Forms.CheckBox();
            this.lblReelInDelay = new System.Windows.Forms.Label();
            this.txtReelInDelay = new System.Windows.Forms.TextBox();
            this.lblRecastDelay = new System.Windows.Forms.Label();
            this.txtRecastDelay = new System.Windows.Forms.TextBox();
            this.chkIgnoreList = new System.Windows.Forms.CheckBox();
            this.grpSkillHistory = new System.Windows.Forms.GroupBox();
            this.lvSkillHistory = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpCatchHistory.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpCatchList.SuspendLayout();
            this.grpGear.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpSkillHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFishCaught});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1057, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFishCaught
            // 
            this.lblFishCaught.BackColor = System.Drawing.SystemColors.Control;
            this.lblFishCaught.Name = "lblFishCaught";
            this.lblFishCaught.Size = new System.Drawing.Size(108, 17);
            this.lblFishCaught.Text = "Fish Caught Today:";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Controls.Add(this.circleProgress1);
            this.grpInfo.ForeColor = System.Drawing.Color.White;
            this.grpInfo.Location = new System.Drawing.Point(10, 33);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grpInfo.Size = new System.Drawing.Size(242, 159);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // circleProgress1
            // 
            this.circleProgress1.BorderColor = System.Drawing.Color.White;
            this.circleProgress1.CenterColor = System.Drawing.Color.Black;
            this.circleProgress1.CircleColor = System.Drawing.Color.DarkRed;
            this.circleProgress1.Location = new System.Drawing.Point(162, 78);
            this.circleProgress1.Max = 100;
            this.circleProgress1.Min = 0;
            this.circleProgress1.Name = "circleProgress1";
            this.circleProgress1.Size = new System.Drawing.Size(75, 76);
            this.circleProgress1.TabIndex = 0;
            this.circleProgress1.Value = 0;
            // 
            // grpCatchHistory
            // 
            this.grpCatchHistory.Controls.Add(this.lvCatchHistory);
            this.grpCatchHistory.ForeColor = System.Drawing.Color.White;
            this.grpCatchHistory.Location = new System.Drawing.Point(256, 34);
            this.grpCatchHistory.Margin = new System.Windows.Forms.Padding(2);
            this.grpCatchHistory.Name = "grpCatchHistory";
            this.grpCatchHistory.Padding = new System.Windows.Forms.Padding(2);
            this.grpCatchHistory.Size = new System.Drawing.Size(256, 159);
            this.grpCatchHistory.TabIndex = 3;
            this.grpCatchHistory.TabStop = false;
            this.grpCatchHistory.Text = "Catch History";
            // 
            // lvCatchHistory
            // 
            this.lvCatchHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvCatchHistory.FullRowSelect = true;
            this.lvCatchHistory.GridLines = true;
            this.lvCatchHistory.Location = new System.Drawing.Point(3, 14);
            this.lvCatchHistory.Margin = new System.Windows.Forms.Padding(2);
            this.lvCatchHistory.Name = "lvCatchHistory";
            this.lvCatchHistory.Size = new System.Drawing.Size(250, 141);
            this.lvCatchHistory.TabIndex = 4;
            this.lvCatchHistory.UseCompatibleStateImageBehavior = false;
            this.lvCatchHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 104;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Time";
            this.columnHeader6.Width = 99;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbProcs,
            this.toolStripButton1,
            this.toolStripSeparator6,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1057, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmbProcs
            // 
            this.cmbProcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcs.Name = "cmbProcs";
            this.cmbProcs.Size = new System.Drawing.Size(200, 27);
            this.cmbProcs.SelectedIndexChanged += new System.EventHandler(this.cmbProcs_SelectedIndexChanged);
            this.cmbProcs.Click += new System.EventHandler(this.cmbProcs_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Fischer.Properties.Resources.arrow_refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::Fischer.Properties.Resources.Actions_media_playback_start;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "Power";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // uiTimer
            // 
            this.uiTimer.Tick += new System.EventHandler(this.uiTimer_Tick);
            // 
            // grpCatchList
            // 
            this.grpCatchList.Controls.Add(this.lvCatchList);
            this.grpCatchList.ForeColor = System.Drawing.Color.White;
            this.grpCatchList.Location = new System.Drawing.Point(12, 349);
            this.grpCatchList.Margin = new System.Windows.Forms.Padding(2);
            this.grpCatchList.Name = "grpCatchList";
            this.grpCatchList.Padding = new System.Windows.Forms.Padding(2);
            this.grpCatchList.Size = new System.Drawing.Size(218, 138);
            this.grpCatchList.TabIndex = 4;
            this.grpCatchList.TabStop = false;
            this.grpCatchList.Text = "Catch List";
            // 
            // lvCatchList
            // 
            this.lvCatchList.CheckBoxes = true;
            this.lvCatchList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.columnHeader1});
            this.lvCatchList.FullRowSelect = true;
            this.lvCatchList.GridLines = true;
            this.lvCatchList.Location = new System.Drawing.Point(5, 15);
            this.lvCatchList.Margin = new System.Windows.Forms.Padding(2);
            this.lvCatchList.Name = "lvCatchList";
            this.lvCatchList.Size = new System.Drawing.Size(207, 117);
            this.lvCatchList.TabIndex = 1;
            this.lvCatchList.UseCompatibleStateImageBehavior = false;
            this.lvCatchList.View = System.Windows.Forms.View.Details;
            this.lvCatchList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvCatchList_ItemChecked);
            this.lvCatchList.SelectedIndexChanged += new System.EventHandler(this.lvCatchList_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 105;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 133;
            // 
            // grpGear
            // 
            this.grpGear.Controls.Add(this.chkUseLeftRing);
            this.grpGear.Controls.Add(this.chkUseRightRing);
            this.grpGear.Controls.Add(this.lblLeftRing);
            this.grpGear.Controls.Add(this.lblRightRing);
            this.grpGear.Controls.Add(this.cmbLeftRing);
            this.grpGear.Controls.Add(this.cmbRightRing);
            this.grpGear.Controls.Add(this.lblAmmo);
            this.grpGear.Controls.Add(this.lblRange);
            this.grpGear.Controls.Add(this.cmbAmmo);
            this.grpGear.Controls.Add(this.cmbRange);
            this.grpGear.ForeColor = System.Drawing.Color.White;
            this.grpGear.Location = new System.Drawing.Point(260, 197);
            this.grpGear.Margin = new System.Windows.Forms.Padding(2);
            this.grpGear.Name = "grpGear";
            this.grpGear.Padding = new System.Windows.Forms.Padding(2);
            this.grpGear.Size = new System.Drawing.Size(252, 148);
            this.grpGear.TabIndex = 5;
            this.grpGear.TabStop = false;
            this.grpGear.Text = "Gear";
            // 
            // chkUseLeftRing
            // 
            this.chkUseLeftRing.AutoSize = true;
            this.chkUseLeftRing.Location = new System.Drawing.Point(181, 83);
            this.chkUseLeftRing.Margin = new System.Windows.Forms.Padding(2);
            this.chkUseLeftRing.Name = "chkUseLeftRing";
            this.chkUseLeftRing.Size = new System.Drawing.Size(45, 17);
            this.chkUseLeftRing.TabIndex = 10;
            this.chkUseLeftRing.Text = "Use";
            this.chkUseLeftRing.UseVisualStyleBackColor = true;
            this.chkUseLeftRing.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // chkUseRightRing
            // 
            this.chkUseRightRing.AutoSize = true;
            this.chkUseRightRing.Location = new System.Drawing.Point(181, 61);
            this.chkUseRightRing.Margin = new System.Windows.Forms.Padding(2);
            this.chkUseRightRing.Name = "chkUseRightRing";
            this.chkUseRightRing.Size = new System.Drawing.Size(45, 17);
            this.chkUseRightRing.TabIndex = 9;
            this.chkUseRightRing.Text = "Use";
            this.chkUseRightRing.UseVisualStyleBackColor = true;
            this.chkUseRightRing.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // lblLeftRing
            // 
            this.lblLeftRing.AutoSize = true;
            this.lblLeftRing.Location = new System.Drawing.Point(7, 84);
            this.lblLeftRing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLeftRing.Name = "lblLeftRing";
            this.lblLeftRing.Size = new System.Drawing.Size(53, 13);
            this.lblLeftRing.TabIndex = 8;
            this.lblLeftRing.Text = "Left Ring:";
            // 
            // lblRightRing
            // 
            this.lblRightRing.AutoSize = true;
            this.lblRightRing.Location = new System.Drawing.Point(7, 60);
            this.lblRightRing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRightRing.Name = "lblRightRing";
            this.lblRightRing.Size = new System.Drawing.Size(60, 13);
            this.lblRightRing.TabIndex = 7;
            this.lblRightRing.Text = "Right Ring:";
            // 
            // cmbLeftRing
            // 
            this.cmbLeftRing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftRing.FormattingEnabled = true;
            this.cmbLeftRing.Items.AddRange(new object[] {
            "Albatross Ring",
            "Pelican Ring",
            "Penguin Ring",
            "Noddy Ring",
            "Puffin Ring",
            "Seagull Ring"});
            this.cmbLeftRing.Location = new System.Drawing.Point(66, 82);
            this.cmbLeftRing.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLeftRing.Name = "cmbLeftRing";
            this.cmbLeftRing.Size = new System.Drawing.Size(111, 21);
            this.cmbLeftRing.TabIndex = 6;
            this.cmbLeftRing.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cmbRightRing
            // 
            this.cmbRightRing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightRing.FormattingEnabled = true;
            this.cmbRightRing.Items.AddRange(new object[] {
            "Albatross Ring",
            "Pelican Ring",
            "Penguin Ring",
            "Noddy Ring",
            "Puffin Ring",
            "Seagull Ring"});
            this.cmbRightRing.Location = new System.Drawing.Point(66, 58);
            this.cmbRightRing.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRightRing.Name = "cmbRightRing";
            this.cmbRightRing.Size = new System.Drawing.Size(111, 21);
            this.cmbRightRing.TabIndex = 5;
            this.cmbRightRing.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.Location = new System.Drawing.Point(8, 37);
            this.lblAmmo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(39, 13);
            this.lblAmmo.TabIndex = 4;
            this.lblAmmo.Text = "Ammo:";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(7, 17);
            this.lblRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(42, 13);
            this.lblRange.TabIndex = 3;
            this.lblRange.Text = "Range:";
            // 
            // cmbAmmo
            // 
            this.cmbAmmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmmo.FormattingEnabled = true;
            this.cmbAmmo.Items.AddRange(new object[] {
            "Crayfish Ball",
            "Drill Calamary",
            "Dwarf Pugil",
            "Giant Shell Bug",
            "Insect Ball",
            "Little Worm",
            "Lufaise Fly\t",
            "Lugworm",
            "Meatball",
            "Peeled Crayfish",
            "Peeled Lobster",
            "Rotten Meat",
            "Sardine Ball",
            "Shell Bug",
            "Slice of Bluetail",
            "Slice of Carp",
            "Sliced Cod",
            "Sliced Sardine",
            "Trout Ball",
            "Dried Squid",
            "Fly Lure",
            "Frog Lure",
            "Lizard Lure",
            "Minnow",
            "Robber Rig",
            "Rogue Rig",
            "Sabiki Rig",
            "Shrimp Lure",
            "Sinking Minnow",
            "Worm Lure",
            "MMM Minnow",
            "Sea Dragon Liver",
            "Judge Fly",
            "Judge Minnow"});
            this.cmbAmmo.Location = new System.Drawing.Point(66, 35);
            this.cmbAmmo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAmmo.Name = "cmbAmmo";
            this.cmbAmmo.Size = new System.Drawing.Size(150, 21);
            this.cmbAmmo.TabIndex = 1;
            this.cmbAmmo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cmbRange
            // 
            this.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRange.FormattingEnabled = true;
            this.cmbRange.Items.AddRange(new object[] {
            "Bamboo Fish. Rod",
            "Clothespole",
            "Ebisu Fishing Rod",
            "Ebisu F. Rod +1",
            "Fastwater F. Rod",
            "Hume Fishing Rod",
            "Lu Shang\'s F. Rod",
            "Lu Sh. F. Rod +1",
            "Carbon Fish. Rod",
            "Tarutaru F. Rod",
            "Willow Fish. Rod",
            "Yew Fishing Rod",
            "Carbon Fish. Rod",
            "Comp. Fishing Rod",
            "Judge\'s Rod",
            "MMM Fishing Rod",
            "Glass Fiber F. Rod",
            "Halcyon Rod",
            "S.H. Fishing Rod",
            "Mithran Fish. Rod"});
            this.cmbRange.Location = new System.Drawing.Point(66, 11);
            this.cmbRange.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRange.Name = "cmbRange";
            this.cmbRange.Size = new System.Drawing.Size(150, 21);
            this.cmbRange.TabIndex = 0;
            this.cmbRange.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.stpOnMn);
            this.grpOptions.Controls.Add(this.chkReleaseMonster);
            this.grpOptions.Controls.Add(this.chkReleaseItem);
            this.grpOptions.Controls.Add(this.chkReleaseSmall);
            this.grpOptions.Controls.Add(this.chkReleaseBig);
            this.grpOptions.Controls.Add(this.chkReleaseChecked);
            this.grpOptions.Controls.Add(this.lblReelInDelay);
            this.grpOptions.Controls.Add(this.txtReelInDelay);
            this.grpOptions.Controls.Add(this.lblRecastDelay);
            this.grpOptions.Controls.Add(this.txtRecastDelay);
            this.grpOptions.Controls.Add(this.chkIgnoreList);
            this.grpOptions.ForeColor = System.Drawing.Color.White;
            this.grpOptions.Location = new System.Drawing.Point(10, 197);
            this.grpOptions.Margin = new System.Windows.Forms.Padding(2);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Padding = new System.Windows.Forms.Padding(2);
            this.grpOptions.Size = new System.Drawing.Size(246, 148);
            this.grpOptions.TabIndex = 5;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // stpOnMn
            // 
            this.stpOnMn.AutoSize = true;
            this.stpOnMn.Location = new System.Drawing.Point(7, 118);
            this.stpOnMn.Margin = new System.Windows.Forms.Padding(2);
            this.stpOnMn.Name = "stpOnMn";
            this.stpOnMn.Size = new System.Drawing.Size(106, 17);
            this.stpOnMn.TabIndex = 17;
            this.stpOnMn.Text = "Stop On Monster";
            this.stpOnMn.UseVisualStyleBackColor = true;
            this.stpOnMn.CheckedChanged += new System.EventHandler(this.StpOnMn_CheckedChanged);
            // 
            // chkReleaseMonster
            // 
            this.chkReleaseMonster.AutoSize = true;
            this.chkReleaseMonster.Location = new System.Drawing.Point(7, 67);
            this.chkReleaseMonster.Margin = new System.Windows.Forms.Padding(2);
            this.chkReleaseMonster.Name = "chkReleaseMonster";
            this.chkReleaseMonster.Size = new System.Drawing.Size(106, 17);
            this.chkReleaseMonster.TabIndex = 16;
            this.chkReleaseMonster.Text = "Release Monster";
            this.chkReleaseMonster.UseVisualStyleBackColor = true;
            this.chkReleaseMonster.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // chkReleaseItem
            // 
            this.chkReleaseItem.AutoSize = true;
            this.chkReleaseItem.Location = new System.Drawing.Point(7, 83);
            this.chkReleaseItem.Margin = new System.Windows.Forms.Padding(2);
            this.chkReleaseItem.Name = "chkReleaseItem";
            this.chkReleaseItem.Size = new System.Drawing.Size(88, 17);
            this.chkReleaseItem.TabIndex = 15;
            this.chkReleaseItem.Text = "Release Item";
            this.chkReleaseItem.UseVisualStyleBackColor = true;
            this.chkReleaseItem.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // chkReleaseSmall
            // 
            this.chkReleaseSmall.AutoSize = true;
            this.chkReleaseSmall.Location = new System.Drawing.Point(7, 101);
            this.chkReleaseSmall.Margin = new System.Windows.Forms.Padding(2);
            this.chkReleaseSmall.Name = "chkReleaseSmall";
            this.chkReleaseSmall.Size = new System.Drawing.Size(93, 17);
            this.chkReleaseSmall.TabIndex = 14;
            this.chkReleaseSmall.Text = "Release Small";
            this.chkReleaseSmall.UseVisualStyleBackColor = true;
            this.chkReleaseSmall.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // chkReleaseBig
            // 
            this.chkReleaseBig.AutoSize = true;
            this.chkReleaseBig.Location = new System.Drawing.Point(131, 101);
            this.chkReleaseBig.Margin = new System.Windows.Forms.Padding(2);
            this.chkReleaseBig.Name = "chkReleaseBig";
            this.chkReleaseBig.Size = new System.Drawing.Size(83, 17);
            this.chkReleaseBig.TabIndex = 13;
            this.chkReleaseBig.Text = "Release Big";
            this.chkReleaseBig.UseVisualStyleBackColor = true;
            this.chkReleaseBig.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // chkReleaseChecked
            // 
            this.chkReleaseChecked.AutoSize = true;
            this.chkReleaseChecked.Enabled = false;
            this.chkReleaseChecked.Location = new System.Drawing.Point(131, 84);
            this.chkReleaseChecked.Margin = new System.Windows.Forms.Padding(2);
            this.chkReleaseChecked.Name = "chkReleaseChecked";
            this.chkReleaseChecked.Size = new System.Drawing.Size(111, 17);
            this.chkReleaseChecked.TabIndex = 12;
            this.chkReleaseChecked.Text = "Release Checked";
            this.chkReleaseChecked.UseVisualStyleBackColor = true;
            this.chkReleaseChecked.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // lblReelInDelay
            // 
            this.lblReelInDelay.AutoSize = true;
            this.lblReelInDelay.Location = new System.Drawing.Point(4, 41);
            this.lblReelInDelay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReelInDelay.Name = "lblReelInDelay";
            this.lblReelInDelay.Size = new System.Drawing.Size(77, 13);
            this.lblReelInDelay.TabIndex = 11;
            this.lblReelInDelay.Text = "Reel In Delay: ";
            // 
            // txtReelInDelay
            // 
            this.txtReelInDelay.Location = new System.Drawing.Point(97, 38);
            this.txtReelInDelay.Margin = new System.Windows.Forms.Padding(2);
            this.txtReelInDelay.Name = "txtReelInDelay";
            this.txtReelInDelay.Size = new System.Drawing.Size(66, 20);
            this.txtReelInDelay.TabIndex = 10;
            this.txtReelInDelay.Text = "0";
            this.txtReelInDelay.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtReelInDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // lblRecastDelay
            // 
            this.lblRecastDelay.AutoSize = true;
            this.lblRecastDelay.Location = new System.Drawing.Point(4, 21);
            this.lblRecastDelay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecastDelay.Name = "lblRecastDelay";
            this.lblRecastDelay.Size = new System.Drawing.Size(77, 13);
            this.lblRecastDelay.TabIndex = 9;
            this.lblRecastDelay.Text = "Recast Delay: ";
            // 
            // txtRecastDelay
            // 
            this.txtRecastDelay.Location = new System.Drawing.Point(97, 18);
            this.txtRecastDelay.Margin = new System.Windows.Forms.Padding(2);
            this.txtRecastDelay.Name = "txtRecastDelay";
            this.txtRecastDelay.Size = new System.Drawing.Size(66, 20);
            this.txtRecastDelay.TabIndex = 8;
            this.txtRecastDelay.Text = "8000";
            this.txtRecastDelay.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtRecastDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // chkIgnoreList
            // 
            this.chkIgnoreList.AutoSize = true;
            this.chkIgnoreList.Location = new System.Drawing.Point(131, 67);
            this.chkIgnoreList.Margin = new System.Windows.Forms.Padding(2);
            this.chkIgnoreList.Name = "chkIgnoreList";
            this.chkIgnoreList.Size = new System.Drawing.Size(106, 17);
            this.chkIgnoreList.TabIndex = 7;
            this.chkIgnoreList.Text = "Ignore Catch List";
            this.chkIgnoreList.UseVisualStyleBackColor = true;
            this.chkIgnoreList.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // grpSkillHistory
            // 
            this.grpSkillHistory.Controls.Add(this.lvSkillHistory);
            this.grpSkillHistory.ForeColor = System.Drawing.Color.White;
            this.grpSkillHistory.Location = new System.Drawing.Point(234, 349);
            this.grpSkillHistory.Margin = new System.Windows.Forms.Padding(2);
            this.grpSkillHistory.Name = "grpSkillHistory";
            this.grpSkillHistory.Padding = new System.Windows.Forms.Padding(2);
            this.grpSkillHistory.Size = new System.Drawing.Size(275, 142);
            this.grpSkillHistory.TabIndex = 6;
            this.grpSkillHistory.TabStop = false;
            this.grpSkillHistory.Text = "Skill History";
            // 
            // lvSkillHistory
            // 
            this.lvSkillHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lvSkillHistory.FullRowSelect = true;
            this.lvSkillHistory.GridLines = true;
            this.lvSkillHistory.Location = new System.Drawing.Point(4, 17);
            this.lvSkillHistory.Margin = new System.Windows.Forms.Padding(2);
            this.lvSkillHistory.Name = "lvSkillHistory";
            this.lvSkillHistory.Size = new System.Drawing.Size(267, 121);
            this.lvSkillHistory.TabIndex = 5;
            this.lvSkillHistory.UseCompatibleStateImageBehavior = false;
            this.lvSkillHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Description";
            this.columnHeader8.Width = 104;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Time";
            this.columnHeader9.Width = 99;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Fischer";
            this.notifyIcon1.Visible = true;
            // 
            // BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1057, 728);
            this.Controls.Add(this.grpSkillHistory);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpGear);
            this.Controls.Add(this.grpCatchList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpCatchHistory);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BotForm";
            this.Load += new System.EventHandler(this.BotForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpCatchHistory.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpCatchList.ResumeLayout(false);
            this.grpGear.ResumeLayout(false);
            this.grpGear.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpSkillHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.GroupBox grpCatchHistory;
        private WindowsFormsApplication104.CircleProgress circleProgress1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Timer uiTimer;
        private System.Windows.Forms.ToolStripComboBox cmbProcs;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpCatchList;
        private System.Windows.Forms.GroupBox grpGear;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.ComboBox cmbAmmo;
        private System.Windows.Forms.ComboBox cmbRange;
        private System.Windows.Forms.ListView lvCatchList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ListView lvCatchHistory;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.GroupBox grpSkillHistory;
        private System.Windows.Forms.ListView lvSkillHistory;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblReelInDelay;
        private System.Windows.Forms.TextBox txtReelInDelay;
        private System.Windows.Forms.Label lblRecastDelay;
        private System.Windows.Forms.TextBox txtRecastDelay;
        private System.Windows.Forms.CheckBox chkIgnoreList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.CheckBox chkReleaseChecked;
        private System.Windows.Forms.CheckBox chkReleaseBig;
        private System.Windows.Forms.CheckBox chkReleaseMonster;
        private System.Windows.Forms.CheckBox chkReleaseItem;
        private System.Windows.Forms.CheckBox chkReleaseSmall;
        private System.Windows.Forms.ToolStripStatusLabel lblFishCaught;
        private System.Windows.Forms.Label lblLeftRing;
        private System.Windows.Forms.Label lblRightRing;
        private System.Windows.Forms.ComboBox cmbLeftRing;
        private System.Windows.Forms.ComboBox cmbRightRing;
        private System.Windows.Forms.CheckBox chkUseLeftRing;
        private System.Windows.Forms.CheckBox chkUseRightRing;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox stpOnMn;
    }
}

