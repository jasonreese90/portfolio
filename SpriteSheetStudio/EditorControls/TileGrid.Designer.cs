namespace EditorControls
{
    partial class TileGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TileGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TileGrid";
            this.Load += new System.EventHandler(this.TileGrid_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TileGrid_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TileGrid_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.TileGrid_DragOver);
            this.DragLeave += new System.EventHandler(this.TileGrid_DragLeave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TileGrid_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
