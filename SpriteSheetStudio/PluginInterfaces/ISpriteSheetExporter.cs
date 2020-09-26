using SpriteSheetCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginInferaces.SpriteSheet
{
    public interface ISpriteSheetExporter
    {
        void ExportSpriteSheet(SpriteSheetProject project);
    }
}
