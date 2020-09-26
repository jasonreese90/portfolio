using SpriteSheetCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetStudio
{
    public partial class Main : Form
    {
        private AnimationTimeline animTimeline;
        private ProjectExplorer projectExplorer;
        private SpriteSheetProject spriteProject = new SpriteSheetProject();

        public Main()
        {
            InitializeComponent();

            animTimeline = new AnimationTimeline(this);
            animTimeline.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);

            projectExplorer = new ProjectExplorer(this);
            projectExplorer.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);

            projectExplorer.SpriteSheetAdded += projectExplorer_SpriteSheetAdded;
            projectExplorer.AnimationSelectionChanged += projectExplorer_AnimationSelectionChanged;
        }

        public SpriteSheetProject Project
        {
            get { return spriteProject; }
        }

        public void ShowPreview(Sprite sprite)
        {
            SpritePreviewForm preview = new SpritePreviewForm();
            preview.SetSprite(sprite);
            preview.Show(dockPanel1);
        }

        public void ShowAnimation(Animation animation)
        {
            AnimationPreviewForm a = new AnimationPreviewForm(animation);
            a.Show(dockPanel1);
        }

        public void ClearAnimationIfActive(Animation animation)
        {
            if (animTimeline.Animation == animation)
            {
                animTimeline.Animation = null;
            }
        }

        public Animation[] GetSpriteDependancies(SpriteSheet ss,Sprite sprite)
        {
            List<Animation> animations = new List<Animation>();

            foreach (Animation a in ss.Animations)
            {
                if (a.Sprites.Contains(sprite))
                {
                    animations.Add(a);
                }
            }

            return animations.ToArray();
        }

        public void LoadProject(string filename)
        {
            spriteProject.Load(filename);
            projectExplorer.LoadSpriteSheetProject(spriteProject);
            this.Text = string.Format("{0} - Sprite Sheet Studio", spriteProject.ProjectName);
        }

        private void projectExplorer_AnimationSelectionChanged(object sender, Animation e)
        {
            animTimeline.Animation = e;
        }

        private void projectExplorer_SpriteSheetAdded(object sender, SpriteSheet e)
        {
            spriteProject.SpriteSheets.Add(e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            spriteProject.Save("test.ssp");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            spriteProject.Load("test.ssp");
            projectExplorer.LoadSpriteSheetProject(spriteProject);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void NewProject()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Application.ExecutablePath);
            process.Start();
        }

        private void OpenProject(string filename)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Application.ExecutablePath,filename);
            process.Start();
        }

        private void SaveProject()
        {
            if (string.IsNullOrEmpty(Project.ProjectPath))
            {
                SaveProjectAs();
            }
            else
            {
                Project.Save();
            }
        }

        private void SaveProjectAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SpriteSheet Project (*.ssp)|*.ssp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Project.Save(sfd.FileName);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "SpriteSheet Project (*.ssp)|*.ssp";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OpenProject(ofd.FileName);
                }
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "SpriteSheet Project (*.ssp)|*.ssp";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OpenProject(ofd.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Project.Saved)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f is AnimationPreviewForm)
                    {
                        f.Close();
                    }
                }

                DialogResult dr = MessageBox.Show(string.Format("Project \"{0}\" is not saved, would you like to save before exiting?", Project.ProjectName), "Exiting", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveProject();
                }
                else if (dr == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
