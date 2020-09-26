using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorControls
{
    public class Map
    {
        public Map(Size mapSize)
        {
            this.LayerManager = new TileLayerManager();
            this.MapSize = mapSize;
            //LayerManager.ActiveLayerChanged += LayerManager_ActiveLayerChanged;
        }

        public string Name { get; set; }
        public Size MapSize { get; set; }

        [Browsable(false)]
        public TileLayerManager LayerManager { get; private set; }

        public void Draw(Graphics g)
        {
            if (LayerManager.ActiveLayer != null)
            {
                LayerManager.Draw(g);
            }
        }
    }
}
