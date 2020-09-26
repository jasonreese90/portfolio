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
    public partial class AnimationDialog : Form
    {
        private SpriteSheet spriteSheet;
        private Animation animation;

        public AnimationDialog(SpriteSheet spriteSheet,Animation a)
        {
            InitializeComponent();

            this.spriteSheet = spriteSheet;
            this.animation = a;

            textBox1.Text = a.Name;
            textBox2.Text = a.Framerate.ToString();
        }

        public float Framerate
        {
            get { return float.Parse(textBox2.Text); }
        }

        public string AnimationName
        {
            get { return textBox1.Text; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AnimationDialog_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (animation.Name.ToLower() != textBox1.Text.ToLower())
                    {
                        bool contains = false;

                        foreach (Animation a in spriteSheet.Animations)
                        {
                            if (a.Name.ToLower() == textBox1.Text.ToLower())
                            {
                                contains = true;
                                break;
                            }
                        }

                        if (contains)
                        {
                            MessageBox.Show(string.Format("SpriteSheet \"{0}\" already contains an animation named \"{1}\".", spriteSheet.Name, textBox1.Text));
                            e.Cancel = true;
                        }
                    }
                }

                float f;
                bool validFloat = float.TryParse(textBox2.Text, out f);

                if (!validFloat)
                {
                    MessageBox.Show(string.Format("\"{0}\" is not a valid single precision number.", textBox2.Text));
                    e.Cancel = true;
                }
            }
        }       
    }
}
