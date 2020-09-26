using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Kunihiro.FFXi;
using System.Globalization;
using XiClaim.Properties;
using Kunihiro;
using System.IO;
using System.Security.Principal;

namespace XiClaim
{
    public partial class Main : Form
    {
        private PolProcess[] processes;
        private XiLib ffxi = null;
        private List<string> targProcs = new List<string>();
        private Mode mode = Mode.ID;
        private ColumnHeader SortingColumn = null;

        List<BotWorker> workers = new List<BotWorker>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("This application must be run as an administrator.\nXiClaim will now exit.", 
                    "Run as admin.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }

            if(IsAdministrator())
            {
                this.Text = "XiClaim - Administrator";
            }

            lstMobs.Sorting = SortOrder.Ascending;
          


            LoadSettings();
            RefreshProcesses();
        }

        private void LoadSettings()
        {
            using (FileStream fs = new FileStream("targprocs", FileMode.OpenOrCreate))
            {
     
                using (StreamReader sr = new StreamReader(fs))
                {
                    int counter = 0;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        targProcs.Add(line);
                        counter++;
                    }

                    if (string.IsNullOrEmpty(line) && counter == 0)
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("pol");
                            targProcs.Add("pol");
                            return;
                        }
                    }

                }
            }
        }

        private bool ProcHasModule(Process proc, string name)
        {
            foreach (ProcessModule pm in proc.Modules)
            {
                if (pm.ModuleName.ToLower() == name.ToLower())
                    return true;
            }

            return false;
        }

        private void RefreshProcesses()
        {
            lstProc.Items.Clear();
            workers.Clear();

            processes = PolProcess.GetProcesses(targProcs.ToArray());

            foreach (Process p in processes)
            {
                XiLib xi = new XiLib(p.Id);

                lstProc.Items.Add(string.Format("{0} [{1} ({2})]", xi.Player.Name,p.ProcessName, p.Id));
            }
        }
        private void RefreshMobs()
        {
            lstMobs.Items.Clear();

            for (uint i = 0; i < 2000; i++)
            {
                EntityInfo es = ffxi.Entity.GetEntity(i);

                if (es.ID != 0 && es.Type == EntityType.Mob)
                {
                    EntityStruct? e = ffxi.Entity.FindByServerID(es.ClaimedBy);
                    lstMobs.Items.Add(new ListViewItem(new string[] { es.ID.ToString("X"), es.Name, es.HPP.ToString(), e==null ? "None" : string.IsNullOrEmpty(e.Value.Name)
                        ? e.Value.ClaimedBy.ToString("X") : e.Value.Name}));
                }
            }
        }

        private void EnableControls(bool enable, bool ignoreStart = false, bool ignoreProcSel = true)
        {
            grpMobs.Enabled = enable;
            grpClaim.Enabled = enable;

            if (!ignoreStart)
            startStop.Enabled = enable;

            if(!ignoreProcSel)
            {
                procRef.Enabled = enable;
                lstProc.Enabled = enable;
            }
        }

        private void ClearControls()
        {
            lstMobs.Items.Clear();
            lstClaim.Items.Clear();
            txtId.Text = "";
            txtCmd.Text = "";
        }

        private void ProcRef_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
            EnableControls(false);
            ClearControls();

        }

        private void LstProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process proc = processes[lstProc.SelectedIndex];
            ffxi = new XiLib(proc.Id);

            RefreshMobs();
            EnableControls(true);
        }

        private void mobRef_Click(object sender, EventArgs e)
        {
            RefreshMobs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            uint id = 0;
            EntityInfo entity;
            string name = "";

            if (mode == Mode.ID)
            {
                if (!uint.TryParse(txtId.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out id))
                {
                    MessageBox.Show("Invalid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            entity = ffxi.Entity.GetEntity(id);

            name = entity.Name;
            if (entity.ID == 0)
            {
                name = "Unknown";
                //MessageBox.Show("Invalid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (mode == Mode.Name)
                name = txtId.Text;

            //if(string.IsNullOrEmpty(txtCmd.Text))
            //{
            //    MessageBox.Show("Invalid Command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            float delay = 0;

            if (!float.TryParse(txtDelay.Text, out delay))
            {
                MessageBox.Show("Invalid Delay. Must be a floating-point number. e.g. 1.5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstClaim.Items.Add(new ListViewItem(new string[] { id == 0?  "N/A": id.ToString("X"), name, txtCmd.Text, mode.ToString() }));
  

            BotWorker worker = new BotWorker(ffxi, chkAlarm.Checked, mode,delay, id,name, txtCmd.Text);
            worker.Alarm += Worker_Alarm;
            workers.Add(worker);
            txtId.Text = "";
            txtCmd.Text = "";
        }

        private void Worker_Alarm(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate { btnMute.Enabled = true; }));
        }

        private void DeleteSelectedListViewItems(ListView.SelectedListViewItemCollection items)
        {
            foreach(ListViewItem i in items)
            {
                workers[i.Index].Alarm -= Worker_Alarm;
                workers.RemoveAt(i.Index);
                i.Remove();
            }
        }

        private void lstClaim_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstClaim.SelectedItems != null && e.Button == MouseButtons.Left)
            {
                DeleteSelectedListViewItems(lstClaim.SelectedItems);
            }
        }

        private void lstClaim_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstClaim.SelectedItems != null && e.KeyCode == Keys.Delete)
            {
                DeleteSelectedListViewItems(lstClaim.SelectedItems);
            }
        }

        private void StartStop_Click(object sender, EventArgs e)
        {
            if (workers.Count > 0)
            {
                if (startStop.Text == "Start")
                {
                    startStop.Text = "Stop";
                    startStop.Image = Resources.power;
                    EnableControls(false, true, false);

                    foreach (BotWorker b in workers)
                    {
                        b.Start();
                    }
                }
                else
                {
                    startStop.Text = "Start";
                    startStop.Image = Resources.power_button;

                    foreach (BotWorker b in workers)
                    {
                        b.Stop();
                        b.StopAlarm();
                    }

                    btnMute.Enabled = false;
                    EnableControls(true, true, false);
                }
            }
            else
            {
                MessageBox.Show("Must enter a valid ID before running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMute_Click(object sender, EventArgs e)
        {
            foreach(BotWorker bw in workers)
            {
                bw.StopAlarm();
            }

            btnMute.Enabled = false;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LstMobs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lstMobs.SelectedIndices.Count > 0 && e.Button == MouseButtons.Left)
            {
                if(mode == Mode.ID)
                    txtId.Text = lstMobs.SelectedItems[0].SubItems[0].Text;
                else
                    txtId.Text = lstMobs.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void LstClaim_MouseDown(object sender, MouseEventArgs e)
        {
            //if(lise.Button == MouseButtons.Left)
        }
        private bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                lblId.Text = "ID:";
                txtId.Text = "";
                mode = Mode.ID;
            }
            else
            {
                lblId.Text = "Name:";
                txtId.Text = "";
                mode = Mode.Name;
            }
        }

        private void LstMobs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader new_sorting_column = lstMobs.Columns[e.Column];

            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            lstMobs.ListViewItemSorter = new MobsComparer(e.Column, sort_order);
            lstMobs.Sort();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)0x0d)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    e.Handled = true;
                    foreach (ListViewItem lvi in lstMobs.Items)
                    {
                        if (!lvi.SubItems[1].Text.ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            lvi.Remove();
                        }
                    }
                }

                textBox1.Text = "";
            }
        }

        public class MobsComparer : System.Collections.IComparer
        {
            private int column = 0;
            private SortOrder sortOrder;

            public MobsComparer(int column, SortOrder order)
            {
                this.column = column;
                this.sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                ListViewItem item_x = x as ListViewItem;
                ListViewItem item_y = y as ListViewItem;

                string s1 = item_x.SubItems[column].Text;
                string s2 = item_y.SubItems[column].Text;
                int res = s1.CompareTo(s2);
                if (sortOrder == SortOrder.Descending)
                    return -res;

                return res;
            }
        }
    }
}
