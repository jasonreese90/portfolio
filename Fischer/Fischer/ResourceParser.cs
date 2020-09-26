using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;

namespace Fischer
{
    public class ResourceParser
    {

        public static string GetWeaponName(int id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "/resources/items_weapons.xml");
            XPathNavigator nav = xml.CreateNavigator();
          
            if (nav == null)
                return "";

            XPathExpression exp = nav.Compile("//i[@id='" + id + "']");

            if (exp == null)
                return "";

            XPathNavigator ret = nav.SelectSingleNode(exp);
            
            if (ret == null)
                return "";

            return ret.InnerXml;
        }


        public static string GetArmorName(int id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "/resources/items_armor.xml");
            XPathNavigator nav = xml.CreateNavigator();

            if (nav == null)
                return "";

            XPathExpression exp = nav.Compile("//i[@id='" + id + "']");

            if (exp == null)
                return "";

            XPathNavigator ret = nav.SelectSingleNode(exp);

            if (ret == null)
                return "";

            return ret.InnerXml;
        }

        public static string GetZoneName(int id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "/resources/areas.xml");
            XPathNavigator nav = xml.CreateNavigator();

            if (nav == null)
                return "";

            XPathExpression exp = nav.Compile("//a[@id='" + id + "']");

            if (exp == null)
                return "";

            XPathNavigator ret = nav.SelectSingleNode(exp);

            if (ret == null)
                return "";

            return ret.InnerXml;
        }

    }
}
