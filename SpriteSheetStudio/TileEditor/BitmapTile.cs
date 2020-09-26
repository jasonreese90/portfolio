using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpriteSheetCommon
{
    class BitmapTile : EditorControls.Tile
    {
        private Bitmap _bitmap;
        
        public BitmapTile(Bitmap bitmap)
        {
            this._bitmap = bitmap;
        }

        public override void Draw(System.Drawing.Size size, System.Drawing.Graphics g)
        {
            g.DrawImage(this._bitmap, new Rectangle(this.Location, size));
        }
    }
}
