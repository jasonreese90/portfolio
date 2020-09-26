using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace Fischer
{
    public partial class FishHistory : DockContent
    {
        private CatchHistory catchHistory = new CatchHistory();
        private List<CatchInfo> catchInfo;

        public FishHistory()
        {
            InitializeComponent();
            PopulateComboBox();
            treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode); 
        }

        void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Random r= new Random(DateTime.Now.Millisecond);
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

            SizeF size = e.Graphics.MeasureString(e.Node.Text,e.Node.NodeFont == null ? treeView1.Font : e.Node.NodeFont);

            // Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black,
               new Rectangle(e.Bounds.X, e.Bounds.Y, (int)size.Width + 1, (int)size.Height +1));

            if (e.Node.Nodes.Count > 0)
                e.Graphics.DrawString(string.Format("[{0}]", e.Node.Nodes.Count), nodeFont, Brushes.Red, new PointF(e.Bounds.X + e.Bounds.Width, e.Bounds.Y));
        }

        private void PopulateComboBox()
        {
            toolStripComboBox1.Items.Clear();

            string[] files = Directory.GetFiles("history/");

            foreach (string s in files)
            {
                if (s.Contains("chistory"))
                {
                    string name = s.Split('_')[0].Replace("history/", "");
                    toolStripComboBox1.Items.Add(name);
                }
            }
        }

        private void PopulateTree(FilterMode filter)
        {
            treeView1.Nodes.Clear();

            foreach (CatchInfo c in catchInfo)
            {
                if (filter == FilterMode.Today)
                {
                    if (TimeIsToday(c.TimeStamp))
                    {
                        AddNode(c.Name, c.TimeStamp);
                    }
                }
                else if(filter == FilterMode.All)
                {
                    AddNode(c.Name, c.TimeStamp);
                }
            }
        }

        private void AddNode(string name,DateTime time)
        {
            TreeNode[] nodes = treeView1.Nodes.Find(name, false);
            TreeNode node = null;
            if (nodes.Length == 0)
            {
                node = treeView1.Nodes.Add(name, name);
            }
            else
            {
                node = nodes[0];
            }

            node.Nodes.Add(time.ToString());
        }

        private bool TimeIsToday(DateTime time)
        {
            DateTime jpNow = Utils.ConvertDateTime("Tokyo Standard Time",DateTime.Now);
            DateTime jpThen = Utils.ConvertDateTime("Tokyo Standard Time",time);
            if (jpNow.Day == jpThen.Day && jpNow.Month == jpThen.Month && jpNow.Year == jpThen.Year)
                return true;
            return false;
        }

        private void FishHistory_Load(object sender, EventArgs e)
        {
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string file = "history/" + toolStripComboBox1.Text+ "_chistory.dat";
            catchInfo = catchHistory.Load(file);
            PopulateTree(FilterMode.All);
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripButton2.Text == "All")
            {
                PopulateTree(FilterMode.All);
                toolStripButton2.Text = "Today";
            }
            else if (toolStripButton2.Text == "Today")
            {
                PopulateTree(FilterMode.Today);
                toolStripButton2.Text = "All";
            }

        }
    }

    public enum FilterMode
    {
        All,
        Today,
        Range,
    }
}
