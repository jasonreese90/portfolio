using EditorControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorControls
{
    public class TileLayer<T> where T: Tile
    {
        public TileLayer(Size tileSize)
        {
            Tiles = new List<T>();
            TileSize = tileSize;
            Visible = true;
        }

        public Size TileSize { get; set; }
        public List<T> Tiles { get; private set; }

        public string Name { get; set; }

        public bool Visible { get; set; }

        public void Draw(Graphics graphics)
        {
            if (Visible)
            {
                foreach (Tile t in Tiles)
                {
                    t.Draw(TileSize, graphics);
                }
            }
        }
    }
}
