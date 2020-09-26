using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fischer
{
    public partial class Form1 : Form
    {
        private List<BotForm> BotInstances = new List<BotForm>();

        public Form1()
        {
            InitializeComponent();
            ErrorLog.Log = "error.log";
         
            Initialize();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox1 ab = new AboutBox1();
                ab.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void  Initialize()
        {
            FishHistory history = new FishHistory();
            history.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight;
         
            history.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockRight);
            history.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            history.DockHandler.CloseButton = false;
            history.DockHandler.CloseButtonVisible = false;
            NewTab();
        }

        private void NewTab()
        {
            try
            {
                BotForm bf = new BotForm();
                bf.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                bf.Show(dockPanel1);
                bf.Text = "New";
                BotInstances.Add(bf);
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           NewTab();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (BotForm bf in BotInstances)
            {
                try
                {
                    if (bf.Fischer != null)
                    {
                        bf.OnClosing();
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.OnError(ex);
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fishHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FishHistory history = new FishHistory();
            history.Show();
        }

        private void dockPanel1_ContentRemoved(object sender, WeifenLuo.WinFormsUI.Docking.DockContentEventArgs e)
        {
            try
            {
                if (e.Content is BotForm)
                {
                    if (((BotForm)e.Content).Fischer != null)
                    {
                        ((BotForm)e.Content).OnClosing();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dockPanel1.ActiveContent is BotForm)
                {
                    if (((BotForm)dockPanel1.ActiveContent).Fischer != null)
                    {
                        ((BotForm)dockPanel1.ActiveContent).ShowSettings();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockPanel1.ActiveContent is BotForm)
            {
                if (((BotForm)dockPanel1.ActiveContent).Fischer != null)
                {
                    //((BotForm)dockPanel1.ActiveContent).Fischer.Alarm.StopSound();
                }
            }
        }
    }
}
