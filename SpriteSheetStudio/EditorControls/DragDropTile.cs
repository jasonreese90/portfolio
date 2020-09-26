using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorControls
{
    public class DragDropTile
    {
        public Tile Tile { get; set; }

        public DragDropTile(Tile tile)
        {
            Tile = tile;
        }
    }
}
