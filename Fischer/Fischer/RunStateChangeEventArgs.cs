// -----------------------------------------------------------------------
// <copyright file="RunStateChangeEventArgs.cs" company="Microsoft">
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
    public class RunStateChangeEventArgs
    {
        public RunStateChangeEventArgs(bool running)
        {
            Running = running;
        }

        public RunStateChangeEventArgs(bool running,string message)
        {
            Running = running;
            Message = message;
        }


        public bool Running { get; set; }
        public string Message { get; set; }
    }
}
