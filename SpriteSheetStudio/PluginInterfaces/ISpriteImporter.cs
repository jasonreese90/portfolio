using SpriteSheetCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PluginInferaces.SpriteSheet
{
    public interface ISpriteImporter
    {
        IEnumerable<Sprite> ImportSprites();
    }
}
