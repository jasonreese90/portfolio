using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SpriteSheetCommon;

namespace SpriteSheetStudio
{
    public partial class AnimationTimeline : DockContent, IList<Sprite>
    {
        private Animation animation;
        private Size frameSize;
        private int? selectedFrame = null;
        private int dragIndex = 0;
        private int scrollOffset = 0;
        private Main main;

        public AnimationTimeline(Main main)
        {
            InitializeComponent();
            this.SelectedColor = Color.Yellow;
            this.LineColor = Color.Black;
            this.main = main;
        }

        public Size FrameSize
        {
            get
            {
                return frameSize;
            }
            set
            {
                frameSize = value;
                this.Height = FrameSize.Height + SystemInformation.HorizontalScrollBarHeight + 2;
            }
        }

        public Color SelectedColor { get; set; }
        public Color LineColor { get; set; }
        public int LineThickness { get; set; }

        public Animation Animation
        {
            get
            {
                return animation;
            }
            set
            {
                animation = value;
                if (value != null)
                {
                    this.AutoScrollMinSize = new Size(animation.Sprites.Count * FrameSize.Width + (animation.Sprites.Count % (this.Width / frameSize.Width) * frameSize.Width), 0);
                    this.Text = string.Format("Timeline - {0} [{1} FPS]", animation.Name, animation.Framerate.ToString());
                }

                this.Invalidate();
            }
        }

        public Sprite SelectedSprite
        {
            get
            {
                if (selectedFrame != null)
                {
                    return this[selectedFrame.Value + scrollOffset / frameSize.Width];
                }
                 
                return null;
            }
        }

