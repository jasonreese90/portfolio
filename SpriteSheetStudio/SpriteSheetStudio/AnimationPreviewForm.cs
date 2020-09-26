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
    public partial class AnimationPreviewForm : DockContent
    {
        private Animation animation;
        private DateTime lastUpdate;
        private int currentFrame = 0;

        public AnimationPreviewForm(Animation animation)
        {
            InitializeComponent();

            this.animation = animation;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.animation.Sprites.Count > 0)
            {
                e.Graphics.Clear(this.BackColor);

                e.Graphics.DrawImage(animation.Sprites[currentFrame].Image, new Point(0, 0));

                if ((DateTime.Now - lastUpdate).TotalMilliseconds > 1000 / this.animation.Framerate)
                {
                    currentFrame++;

                    if (currentFrame > animation.Sprites.Count - 1)
                    {
                        currentFrame = 0;
                    }


                    lastUpdate = DateTime.Now;
                }
            }

            this.Invalidate();
            base.OnPaint(e);
        }
    }
}
