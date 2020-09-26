using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetCommon
{
    [Serializable]
    public class Sprite
    {
        public Sprite(string name, Bitmap image)
        {
            Name = name;
            Image = image;
        }

        public string Name { get; set; }
        public string Path { get; set; }
        public Bitmap Image { get; set; }
    }
}
