using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteSheetCommon;
using System.IO;
using System.Drawing;
using System.ComponentModel.Composition;

namespace TestImporter
{
    //[Export(typeof(IImporter))]
    //[ExportMetadata("Description","Test tile importer")]
    //public class TestImporter : IImporter
    //{
    //    public IEnumerable<System.Drawing.Bitmap> ImportTiles()
    //    {
    //        using (FolderBrowserDialog fbd = new FolderBrowserDialog())
    //        {
    //            if (fbd.ShowDialog() == DialogResult.OK)
    //            {
    //                IList<System.Drawing.Bitmap> bitmaps = new List<System.Drawing.Bitmap>();

    //                string[] files = Directory.GetFiles(fbd.SelectedPath);

    //                foreach (string file in files)
    //                {
    //                        if (!file.Contains(".db"))
    //                        {
    //                            Bitmap bitmap = (Bitmap)Bitmap.FromFile(file);

    //                            bitmaps.Add(bitmap);
    //                        }
    //                }

    //                return bitmaps;
    //            }
    //        }

    //        return null;
    //    }
    //}
}
