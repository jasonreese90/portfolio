namespace SpriteSheetStudio
{
    partial class ProjectExplorer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("New Project");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectExplorer));
            this.projectTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ProjectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpritesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importSpritesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimationsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpriteSheetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SpriteMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectMenu.SuspendLayout();
            this.SpritesMenu.SuspendLayout();
            this.AnimationsMenu.SuspendLayout();
            this.AnimationMenu.SuspendLayout();
            this.SpriteSheetMenu.SuspendLayout();
            this.SpriteMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectTree
            // 
            this.projectTree.AllowDrop = true;
            this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTree.ImageIndex = 0;
            this.projectTree.ImageList = this.imageList1;
            this.projectTree.LabelEdit = true;
            this.projectTree.Location = new System.Drawing.Point(0, 0);
            this.projectTree.Name = "projectTree";
            treeNode1.ImageKey = "project.png";
            treeNode1.Name = "ProjectNode";
            treeNode1.SelectedImageKey = "project.png";
            treeNode1.Tag = "ProjectNode";
            treeNode1.Text = "New Project";
            this.projectTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.projectTree.SelectedImageIndex = 0;
            this.projectTree.Size = new System.Drawing.Size(284, 689);
            this.projectTree.TabIndex = 0;
            this.projectTree.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.projectTree_BeforeLabelEdit);
            this.projectTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.projectTree_AfterLabelEdit);
            this.projectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.projectTree_AfterSelect_1);
            this.projectTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.projectTree_NodeMouseClick);
            this.projectTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.projectTree_NodeMouseDoubleClick);
            this.projectTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.projectTree_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "normal_folder.png");
            this.imageList1.Images.SetKeyName(1, "anim.png");
            this.imageList1.Images.SetKeyName(2, "project.png");
            this.imageList1.Images.SetKeyName(3, "anims.png");
            this.imageList1.Images.SetKeyName(4, "sprites.png");
            this.imageList1.Images.SetKeyName(5, "spritesheets.png");
            // 
            // ProjectMenu
            // 
            this.ProjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.ProjectMenu.Name = "ProjectMenu";
            this.ProjectMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteSheetToolStripMenuItem});
            this.addToolStripMenuItem1.Image = global::SpriteSheetCommon.Properties.Resources.Button_Add_icon;
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem1.Text = "Add";
            // 
            // spriteSheetToolStripMenuItem
            // 
            this.spriteSheetToolStripMenuItem.Name = "spriteSheetToolStripMenuItem";
            this.spriteSheetToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.spriteSheetToolStripMenuItem.Text = "SpriteSheet";
            this.spriteSheetToolStripMenuItem.Click += new System.EventHandler(this.spriteSheetToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Edit_Document_icon;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Folder_Compressed_icon;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // SpritesMenu
            // 
            this.SpritesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSpritesButton,
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem3});
            this.SpritesMenu.Name = "MapMenu";
            this.SpritesMenu.Size = new System.Drawing.Size(128, 70);
            this.SpritesMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MapsMenu_Opening);
            // 
            // importSpritesButton
            // 
            this.importSpritesButton.Image = global::SpriteSheetCommon.Properties.Resources.Button_Add_icon;
            this.importSpritesButton.Name = "importSpritesButton";
            this.importSpritesButton.Size = new System.Drawing.Size(127, 22);
            this.importSpritesButton.Text = "Import";
            this.importSpritesButton.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Folder_Add_icon;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.newToolStripMenuItem.Text = "New Filter";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem3
            // 
            this.deleteToolStripMenuItem3.Image = global::SpriteSheetCommon.Properties.Resources.Button_Delete_icon;
            this.deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
            this.deleteToolStripMenuItem3.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem3.Text = "Delete";
            this.deleteToolStripMenuItem3.Click += new System.EventHandler(this.deleteToolStripMenuItem3_Click);
            // 
            // AnimationsMenu
            // 
            this.AnimationsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.AnimationsMenu.Name = "TileMenu";
            this.AnimationsMenu.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animationToolStripMenuItem});
            this.addToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Button_Add_icon;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.animationToolStripMenuItem.Text = "Animation";
            this.animationToolStripMenuItem.Click += new System.EventHandler(this.animationToolStripMenuItem_Click);
            // 
            // AnimationMenu
            // 
            this.AnimationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.AnimationMenu.Name = "AnimationMenu";
            this.AnimationMenu.Size = new System.Drawing.Size(116, 70);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Document_Preview_icon;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Edit_Document_icon;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SpriteSheetCommon.Properties.Resources.Button_Delete_icon;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // SpriteSheetMenu
            // 
            this.SpriteSheetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem2,
            this.deleteToolStripMenuItem1});
            this.SpriteSheetMenu.Name = "SpriteSheetMenu";
            this.SpriteSheetMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.Image = global::SpriteSheetCommon.Properties.Resources.Edit_Document_icon;
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem2.Text = "Edit";
            this.editToolStripMenuItem2.Click += new System.EventHandler(this.editToolStripMenuItem2_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::SpriteSheetCommon.Properties.Resources.Button_Delete_icon;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // SpriteMenu
            // 
            this.SpriteMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.deleteToolStripMenuItem2});
            this.SpriteMenu.Name = "SpriteMenu";
            this.SpriteMenu.Size = new System.Drawing.Size(116, 70);
            // 
            // previewToolStripMenuItem1
            // 
            this.previewToolStripMenuItem1.Image = global::SpriteSheetCommon.Properties.Resources.Document_Preview_icon;
            this.previewToolStripMenuItem1.Name = "previewToolStripMenuItem1";
            this.previewToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.previewToolStripMenuItem1.Text = "Preview";
            this.previewToolStripMenuItem1.Click += new System.EventHandler(this.previewToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Image = global::SpriteSheetCommon.Properties.Resources.Edit_Document_icon;
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click_1);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Image = global::SpriteSheetCommon.Properties.Resources.Button_Delete_icon;
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
            // 
            // ProjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 689);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.projectTree);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectExplorer";
            this.Text = "Project Explorer";
            this.Load += new System.EventHandler(this.ProjectExplorer_Load);
            this.ProjectMenu.ResumeLayout(false);
            this.SpritesMenu.ResumeLayout(false);
            this.AnimationsMenu.ResumeLayout(false);
            this.AnimationMenu.ResumeLayout(false);
            this.SpriteSheetMenu.ResumeLayout(false);
            this.SpriteMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView projectTree;
        private System.Windows.Forms.ContextMenuStrip ProjectMenu;
        private System.Windows.Forms.ContextMenuStrip SpritesMenu;
        private System.Windows.Forms.ContextMenuStrip AnimationsMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSpritesButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spriteSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip AnimationMenu;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip SpriteSheetMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip SpriteMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}