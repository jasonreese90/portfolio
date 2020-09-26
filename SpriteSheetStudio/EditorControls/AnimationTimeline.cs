using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorControls
{
    public partial class AnimationTimeline : UserControl, IList<Bitmap>
    {
        private IList<Bitmap> Bitmaps;
        private Size frameSize;
        private int? selectedFrame = null;
        private int dragIndex = 0;
        private int scrollOffset = 0;

        public AnimationTimeline()
        {
            InitializeComponent();
            Bitmaps = new List<Bitmap>();
            FrameSize = new Size(50, 50);
        }

        private AnimationTimeline(IList<Bitmap> Bitmaps)
            : this()
        {
            this.Bitmaps = Bitmaps;
            this.Invalidate();
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

        public Bitmap SelectedImage
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


        public void SetBitmaps(IList<Bitmap> bitmaps)
        {
            this.Bitmaps = bitmaps;
            this.selectedFrame = null;
            this.dragIndex = 0;

            this.Invalidate();
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
            base.OnMouseClick(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            if (frameSize.Width > 0 && frameSize.Height > 0)
            {
                int startFrame = scrollOffset / frameSize.Width;
                int endFrame = (this.Width / FrameSize.Width + 1) + startFrame;

                if (endFrame > this.Count)
                    endFrame = this.Count;

                for (int i = startFrame; i < endFrame; i++)
                {
                    e.Graphics.DrawImage(this[i], new Rectangle(new Point(FrameSize.Width * (i - startFrame) + LineThickness, LineThickness), FrameSize));
                    e.Graphics.DrawRectangle(new Pen(LineColor, LineThickness), new Rectangle(new Point(FrameSize.Width * (i - startFrame), 0), new Size(FrameSize.Width + LineThickness, FrameSize.Height + LineThickness)));
                }

                if (selectedFrame != null)
                {
                    e.Graphics.DrawRectangle(new Pen(SelectedColor, LineThickness), new Rectangle(new Point(FrameSize.Width * selectedFrame.Value, 0), new Size(FrameSize.Width + LineThickness, FrameSize.Height + LineThickness)));
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

        public int IndexOf(Bitmap item)
        {
            return Bitmaps.IndexOf(item);
        }

        public void Insert(int index, Bitmap item)
        {
            Bitmaps.Insert(index, item);
            this.Invalidate();
        }

        public void RemoveAt(int index)
        {
            if (index < this.Count)
            {
                Bitmaps.RemoveAt(index);
                this.Invalidate();
            }
        }

        public Bitmap this[int index]
        {
            get
            {
                return Bitmaps[index];
            }
            set
            {
                Bitmaps[index] = value;
            }
        }

        public void Add(Bitmap item)
        {
            Bitmaps.Add(item);
            this.AutoScrollMinSize = new Size(Bitmaps.Count * FrameSize.Width, 0);
            this.Invalidate();
        }

        public void Clear()
        {
            Bitmaps.Clear();
            this.Invalidate();
        }

        public bool Contains(Bitmap item)
        {
            return Bitmaps.Contains(item);
        }

        public void CopyTo(Bitmap[] array, int arrayIndex)
        {
            Bitmaps.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Bitmaps.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Bitmap item)
        {
            bool ret = Bitmaps.Remove(item);
            this.Invalidate();
            return ret;
        }

        public IEnumerator<Bitmap> GetEnumerator()
        {
            return Bitmaps.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Bitmaps.GetEnumerator();
        
        }

        public static implicit operator List<Bitmap>(AnimationTimeline timeline)
        {
            return timeline;
        }

        public static implicit operator AnimationTimeline(List<Bitmap> Bitmaps)
        {
            return new AnimationTimeline(Bitmaps);
        }

        private void AnimationTimeline_Load(object sender, EventArgs e)
        {
            this.AutoScrollMinSize = new Size(this.Width + 1, 0);
            this.ResizeRedraw = true;
            this.HorizontalScroll.SmallChange = frameSize.Width;
            this.Height = FrameSize.Height + SystemInformation.HorizontalScrollBarHeight + 2;
        }

        private void AnimationTimeline_DragOver(object sender, DragEventArgs e)
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

        private void AnimationTimeline_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void AnimationTimeline_DragDrop(object sender, DragEventArgs e)
        {
            Bitmap b = e.Data.GetData(typeof(Bitmap)) as Bitmap;

            if (b != null)
            {
                if (selectedFrame != null)
                {
                    int startFrame = scrollOffset / frameSize.Width;
                    this.RemoveAt(dragIndex);
                    this.Insert(selectedFrame.Value + startFrame, b);
                    this.dragIndex = 0;
                    this.selectedFrame = null;
                }
                else
                {
                    this.Add(b);
                }
            }
        }
    }
}
