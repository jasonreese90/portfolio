using SpriteSheetCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetStudio
{
    public partial class SpriteSheetDialog : Form
    {
        private SpriteSheetProject project;
        private SpriteSheet spriteSheet;

        public SpriteSheetDialog(SpriteSheetProject project,SpriteSheet spriteSheet)
        {
            InitializeComponent();
            this.project = project;
            this.spriteSheet = spriteSheet;

            
        }

        public string SpriteSheetName
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void SpriteSheetDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Name cannot be empty.");
                    e.Cancel = true;
                }
                else
                {
                    if (spriteSheet.Name.ToLower() != textBox1.Text.ToLower())
                    {
                        bool contains = false;

                        foreach (SpriteSheet s in project.SpriteSheets)
                        {
                            if (s.Name.ToLower() == textBox1.Text.ToLower())
                            {
                                contains = true;
                                break;
                            }
                        }

                        if (contains)
                        {
                            MessageBox.Show(string.Format("Project \"{0}\" already contains a SpriteSheet named \"{1}\".", project.ProjectName, textBox1.Text));
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void SpriteSheetDialog_Load(object sender, EventArgs e)
        {
            textBox1.Text = spriteSheet.Name;
        }
    }
}