        public int? SelectedIndex
        {
            get
            {
                if (selectedFrame != null)
                {
                    return selectedFrame.Value + scrollOffset / frameSize.Width; 
                }

                return null;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (selectedFrame != null)
                {
                    this.dragIndex = selectedFrame .Value+ scrollOffset / frameSize.Width; 
                    this.DoDragDrop(this[dragIndex], DragDropEffects.Move);
                }
            }

            base.OnMouseDown(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (animation != null)
                {
                    if (this.Count > 0)
                    {
                        int selected = e.X / frameSize.Width;
                        if (selected + scrollOffset / frameSize.Width < this.Count)
                        {
                            selectedFrame = selected;
                            this.Invalidate();
                        }
                    }
                }
            }
            base.OnMouseClick(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            if (animation != null)
            {
                if (frameSize.Width > 0 && frameSize.Height > 0)
                {
                    int startFrame = scrollOffset / frameSize.Width;
                    int endFrame = (this.Width / FrameSize.Width + 1) + startFrame;

                    if (endFrame > this.Count)
                        endFrame = this.Count;

                    for (int i = startFrame; i < endFrame; i++)
                    {
                        e.Graphics.DrawImage(this[i].Image, new Rectangle(new Point(FrameSize.Width * (i - startFrame) + LineThickness, LineThickness), FrameSize));
                        e.Graphics.DrawRectangle(new Pen(LineColor, LineThickness), new Rectangle(new Point(FrameSize.Width * (i - startFrame), 0), new Size(FrameSize.Width + LineThickness, FrameSize.Height + LineThickness)));
                        SizeF size = e.Graphics.MeasureString(this[i].Name, new System.Drawing.Font("arial", 12));
                        e.Graphics.FillRectangle(Brushes.Black, new Rectangle(new Point(FrameSize.Width * (i - startFrame), 0),new Size((int)size.Width, (int)size.Height)));
                        e.Graphics.DrawString(this[i].Name, new Font("arial", 12), Brushes.White, new Point(FrameSize.Width * (i - startFrame), 0));
                    }

                    if (selectedFrame != null)
                    {
                        e.Graphics.DrawRectangle(new Pen(SelectedColor, LineThickness), new Rectangle(new Point(FrameSize.Width * selectedFrame.Value, 0), new Size(FrameSize.Width + LineThickness, FrameSize.Height + LineThickness)));
                    }
                }
            }

            base.OnPaint(e);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            scrollOffset = se.NewValue;
            selectedFrame = null;
            this.Invalidate();
            base.OnScroll(se);
        }

        protected override void OnResize(EventArgs e)
        {
            frameSize = new Size(this.Height, this.Height);

            if (animation != null)
            {
                this.AutoScrollMinSize = new Size(animation.Sprites.Count * FrameSize.Width + (animation.Sprites.Count % (this.Width / frameSize.Width) * frameSize.Width), 0);
            }

            base.OnResize(e);
        }

        public int IndexOf(Sprite item)
        {
            return animation.Sprites.IndexOf(item);
        }

        public void Insert(int index, Sprite item)
        {
            animation.Sprites.Insert(index, item);
            this.Invalidate();
        }

        public void RemoveAt(int index)
        {
            if (animation != null)
            {
                if (index < this.Count)
                {
                    animation.Sprites.RemoveAt(index);
                    this.Invalidate();
                }
            }
        }

        public Sprite this[int index]
        {
            get
            {
                return animation.Sprites[index];
            }
            set
            {
                animation.Sprites[index] = value;
            }
        }

        public void Add(Sprite item)
        {
            animation.Sprites.Add(item);
            this.AutoScrollMinSize = new Size(animation.Sprites.Count * FrameSize.Width + (animation.Sprites.Count % (this.Width/frameSize.Width) * frameSize.Width), 0);
            this.Invalidate();
        
        }

        public void Clear()
        {
            animation.Sprites.Clear();
            this.Invalidate();
        }

        public bool Contains(Sprite item)
        {
            return animation.Sprites.Contains(item);
        }

        public void CopyTo(Sprite[] array, int arrayIndex)
        {
            animation.Sprites.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return animation.Sprites.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Sprite item)
        {
            bool ret = animation.Sprites.Remove(item);
            this.Invalidate();
            return ret;
        }

        public IEnumerator<Sprite> GetEnumerator()
        {
            if (animation != null)
            {
                return animation.Sprites.GetEnumerator();
            }

            return null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (animation != null)
            {
                return animation.Sprites.GetEnumerator();
            }

            return null;
        }

        private void AnimationTimeline_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
            this.HorizontalScroll.SmallChange = frameSize.Width;
            this.Height = FrameSize.Height + SystemInformation.HorizontalScrollBarHeight + 2;
        }

        private void AnimationTimeline_DragOver(object sender, DragEventArgs e)
        {
            if (animation != null)
            {
                if (frameSize.Width > 0)
                {
                    int selected = this.PointToClient(new Point(e.X, e.Y)).X / frameSize.Width;

                    if (selected + scrollOffset / frameSize.Width < this.Count)
                    {
                        selectedFrame = selected;
                        this.Invalidate();
                    }
                }
            }
        }

        private void AnimationTimeline_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move | DragDropEffects.Copy;
        }

        private void AnimationTimeline_DragDrop(object sender, DragEventArgs e)
        {
            Sprite b = e.Data.GetData(typeof(Sprite)) as Sprite;
            int startFrame = scrollOffset / frameSize.Width;

            if (b != null && animation != null)
            {
                if (e.AllowedEffect == DragDropEffects.Copy)
                {
                    if ((e.X / frameSize.Width) > (this.Count -startFrame))
                    {
                        this.Add(b);
                    }
                    else
                    {
                        this.Insert(selectedFrame.Value + startFrame, b);
                    }
                }
                else if (e.AllowedEffect == DragDropEffects.Move)
                {
                    this.RemoveAt(dragIndex);
                    this.Insert(selectedFrame.Value + startFrame, b);
                }

                this.dragIndex = 0;
                this.selectedFrame = null;

                main.Project.Saved = false;
            }
        }
    }
}
