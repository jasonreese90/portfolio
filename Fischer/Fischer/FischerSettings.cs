// -----------------------------------------------------------------------
// <copyright file="FischerSettings.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fischer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Runtime.Serialization;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Serializable()]
    public class FischerSettings
    {
        public bool IgnoreCatchList;
        public bool ReleaseChecked;
        public bool ReleaseBig;
        public bool ReleaseSmall;
        public bool ReleaseMonster;
        public bool ReleaseItem;
        public bool UseRightRing;
        public bool UseLeftRing;
        public bool StopOnMonster;
        public int Fatigue;
        public bool UseFatigue;
        public int RecastDelay;
        public int ReelInDelay;
        public int ReleaseDelayMin;
        public int ReleaseDelayMax;
        public byte ReelInPercent;
        public string NewChatLineScript;
        public string ZoneChangeScript;
        public string FullInventoryScript;
        public string NoRodScript;
        public string NoBaitScript;

        public static FischerSettings Load(string name)
        {
            if (File.Exists(string.Format("settings/{0}.set", name)))
                return Utils.DeserializeData<FischerSettings>(string.Format("settings/{0}.set", name));
            else
                return null;
        }

        public static void Save(FischerSettings settings, string name)
        {
            Utils.SerializeData<FischerSettings>(string.Format("settings/{0}.set",name), settings);
        }
    }

}
