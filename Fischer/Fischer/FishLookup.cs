using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Globalization;

namespace Fischer
{
    public struct FishEntry
    {
        public int ID;
        public string Name;
        public bool Checked;
    }

    public class FishDictionary
    {
        private int zoneId;
        private string document;

        public FishDictionary(int zoneId,string document)
        {
            this.zoneId = zoneId;
            this.document = document;
        }

        public void SetFile(string filename)
        {
            this.document = filename;
        }

        public void SetZone(int id)
        {
            zoneId = id;
        }

        public void CreateNewFile(string filename,int id)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlElement xm = doc.CreateElement("dictionary");
            doc.AppendChild(xm);

            XmlNode node = doc.CreateElement("zone");
            XmlAttribute att = doc.CreateAttribute("id");
            att.Value = id.ToString("X");
            node.Attributes.Append(att);
            xm.AppendChild(node);
         
           doc.Save(filename);
        }

        public void WriteFish(int id, string name)
        {
            XmlDocument fishXml = new XmlDocument();
            fishXml.Load(document);
            XmlNode node = fishXml.DocumentElement.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']");

            if (node == null) //node doesn't exist
            {
                XmlElement ele = fishXml.CreateElement("zone");
                XmlAttribute att = fishXml.CreateAttribute("id");
                att.Value = zoneId.ToString("X");

                ele.Attributes.Append(att);

                node = ele;

            }

            fishXml.DocumentElement.AppendChild(node);

            XmlNode fish = node.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']/fish[@id='" + id.ToString("X") + "']");

            if (fish == null)
            {
                XmlElement fishele = fishXml.CreateElement("fish");
                XmlAttribute idatt = fishXml.CreateAttribute("id");
                idatt.Value = id.ToString("X");

                fishele.Attributes.Append(idatt);

                idatt = fishXml.CreateAttribute("name");
                idatt.Value = name;

                fishele.Attributes.Append(idatt);

                fish = fishele;
            }

            node.AppendChild(fish);

            fishXml.Save(document);
        }

        public string GetFishName(int id)
        {
            XmlDocument fishXml = new XmlDocument();
            fishXml.Load(document);

            XmlNode node = fishXml.DocumentElement.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']/fish[@id='" + id.ToString("X") + "']");

            if (node == null)
                return "";

            return node.Attributes["name"].Value;

        }

        public int GetFishID(string name)
        {
            XmlDocument fishXml = new XmlDocument();
            fishXml.Load(document);

            XmlNode node = fishXml.DocumentElement.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']//fish[@name='" + name + "']");
            if (node == null)
                return 0;

            return int.Parse(node.Attributes["id"].Value, NumberStyles.HexNumber);
        }

        public void SetChecked(string name,bool check)
        {
            XmlDocument fishXml = new XmlDocument();
            fishXml.Load(document);

            XmlNode node = fishXml.DocumentElement.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']//fish[@name='" + name + "']");
            
            if (node == null)
                return;

            if (node.Attributes["checked"] == null)
            {
                XmlAttribute att = fishXml.CreateAttribute("checked");
                att.Value = check.ToString().ToLower();
                node.Attributes.Append(att);
            }
            else
            {
                node.Attributes["checked"].Value = check.ToString().ToLower();
            }

            fishXml.Save(document);
        }

        public void SetChecked(int id, bool check)
        {
            XmlDocument fishXml = new XmlDocument();
            fishXml.Load(document);

            XmlNode node = fishXml.DocumentElement.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']/fish[@id='" + id.ToString("X") + "']");

            if (node == null)
                return;

            if (node.Attributes["checked"] == null)
            {
                XmlAttribute att = fishXml.CreateAttribute("checked");
                att.Value = check.ToString().ToLower();
                node.Attributes.Append(att);
            }
            else
            {
                node.Attributes["checked"].Value = check.ToString().ToLower();
            }

            fishXml.Save(document);
        }





        public FishEntry[] GetAllEntries()
        {
            XmlDocument fishXml = new XmlDocument();
            fishXml.Load(document);
              XmlNode node = fishXml.DocumentElement.SelectSingleNode("//zone[@id='" + zoneId.ToString("X") + "']");

              if (node == null) //node doesn't exist
                  return null;

              FishEntry[] entries = new FishEntry[node.ChildNodes.Count];

              int counter = 0;

              try
              {
                  foreach (XmlNode child in node.ChildNodes)
                  {
                      entries[counter].ID = int.Parse(child.Attributes["id"].Value, NumberStyles.HexNumber);
                      entries[counter].Name = child.Attributes["name"].Value;

                      entries[counter].Checked = child.Attributes["checked"] == null ? false : bool.Parse(child.Attributes["checked"].Value);
                      counter++;
                  }
              }
              catch(Exception ex)
              {
                  ErrorLog.OnError(ex);
              }
              return entries;

        }

      
    }
}
