using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetCommon
{
    [Serializable]
    public class SpriteSheet
    {

        public SpriteSheet()
        {
            Sprites = new List<Sprite>();
            Animations = new List<Animation>();
            Name = "";
        }

        public IList<Sprite> Sprites { get; private set; }
        public IList<Animation> Animations { get; private set; }
        public string Name { get; set; }
    }
}
