// -----------------------------------------------------------------------
// <copyright file="SkillUpEventArgs.cs" company="Microsoft">
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
    public class SkillUpEventArgs
    {
        public SkillUpEventArgs(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
