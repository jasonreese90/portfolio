using GenericSpriteSheetImporter.Properties;
using PluginInferaces.SpriteSheet;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSpriteSheetImporter
{
    [Export(typeof(ISpriteImporter))]
    [ExportMetadata("Description", "Generic SpriteSheet Importer")]
    [ExportMetadata("Author", "Jason Reese")]
    [ExportMetadata("Version", 1.0)]
    [ExportMetadata("Icon", null)]
    public class GenericSpriteSheetImporter : ISpriteImporter
    {
        public IEnumerable<SpriteSheetCommon.Sprite> ImportSprites()
        {
            using (SpriteSheetImporter ssi = new SpriteSheetImporter())
            {
                if (ssi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    return ssi.GetSprites();
                }

                return null;
            }
        }
    }
}
