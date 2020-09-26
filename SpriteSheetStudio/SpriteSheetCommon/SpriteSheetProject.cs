using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SpriteSheetCommon
{
    [Serializable]
    public class SpriteSheetProject
    {

        public SpriteSheetProject()
        {
            SpriteSheets = new List<SpriteSheet>();
            ProjectName = "New Project";
            Saved = true;
        }

        public IList<SpriteSheet> SpriteSheets { get; private set; }
        public string ProjectName { get; set; }

        public bool Saved { get; set; }
        public string ProjectPath { get;  private set; }

        public void Save()
        {
            Save(ProjectPath);
        }

        public void Save(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, this);
            }

            Saved = true;
            this.ProjectPath = path;
        }

        public void Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();

                SpriteSheetProject ssp = (SpriteSheetProject)bf.Deserialize(fs);
                this.ProjectName = ssp.ProjectName;
                this.SpriteSheets = ssp.SpriteSheets;
            }

            this.Saved = true;
            this.ProjectPath = path;
        }
    }
}
