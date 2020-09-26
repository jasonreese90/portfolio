using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ShoutWatch
{
    public class Shout
    {
        public Shout()
        {

        }

        public Shout(int zone, long timestamp, string character, string mode, string msg)
        {
            Zone = zone;
            Timestamp = timestamp;
            Character = character;
            Mode = mode;
            Message = msg;
        }

        public int Zone { get; set; }
        public long Timestamp { get; set; }
        public string Character { get; set; }
        public string Mode { get; set; }
        public string Message { get; set; }
    }
}
