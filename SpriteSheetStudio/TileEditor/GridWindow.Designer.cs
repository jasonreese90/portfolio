namespace SpriteSheetCommon
{
    partial class GridWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tileGrid1 = new EditorControls.TileGrid();
            this.SuspendLayout();
            // 
            // tileGrid1
            // 
            this.tileGrid1.AllowDrop = true;
            this.tileGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileGrid1.GridColor = System.Drawing.Color.Black;
            this.tileGrid1.GridSize = new System.Drawing.Size(625, 625);
            this.tileGrid1.GridThickness = 1;
            this.tileGrid1.Location = new System.Drawing.Point(0, 0);
            this.tileGrid1.Name = "tileGrid1";
            this.tileGrid1.SelectionColor = System.Drawing.Color.Yellow;
            this.tileGrid1.Size = new System.Drawing.Size(741, 469);
            this.tileGrid1.TabIndex = 0;
            // 
            // GridWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 469);
            this.Controls.Add(this.tileGrid1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GridWindow";
            this.Text = "GridWindow";
            this.Load += new System.EventHandler(this.GridWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridWindow_DragDrop);
            this.ResumeLayout(false);

        }

        #endregion

        private EditorControls.TileGrid tileGrid1;

    }
}