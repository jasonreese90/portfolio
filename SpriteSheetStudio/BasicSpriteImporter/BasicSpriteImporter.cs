using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteSheetCommon;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using PluginInferaces.SpriteSheet;

namespace BasicSpriteImporter
{
    [Export(typeof(ISpriteImporter))]
    [ExportMetadata("Description", "Basic sprite importer")]
    [ExportMetadata("Author", "Jason Reese")]
    [ExportMetadata("Version", 1.0)]
    [ExportMetadata("Icon", null)]
    public class BasicSpriteImporter : ISpriteImporter
    {
        private readonly string OpenFilter = "PNG|*.png|GIF|*.gif|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIFF|*.tiff;*.tiff|Bitmap|*.bmp;*.dib";

        public IEnumerable<Sprite> ImportSprites()
        {
            List<Sprite> bitmaps = new List<Sprite>();

            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = OpenFilter;

                if(ofd.ShowDialog() ==  DialogResult.OK)
                {
                    foreach(string file in ofd.FileNames)
                    {
                        bitmaps.Add(new Sprite(Path.GetFileNameWithoutExtension(file), (Bitmap)Bitmap.FromFile(file)));
                    }
                }
            }

            return bitmaps;
        }
    }
}
