// -----------------------------------------------------------------------
// <copyright file="ErrorLog.cs" company="Microsoft">
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
    using System.Windows.Forms;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ErrorLog
    {
        private static string log;

        public static string Log
        {
            get { return log; }
            set { log = value; }
        }

        public static void OnError(Exception e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(log, FileMode.OpenOrCreate | FileMode.Append)))
                {
                    MessageBox.Show(string.Format("{0}\n\n{1}", e.Message, e.StackTrace), e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sw.WriteLine(string.Format("[{0}]{1}\r\n{2}\r\n{3}", DateTime.Now.ToString(), e.GetType().ToString(), e.Message, e.StackTrace));
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n\n{1}", ex.Message, ex.StackTrace), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
