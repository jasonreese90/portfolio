namespace XiClaim
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStProc = new System.Windows.Forms.ToolStrip();
            this.lstProc = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.procRef = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.startStop = new System.Windows.Forms.ToolStripButton();
            this.btnMute = new System.Windows.Forms.ToolStripButton();
            this.grpMobs = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tlStMobs = new System.Windows.Forms.ToolStrip();
            this.mobRef = new System.Windows.Forms.ToolStripButton();
            this.lstMobs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpClaim = new System.Windows.Forms.GroupBox();
            this.grpAdd = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.chkAlarm = new System.Windows.Forms.CheckBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.lblCmd = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstClaim = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip.SuspendLayout();
            this.tlStProc.SuspendLayout();
            this.grpMobs.SuspendLayout();
            this.tlStMobs.SuspendLayout();
            this.grpClaim.SuspendLayout();
            this.grpAdd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(665, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // tlStProc
            // 
            this.tlStProc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlStProc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lstProc,
            this.toolStripSeparator6,
            this.procRef,
            this.toolStripSeparator7,
            this.startStop,
            this.btnMute});
            this.tlStProc.Location = new System.Drawing.Point(0, 24);
            this.tlStProc.Name = "tlStProc";
            this.tlStProc.Size = new System.Drawing.Size(665, 25);
            this.tlStProc.TabIndex = 1;
            this.tlStProc.Text = "z`x";
            // 
            // lstProc
            // 
            this.lstProc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstProc.Name = "lstProc";
            this.lstProc.Size = new System.Drawing.Size(200, 25);
            this.lstProc.SelectedIndexChanged += new System.EventHandler(this.LstProc_SelectedIndexChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // procRef
            // 
            this.procRef.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.procRef.Image = global::XiClaim.Properties.Resources.refresh;
            this.procRef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.procRef.Name = "procRef";
            this.procRef.Size = new System.Drawing.Size(23, 22);
            this.procRef.Text = "Refresh";
            this.procRef.Click += new System.EventHandler(this.ProcRef_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // startStop
            // 
            this.startStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startStop.Enabled = false;
            this.startStop.Image = global::XiClaim.Properties.Resources.power_button;
            this.startStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startStop.Name = "startStop";
            this.startStop.Size = new System.Drawing.Size(23, 22);
            this.startStop.Text = "Start";
            this.startStop.Click += new System.EventHandler(this.StartStop_Click);
            // 
            // btnMute
            // 
            this.btnMute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMute.Enabled = false;
            this.btnMute.Image = global::XiClaim.Properties.Resources.mute;
            this.btnMute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMute.Margin = new System.Windows.Forms.Padding(381, 1, 0, 2);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(23, 22);
            this.btnMute.Text = "toolStripButton1";
            this.btnMute.Click += new System.EventHandler(this.BtnMute_Click);
            // 
            // grpMobs
            // 
            this.grpMobs.Controls.Add(this.textBox1);
            this.grpMobs.Controls.Add(this.tlStMobs);
            this.grpMobs.Controls.Add(this.lstMobs);
            this.grpMobs.Enabled = false;
            this.grpMobs.Location = new System.Drawing.Point(12, 52);
            this.grpMobs.Name = "grpMobs";
            this.grpMobs.Size = new System.Drawing.Size(314, 295);
            this.grpMobs.TabIndex = 2;
            this.grpMobs.TabStop = false;
            this.grpMobs.Text = "Mobs";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 275);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // tlStMobs
            // 
            this.tlStMobs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlStMobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mobRef});
            this.tlStMobs.Location = new System.Drawing.Point(3, 16);
            this.tlStMobs.Name = "tlStMobs";
            this.tlStMobs.Size = new System.Drawing.Size(308, 25);
            this.tlStMobs.TabIndex = 1;
            this.tlStMobs.Text = "toolStrip2";
            // 
            // mobRef
            // 
            this.mobRef.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mobRef.Image = global::XiClaim.Properties.Resources.refresh;
            this.mobRef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mobRef.Name = "mobRef";
            this.mobRef.Size = new System.Drawing.Size(23, 22);
            this.mobRef.Text = "Refresh";
            this.mobRef.Click += new System.EventHandler(this.mobRef_Click);
            // 
            // lstMobs
            // 
            this.lstMobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstMobs.FullRowSelect = true;
            this.lstMobs.GridLines = true;
            this.lstMobs.Location = new System.Drawing.Point(3, 44);
            this.lstMobs.MultiSelect = false;
            this.lstMobs.Name = "lstMobs";
            this.lstMobs.Size = new System.Drawing.Size(308, 231);
            this.lstMobs.TabIndex = 0;
            this.lstMobs.UseCompatibleStateImageBehavior = false;
            this.lstMobs.View = System.Windows.Forms.View.Details;
            this.lstMobs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstMobs_ColumnClick);
            this.lstMobs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstMobs_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 103;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "HP%";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ClaimedBy";
            this.columnHeader4.Width = 78;
            // 
            // grpClaim
            // 
            this.grpClaim.Controls.Add(this.grpAdd);
            this.grpClaim.Controls.Add(this.lstClaim);
            this.grpClaim.Enabled = false;
            this.grpClaim.Location = new System.Drawing.Point(332, 52);
            this.grpClaim.Name = "grpClaim";
            this.grpClaim.Size = new System.Drawing.Size(328, 295);
            this.grpClaim.TabIndex = 3;
            this.grpClaim.TabStop = false;
            this.grpClaim.Text = "Claim List";
            // 
            // grpAdd
            // 
            this.grpAdd.Controls.Add(this.label2);
            this.grpAdd.Controls.Add(this.label1);
            this.grpAdd.Controls.Add(this.txtDelay);
            this.grpAdd.Controls.Add(this.groupBox1);
            this.grpAdd.Controls.Add(this.chkAlarm);
            this.grpAdd.Controls.Add(this.txtId);
            this.grpAdd.Controls.Add(this.lblId);
            this.grpAdd.Controls.Add(this.txtCmd);
            this.grpAdd.Controls.Add(this.lblCmd);
            this.grpAdd.Controls.Add(this.btnAdd);
            this.grpAdd.Location = new System.Drawing.Point(6, 147);
            this.grpAdd.Name = "grpAdd";
            this.grpAdd.Size = new System.Drawing.Size(313, 142);
            this.grpAdd.TabIndex = 2;
            this.grpAdd.TabStop = false;
            this.grpAdd.Text = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Delay:";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(172, 37);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(52, 20);
            this.txtDelay.TabIndex = 21;
            this.txtDelay.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 44);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Claim By";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(48, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 20;
            this.radioButton2.Text = "Name";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ID";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // chkAlarm
            // 
            this.chkAlarm.AutoSize = true;
            this.chkAlarm.Checked = true;
            this.chkAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlarm.Location = new System.Drawing.Point(228, 70);
            this.chkAlarm.Name = "chkAlarm";
            this.chkAlarm.Size = new System.Drawing.Size(52, 17);
            this.chkAlarm.TabIndex = 18;
            this.chkAlarm.Text = "Alarm";
            this.chkAlarm.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(70, 69);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(141, 20);
            this.txtId.TabIndex = 14;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(7, 72);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 15;
            this.lblId.Text = "ID:";
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(70, 95);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(141, 20);
            this.txtCmd.TabIndex = 16;
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.Location = new System.Drawing.Point(7, 98);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(57, 13);
            this.lblCmd.TabIndex = 17;
            this.lblCmd.Text = "Command:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(228, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstClaim
            // 
            this.lstClaim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader7});
            this.lstClaim.FullRowSelect = true;
            this.lstClaim.GridLines = true;
            this.lstClaim.Location = new System.Drawing.Point(6, 22);
            this.lstClaim.Name = "lstClaim";
            this.lstClaim.Size = new System.Drawing.Size(316, 118);
            this.lstClaim.TabIndex = 1;
            this.lstClaim.UseCompatibleStateImageBehavior = false;
            this.lstClaim.View = System.Windows.Forms.View.Details;
            this.lstClaim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstClaim_KeyDown);
            this.lstClaim.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstClaim_MouseDoubleClick);
            this.lstClaim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LstClaim_MouseDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 75;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Command";
            this.columnHeader9.Width = 114;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mode";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 351);
            this.Controls.Add(this.grpClaim);
            this.Controls.Add(this.grpMobs);
            this.Controls.Add(this.tlStProc);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "XiClaim";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tlStProc.ResumeLayout(false);
            this.tlStProc.PerformLayout();
            this.grpMobs.ResumeLayout(false);
            this.grpMobs.PerformLayout();
            this.tlStMobs.ResumeLayout(false);
            this.tlStMobs.PerformLayout();
            this.grpClaim.ResumeLayout(false);
            this.grpAdd.ResumeLayout(false);
            this.grpAdd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tlStProc;
        private System.Windows.Forms.ToolStripComboBox lstProc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton procRef;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton startStop;
        private System.Windows.Forms.GroupBox grpMobs;
        private System.Windows.Forms.ListView lstMobs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip tlStMobs;
        private System.Windows.Forms.ToolStripButton mobRef;
        private System.Windows.Forms.GroupBox grpClaim;
        private System.Windows.Forms.GroupBox grpAdd;
        private System.Windows.Forms.ListView lstClaim;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnMute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chkAlarm;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Label lblCmd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.TextBox textBox1;
    }
}

