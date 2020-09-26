using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Kunihiro.FFXi;

namespace Fischer
{
    public partial class Settings : Form
    {
        private FischerSettings settings;
        private XiLib ffxi;

        public Settings(FischerSettings settings,XiLib ffxi)
        {
            InitializeComponent();
            this.settings = settings;
            this.ffxi = ffxi;
            ApplySettings(settings);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApplySettings(FischerSettings settings)
        {
            textBox1.Text = settings.NewChatLineScript;
            textBox2.Text = settings.FullInventoryScript;
            textBox3.Text = settings.ZoneChangeScript;
            textBox4.Text = settings.NoRodScript;
            textBox5.Text = settings.NoBaitScript;
            numericUpDown1.Value = settings.ReleaseDelayMin;
            numericUpDown2.Value = settings.ReleaseDelayMax;
            numericUpDown3.Value = settings.ReelInPercent;
            numericUpDown4.Value = settings.Fatigue;
            checkBox1.Checked = settings.UseFatigue;
        }

        private string ShowOpenFileDialog()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "LUA Files (.lua)|*.lua"; 

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if(ofd.FileName.Contains(Application.StartupPath +"\\"))
                    {
                        return ofd.FileName.Replace(Application.StartupPath + "\\","");
                    }

                    return ofd.FileName;
                }
            }

            return "";
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = ShowOpenFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                settings.NewChatLineScript = path;
                textBox1.Text = path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = ShowOpenFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                settings.FullInventoryScript = path;
                textBox2.Text = path;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = ShowOpenFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                settings.ZoneChangeScript = path;
                textBox3.Text = path;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = ShowOpenFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                settings.NoRodScript = path;
                textBox4.Text = path;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = ShowOpenFileDialog();

            if (!string.IsNullOrEmpty(path))
            {
                settings.NoBaitScript = path;
                textBox5.Text = path;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            settings.ReleaseDelayMin = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            settings.ReleaseDelayMax = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            settings.ReelInPercent = (byte)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            FischerSettings.Save(settings, ffxi.Player.Name);
            this.Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            FischerSettings.Save(settings, ffxi.Player.Name);
        }

        private void numericUpDown4_ValueChanged_1(object sender, EventArgs e)
        {
            settings.Fatigue = (int)numericUpDown4.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            settings.UseFatigue = checkBox1.Checked;

            numericUpDown4.Enabled = checkBox1.Checked;
        }
    }
}
