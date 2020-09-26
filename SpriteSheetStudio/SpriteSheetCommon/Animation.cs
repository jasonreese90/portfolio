using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetCommon
{
    [Serializable]
    public class Animation
    {
        public Animation()
        {
            Sprites = new List<Sprite>();
            Name = "";
        }

        public string Name { get; set; }
        public float Framerate { get; set; }

        public IList<Sprite> Sprites { get; private set; }
    }
}
