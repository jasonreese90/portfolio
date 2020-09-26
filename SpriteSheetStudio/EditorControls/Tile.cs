using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorControls
{
    public abstract class Tile
    {
        public Tile()
        {
        }

        public Point Location { get; set; }

        public abstract void Draw(Size size,Graphics g);
    }
}
