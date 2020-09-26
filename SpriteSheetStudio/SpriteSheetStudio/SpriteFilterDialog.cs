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
    public partial class SpriteFilterDialog : Form
    {
        private TreeNode current;

        public SpriteFilterDialog(TreeNode current)
        {
            InitializeComponent();
            this.current = current;
        }

        public string SpriteFilterName
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void SpriteFilterDialog_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (current.Text.ToLower() != textBox1.Text.ToLower())
                    {
                        bool contains = false;

                        foreach (TreeNode n in current.Nodes)
                        {
                            if (n.Name.ToLower() == "spritefilternode")
                            {
                                if (n.Text.ToLower() == textBox1.Text.ToLower())
                                {
                                    contains = true;
                                    break;
                                }
                            }
                        }

                        if (contains)
                        {
                            MessageBox.Show(string.Format("\"{0}\" already contains a filter named \"{1}\".", current.Parent.Text, textBox1.Text));
                            e.Cancel = true;
                        }

                    }
                }
            }
        }
    }
}
