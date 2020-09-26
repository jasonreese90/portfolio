using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorControls
{
    public partial class TileGrid : UserControl
    {
        private Point _selectedTile;
        private bool _tileSelected = false;
  
        public TileGrid()
        {
            InitializeComponent();
            GridSize = new System.Drawing.Size(625, 625);
      
            GridColor = Color.Black;
            SelectionColor = Color.Yellow;
            GridThickness = 1;
            this.DoubleBuffered = true;
        }

        public Size GridSize { get; set; }
        public Color GridColor { get; set; }
        public Color SelectionColor { get; set; }
        public int GridThickness { get; set; }
        public Map ActiveMap { get; set; }

        private void TileGrid_Load(object sender, EventArgs e)
        {

        }

        protected override void OnResize(EventArgs e)
        {
           // GridSize = this.Size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ActiveMap.LayerManager.ActiveLayer != null)
            {
                Size tileSize = ActiveMap.LayerManager.ActiveLayer.TileSize;

                ActiveMap.Draw(e.Graphics);

                for (int x = 0; x < GridSize.Width / tileSize.Width + 1; x++)
                {
                    e.Graphics.DrawLine(new Pen(GridColor, GridThickness), new Point(x * tileSize.Width, 0), new Point(x * tileSize.Width, (GridSize.Height / tileSize.Height) * tileSize.Height));
                }

                for (int y = 0; y < GridSize.Height / tileSize.Height + 1; y++)
                {
                    e.Graphics.DrawLine(new Pen(GridColor, GridThickness), new Point(0, y * tileSize.Height), new Point((GridSize.Width / tileSize.Width) * tileSize.Width, y * tileSize.Height));
                }

                if (_tileSelected)
                {
                    e.Graphics.DrawRectangle(new Pen(SelectionColor, GridThickness), new Rectangle(_selectedTile, tileSize));
                }
            }
        }

        private void TileGrid_DragOver(object sender, DragEventArgs e)
        {
            if (ActiveMap.LayerManager.ActiveLayer != null)
            {
                Point client = this.PointToClient(new Point(e.X, e.Y));

                Size tileSize = ActiveMap.LayerManager.ActiveLayer.TileSize;

                int x = (client.X / tileSize.Width) * tileSize.Width;
                int y = (client.Y / tileSize.Height) * tileSize.Height;

                if (IsInBounds(new Point(x, y)))
                {
                    this._selectedTile = new Point(x, y);
                    this._tileSelected = true;

                    this.Invalidate();
                }
            }
        }

        private void TileGrid_DragLeave(object sender, EventArgs e)
        {
 
        }

        private void TileGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (ActiveMap.LayerManager.ActiveLayer != null)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private bool IsInBounds(Point location)
        {
            return !(location.X > ActiveMap.MapSize.Width || location.Y > ActiveMap.MapSize.Height);
        }

        private void TileGrid_DragDrop(object sender, DragEventArgs e)
        {
            if (ActiveMap.LayerManager.ActiveLayer != null)
            {
                Point client = this.PointToClient(new Point(e.X, e.Y));
                Size tileSize = ActiveMap.LayerManager.ActiveLayer.TileSize;
                int x = (client.X / tileSize.Width) * tileSize.Width;
                int y = (client.Y / tileSize.Height) * tileSize.Height;

                DragDropTile ddtile = (DragDropTile)e.Data.GetData(typeof(DragDropTile));
                Tile tile = ddtile.Tile;

                if (IsInBounds(new Point(x, y)))
                {
                    tile.Location = new Point(x, y);
                    ActiveMap.LayerManager.ActiveLayer.Tiles.Add(tile);
                    this.Invalidate();
                }
            }
        }

        private void TileGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (ActiveMap.LayerManager.ActiveLayer != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Size tileSize = ActiveMap.LayerManager.ActiveLayer.TileSize;
                    int x = (e.X / tileSize.Width) * tileSize.Width;
                    int y = (e.Y / tileSize.Height) * tileSize.Height;

                    this._selectedTile = new Point(x, y);
                    this._tileSelected = true;
                    this.Invalidate();
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this._tileSelected = false;
                    this.Invalidate();
                }
            }
        }

        private void LayerManager_ActiveLayerChanged(object sender, EventArgs e)
        {
            this._tileSelected = false;
            this.Invalidate();
        }
  
    }
}
