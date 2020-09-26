using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorControls
{
    public class TileLayerManager : List<TileLayer<Tile>>
    {
        public TileLayerManager()
        {
        }

        public event EventHandler<EventArgs> ActiveLayerChanged;

        public TileLayer<Tile> ActiveLayer { get; set; }

        public void SetActiveLayer(int index)
        {
            if (index < this.Count)
            {
                ActiveLayer = this[index];

                if (ActiveLayerChanged != null)
                {
                    ActiveLayerChanged(this, new EventArgs());
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Draw(Graphics g)
        {
            foreach(TileLayer<Tile> t in this)
            {
                t.Draw(g);
            }
        }
    }
}
