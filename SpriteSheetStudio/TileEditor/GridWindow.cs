using EditorControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SpriteSheetCommon
{
    public partial class GridWindow : DockContent
    {
        public GridWindow(Map active)
        {
            InitializeComponent();
            this.tileGrid1.ActiveMap = active;
        }

        public EditorControls.TileGrid TileGrid { get { return this.tileGrid1; } }

        private void GridWindow_Load(object sender, EventArgs e)
        {

        }

        private void GridWindow_DragDrop(object sender, DragEventArgs e)
        {
         
        }
    }
}
