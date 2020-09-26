using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fischer
{
    [Serializable()]
    public class CatchInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class CatchHistory
    {
        private List<CatchInfo> catchHistory = new List<CatchInfo>();

        public void Add(CatchInfo ci)
        {
            if (ci != null)
                catchHistory.Add(ci);
        }

        public void Save(string filename)
        {
            Utils.SerializeData<List<CatchInfo>>(filename, catchHistory);
        }

        public List<CatchInfo> Load(string filename)
        {
            return catchHistory = Utils.DeserializeData<List<CatchInfo>>(filename);
        }

        public void Clear()
        {
            catchHistory.Clear();
        }

        public List<CatchInfo> History
        {
            get { return catchHistory; }
        }
    }
}
