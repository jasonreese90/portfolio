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

namespace GenericSpriteSheetImporter
{
    public partial class SpriteSheetImporter : Form
    {
        private Color lineColor = Color.Yellow;
        private readonly string OpenFilter = "PNG|*.png|GIF|*.gif|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIFF|*.tiff;*.tiff|Bitmap|*.bmp;*.dib";

        public SpriteSheetImporter()
        {
            InitializeComponent();

            button4.BackColor = lineColor;
        }

        public Sprite[] GetSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            int x = (int)numericUpDown2.Value;
            int y = (int)numericUpDown1.Value;

            int rowSize = pictureBox1.Image.Height / y;
            int colSize = pictureBox1.Image.Width / x;

            for (int i = 0; i < y; i++)
            {
                for (int c = 0; c < x; c++)
                {
                    Bitmap b = new Bitmap(colSize, rowSize);

                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(pictureBox1.Image, 0, 0, new Rectangle(c * colSize, i * rowSize, colSize, rowSize), GraphicsUnit.Pixel);

                        Sprite s = new Sprite(string.Format("{0}{1}",textBox1.Text, y*i+ c), b);
                        sprites.Add(s);
                    }
                }
            }

            return sprites.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = OpenFilter;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                int rowSize = (int)(pictureBox1.Height / numericUpDown1.Value);

                for (int i = 1; i < numericUpDown1.Value; i++)
                {
                    e.Graphics.DrawLine(new Pen(lineColor), new Point(0, i * rowSize), new Point(pictureBox1.Width, i * rowSize));
                }
            }

            if (numericUpDown2.Value > 0)
            {
                int colSize = (int)(pictureBox1.Width / numericUpDown2.Value);

                for (int i = 1; i < numericUpDown2.Value; i++)
                {
                    e.Graphics.DrawLine(new Pen(lineColor), new Point(i * colSize, 0), new Point(i * colSize, pictureBox1.Height));
                }
            }
           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    button4.BackColor = cd.Color;
                    lineColor = cd.Color;

                    pictureBox1.Invalidate();
                }
            }
        }
    }
}
