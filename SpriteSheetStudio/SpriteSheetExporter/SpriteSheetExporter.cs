using PluginInferaces.SpriteSheet;
using SpriteSheetCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SpriteSheetExporter;
using System.Drawing;

namespace SpriteSheetExporter
{
    [Export(typeof(ISpriteSheetExporter))]
    [ExportMetadata("Description", "XML SpriteSheet Exporter")]
    [ExportMetadata("Author", "Jason Reese")]
    [ExportMetadata("Version", 1.0)]
    [ExportMetadata("Icon", null)]
    public class SpriteSheetExporter : ISpriteSheetExporter
    {
        public void ExportSpriteSheet(SpriteSheetProject project)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    foreach (SpriteSheet ss in project.SpriteSheets)
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                        doc.AppendChild(dec);
                        XmlElement spriteSheetElement = doc.CreateElement("SpriteSheet");
                        XmlAttribute name = doc.CreateAttribute("name");

                        name.Value = ss.Name;
                        spriteSheetElement.Attributes.Append(name);
                        doc.AppendChild(spriteSheetElement);

                        IList<Rectangle> rects = new List<Rectangle>();

                        Image packed = SpritePacker.PackSprites(ss.Sprites, rects);

                        XmlElement spritesElement = doc.CreateElement("Sprites");
                        spriteSheetElement.AppendChild(spritesElement);

                        for (int i = 0; i < ss.Sprites.Count; i++)
                        {
                            XmlElement spriteElement = doc.CreateElement("Sprite");

                            name = doc.CreateAttribute("name");
                            name.Value = ss.Sprites[i].Name;

                            XmlAttribute x = doc.CreateAttribute("x");
                            XmlAttribute y = doc.CreateAttribute("y");
                            XmlAttribute height = doc.CreateAttribute("height");
                            XmlAttribute width = doc.CreateAttribute("width");

                            x.Value = rects[i].X.ToString();
                            y.Value = rects[i].Y.ToString();
                            height.Value = rects[i].Height.ToString();
                            width.Value = rects[i].Width.ToString();

                            spriteElement.Attributes.Append(name);
                            spriteElement.Attributes.Append(x);
                            spriteElement.Attributes.Append(y);
                            spriteElement.Attributes.Append(width);
                            spriteElement.Attributes.Append(height);

                            spritesElement.AppendChild(spriteElement);
                        }

                        XmlElement animationsElement = doc.CreateElement("Animations");
                        spriteSheetElement.AppendChild(animationsElement);

                        foreach (Animation a in ss.Animations)
                        {
                            XmlElement animationElement = doc.CreateElement("Animation");
                            name = doc.CreateAttribute("name");
                            name.Value = a.Name;

                            XmlAttribute fps = doc.CreateAttribute("fps");
                            fps.Value = a.Framerate.ToString();

                            animationElement.Attributes.Append(name);
                            animationElement.Attributes.Append(fps);

                            animationsElement.AppendChild(animationElement);

                            foreach (Sprite s in a.Sprites)
                            {
                                XmlElement spriteElement = doc.CreateElement("Sprite");
                                name = doc.CreateAttribute("name");
                                name.Value = s.Name;

                                spriteElement.Attributes.Append(name);

                                animationElement.AppendChild(spriteElement);
                            }

                        }

                        XmlElement dataElement = doc.CreateElement("SpriteSheetImage");
                        XmlAttribute w = doc.CreateAttribute("width");
                        XmlAttribute h = doc.CreateAttribute("height");

                        w.Value = packed.Width.ToString();
                        h.Value = packed.Height.ToString();
                        spriteSheetElement.Attributes.Append(w);
                        spriteSheetElement.Attributes.Append(h);

                        dataElement.InnerText = Convert.ToBase64String(ImageToByteArray(packed));
                      
                        spriteSheetElement.AppendChild(dataElement);

                        doc.Save(fbd.SelectedPath + "\\" + ss.Name + ".sps");
                    }
                }

            }
        }

        static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
    