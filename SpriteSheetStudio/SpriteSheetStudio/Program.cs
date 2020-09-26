using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetStudio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                Application.Run(new Main());
            }
            else
            {
                Main m = new Main();
                if (File.Exists(args[0]))
                {
                    m.LoadProject(args[0]);
                    Application.Run(m);
                }
                else
                {
                    MessageBox.Show("{0} is not a valid SpriteSheet project.", args[0]);
                }
            }
        }
    }
}
