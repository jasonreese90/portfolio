// -----------------------------------------------------------------------
// <copyright file="NewFishFoundEventArgs.cs" company="Kunihiro">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fischer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NewFishEventArgs
    {
        public NewFishEventArgs(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }

}
