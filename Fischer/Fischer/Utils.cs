using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Fischer
{
    public class Utils
    {
        public static void SerializeData<T>(string filename, T t)
        {
            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, t);
               
            }
        }

        public static T DeserializeData<T>(string filename)
        {
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (T)bin.Deserialize(stream);
            }
        }

        public static string GetIDString(int id1, int id2, int id3)
        {
            return string.Format("{0:X}{1:X}{2:X}", id1, id2, id3);
        }

        public static int GetID(int id1, int id2, int id3)
        {
            return int.Parse(string.Format("{0:X}{1:X}", id1, id2),NumberStyles.HexNumber);
        }

        public static void Wait(int min, int max)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int wait = rnd.Next(min, max);
            Thread.Sleep(wait);
        }

        public static DateTime ConvertDateTime(string timezone, DateTime current)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            return TimeZoneInfo.ConvertTime(current, timeZoneInfo);
        }


    }
}
