using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fischer
{
    [Serializable()]
    public class SkillInfo
    {
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class SkillHistory
    {
        private List<SkillInfo> skillHistory = new List<SkillInfo>();

        public void Add(SkillInfo si)
        {
            if (si != null)
                skillHistory.Add(si);
        }

        public void Save(string filename)
        {
            Utils.SerializeData<List<SkillInfo>>(filename, skillHistory);
        }

        public List<SkillInfo> Load(string filename)
        {
            return skillHistory = Utils.DeserializeData<List<SkillInfo>>(filename);
        }

        public void Clear()
        {
            skillHistory.Clear();
        }

        public List<SkillInfo> History
        {
            get { return skillHistory; }
        }
    }
}
