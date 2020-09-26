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
using WeifenLuo.WinFormsUI.Docking;

namespace SpriteSheetStudio
{
    public partial class SpritePreviewForm : DockContent
    {
        public SpritePreviewForm()
        {
            InitializeComponent();
        }

        public void SetSprite(Sprite s)
        {
            pictureBox1.Image = s.Image;
        }

        private void SpritePreviewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
