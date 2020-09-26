using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fischer
{
    public partial class HistoryTreeView : TreeNode
    {
        public HistoryTreeView()
        {
            InitializeComponent();
            this.Text = "";
        }
    }
}
