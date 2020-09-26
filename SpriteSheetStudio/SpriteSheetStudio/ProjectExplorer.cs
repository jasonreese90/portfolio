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
using SpriteSheetCommon;
using PluginInferaces.SpriteSheet;
using PluginInterfaces;

namespace SpriteSheetStudio
{
    public partial class ProjectExplorer : DockContent
    {
        private CompositionHost<ISpriteImporter, IDescriptionMetadata> spriteImporter = new CompositionHost<ISpriteImporter, IDescriptionMetadata>(Application.StartupPath + "/plugins/importers");
        private CompositionHost<ISpriteSheetExporter, IDescriptionMetadata> spriteSheetExporters = new CompositionHost<ISpriteSheetExporter, IDescriptionMetadata>(Application.StartupPath + "/plugins/exporters");
        private Main main;

        public ProjectExplorer(Main main)
        {
            InitializeComponent();

            this.main = main;

            foreach (Lazy<ISpriteImporter, IDescriptionMetadata> p in spriteImporter.GetLoadedPlugins())
            {
                importSpritesButton.DropDownItems.Add(string.Format("{0} - {1} - {2}",p.Metadata.Description,p.Metadata.Author,p.Metadata.Version), p.Metadata.Icon, new EventHandler(delegate { this.ImportSprites(p.Value.ImportSprites()); }));
            }

            foreach (Lazy<ISpriteSheetExporter, IDescriptionMetadata> p in spriteSheetExporters.GetLoadedPlugins())
            {
                exportToolStripMenuItem.DropDownItems.Add(p.Metadata.Description, null, new EventHandler(delegate { p.Value.ExportSpriteSheet(main.Project); }));
            }
        }

        public event EventHandler<SpriteSheet> SpriteSheetAdded;
        public event EventHandler<Animation> AnimationSelectionChanged;

        public void LoadSpriteSheetProject(SpriteSheetProject spriteSheetProject)
        {
            projectTree.Nodes.Clear();

            TreeNode projectNode = new TreeNode(spriteSheetProject.ProjectName);
            projectNode.Name = "ProjectNode";
            projectNode.SelectedImageKey = projectNode.ImageKey = "project.png";

            foreach (SpriteSheet ss in spriteSheetProject.SpriteSheets)
            {
                AddSpriteSheet(projectNode, ss);
            }

            projectTree.Nodes.Add(projectNode);
        }

        private void ShowContextMenu(TreeNode selectedNode,Point mouseLocation)
        {
            switch (selectedNode.Name.ToLower())
            {
                case "projectnode":
                    {
                        ProjectMenu.Show(mouseLocation);
                        break;
                    }
                case "spritesnode":
                    {
                        SpritesMenu.Show(mouseLocation);
                        break;
                    }
                case "spritenode":
                    {
                        SpriteMenu.Show(mouseLocation);
                        break;
                    }
                case "spritefilternode":
                    {
                        SpritesMenu.Show(mouseLocation);
                        break;
                    }
                case "animationsnode":
                    {
                        AnimationsMenu.Show(mouseLocation);
                        break;
                    }
                case "animationnode":
                    {
                        AnimationMenu.Show(mouseLocation);
                        break;
                    }
                case "spritesheetnode":
                    {
                        SpriteSheetMenu.Show(mouseLocation);
                        break;
                    }
            }
        }

        private void ImportSprites(IEnumerable<Sprite> sprites)
        {
            if (sprites != null)
            {
                TreeNode selectedNode = this.projectTree.SelectedNode;

                if (selectedNode != null)
                {
                    foreach (Sprite s in sprites)
                    {
                        if (selectedNode.Tag is SpriteSheet)
                        {
                            bool duplicate = false;
                            SpriteSheet spriteSheet = (SpriteSheet)selectedNode.Tag;
                            TreeNode spritesNode = selectedNode;

                            foreach (Sprite sp in spriteSheet.Sprites)
                            {
                                if (sp.Name.ToLower() == s.Name.ToLower())
                                {
                                    duplicate = true;
                                    break;
                                }
                            }

                            if (duplicate)
                            {
                                MessageBox.Show(string.Format("SpriteSheet {0} already contains sprite {1}", spriteSheet.Name, s.Name));
                                continue;
                            }

                            TreeNode node = new TreeNode(s.Name);
                            node.Name = "SpriteNode";
                            imageList1.Images.Add(s.Name, s.Image);
                         
                            node.ImageKey = s.Name;
                            node.SelectedImageKey = node.ImageKey;
                

                            while (spritesNode.Name != "SpritesNode")
                            {
                                spritesNode = spritesNode.Parent;
                            }

                            Sprite sprite = new Sprite(s.Name,s.Image);

                            sprite.Path = selectedNode.FullPath.Replace(spritesNode.FullPath, "");

                            node.Tag = sprite;

                            selectedNode.Nodes.Add(node);
                            spriteSheet.Sprites.Add(sprite);
                        }
                    }

                    main.Project.Saved = false;
                }
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Filter");
            node.Name = "TileFilterNode";
   
            this.projectTree.SelectedNode.Nodes.Add(node);
        }

        private void projectTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeNode node = this.projectTree.GetNodeAt(e.Location);

                if (node != null)
                {
                    this.projectTree.SelectedNode = node;

                    if (node.Tag is Sprite)
                    {
                        Sprite sprite = (Sprite)node.Tag;
                        this.DoDragDrop(sprite, DragDropEffects.Copy);
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void projectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.projectTree.SelectedNode = e.Node;
                this.ShowContextMenu(e.Node, this.PointToScreen(e.Location));
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void projectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MapsMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void projectTree_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpriteFilterDialog sfd = new SpriteFilterDialog(this.projectTree.SelectedNode))
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TreeNode node = new TreeNode(sfd.SpriteFilterName);
                    node.Name = "SpriteFilterNode";
                    node.Tag = projectTree.SelectedNode.Tag;

                    this.projectTree.SelectedNode.Nodes.Add(node);
                    main.Project.Saved = false;
                }
            }
        }

        private void AddSpriteSheet(TreeNode projectNode, SpriteSheet spriteSheet)
        {
            TreeNode node = new TreeNode(spriteSheet.Name);
            node.Name = "SpriteSheetNode";
            node.Tag = spriteSheet;
            node.SelectedImageKey = node.ImageKey = "spritesheets.png";

            TreeNode spritesNode = new TreeNode("Sprites");
            spritesNode.Name = "SpritesNode";
            spritesNode.Tag = spriteSheet;
            spritesNode.SelectedImageKey = spritesNode.ImageKey = "sprites.png";

            foreach (Sprite s in spriteSheet.Sprites)
            {
                TreeNode spriteNode = new TreeNode(s.Name);

                imageList1.Images.Add(s.Name,s.Image);
                spriteNode.Name = "SpriteNode";
                spriteNode.ImageKey = s.Name;
                spriteNode.SelectedImageKey = spriteNode.ImageKey;
                spriteNode.Tag = s;

                if (s.Path == "")
                {
                    spritesNode.Nodes.Add(spriteNode);
                }
                else
                {
                    AddSprite(spritesNode, spriteNode, s.Path);
                }
            }

            TreeNode animationsNode = new TreeNode("Animations");
            animationsNode.Name = "AnimationsNode";
            animationsNode.Tag = spriteSheet;
            animationsNode.SelectedImageKey = animationsNode.ImageKey = "anims.png";

            foreach (Animation a in spriteSheet.Animations.ToList())
            {
                TreeNode animationNode = new TreeNode(a.Name);
                animationNode.Tag = a;
                animationNode.Name = "AnimationNode";
                animationNode.SelectedImageKey = animationNode.ImageKey = "anim.png";

                animationsNode.Nodes.Add(animationNode);
            }

            node.Nodes.Add(spritesNode);
            node.Nodes.Add(animationsNode);

            projectNode.Nodes.Add(node);
        }

        private void AddSprite(TreeNode node, TreeNode spriteNode,string path)
        {
            string[] split = path.Split('\\');

            foreach (string s in split)
            {
                if (s != "")
                {
                    bool containsNode = false;

                    foreach (TreeNode n in node.Nodes)
                    {
                        if (n.Text.ToLower() == s.ToLower())
                        {
                            node = n;
                            containsNode = true;
                        }
                    }

                    if (!containsNode)
                    {
                        TreeNode n = new TreeNode(s);
                        n.Tag = node.Tag;
                        n.Name = "SpriteFilterNode";
                        node.Nodes.Add(n);
                        node = n;
                    }
                }
            }

            node.Nodes.Add(spriteNode);
        }

        private void spriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpriteSheet s = new SpriteSheet();

            using (SpriteSheetDialog ssd = new SpriteSheetDialog(main.Project,s))
            {
                if (ssd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TreeNode node = new TreeNode(ssd.SpriteSheetName);
                    node.Name = "SpriteSheetNode";
                    node.SelectedImageKey = node.ImageKey = "spritesheets.png";

                    TreeNode spritesNode = new TreeNode("Sprites");
                    spritesNode.Name = "SpritesNode";
                    spritesNode.SelectedImageKey = spritesNode.ImageKey = "sprites.png";

                    TreeNode animationsNode = new TreeNode("Animations");
                    animationsNode.Name = "AnimationsNode";
                    animationsNode.SelectedImageKey = animationsNode.ImageKey = "anims.png";


                    node.Nodes.Add(spritesNode);
                    node.Nodes.Add(animationsNode);

                    s.Name = ssd.SpriteSheetName;
                    node.Tag = s;

                    spritesNode.Tag = node.Tag;
                    animationsNode.Tag = node.Tag;

                    if (SpriteSheetAdded != null)
                    {
                        SpriteSheetAdded(this, (SpriteSheet)node.Tag);
                    }

                    this.projectTree.SelectedNode.Nodes.Add(node);
                    main.Project.Saved = false;
                }
            }
        }

        private void projectTree_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Name.ToLower() != "spritenode" && e.Node.Name.ToLower() != "spritefilternode" && e.Node.Name.ToLower() != "projectnode")
            {
                e.CancelEdit = true;
            }
        }

        private void projectTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label) || e.Node.Text.ToLower() == e.Label.ToLower())
            {
                e.CancelEdit = true;
                return;
            }

            switch(e.Node.Name.ToLower())
            {
                case "projectnode":
                    {
                        main.Project.ProjectName = e.Label;
                        main.Project.Saved = false;
                        break;
                    }
                case "spritenode":
                    {
                        SpriteSheet ss = (SpriteSheet)e.Node.Parent.Tag;
                        Sprite s = (Sprite)e.Node.Tag;
                        bool contains = false;

                        foreach (Sprite sprite in ss.Sprites)
                        {
                            if (sprite.Name.ToLower() == s.Name.ToLower())
                            {
                                contains = true;
                                break;
                            }
                        }

                        if (!contains)
                        {
                            s.Name = e.Label;
                            main.Project.Saved = false;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("SpriteSheet \"{0}\" already contains a sprite with the name \"{1}\".", ss.Name, e.Label));
                            e.CancelEdit = true;
                        }

                        break;
                    }
                case "spritefilternode":
                    {
                        bool contains = false;

                        foreach (TreeNode n in e.Node.Parent.Nodes)
                        {
                            if (n.Name.ToLower() == "spritefilternode")
                            {
                                if(n.Text.ToLower() == e.Label.ToLower())
                                {
                                    contains = true;
                                    break;
                                }
                            }
                        }

                        if (!contains)
                        {
                            e.Node.Text = e.Label;
                                 main.Project.Saved = false;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("\"{0}\" already contains a filter named \"{1}\".",e.Node.Parent.Text,e.Label));
                            e.CancelEdit = true;
                        }

                        break;
                    }
            }
        }

        private void animationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode.Tag is SpriteSheet)
            {
                SpriteSheet s = (SpriteSheet)projectTree.SelectedNode.Tag;
                Animation a = new Animation();

                using (AnimationDialog ad = new AnimationDialog(s,a))
                {
                    if (ad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        a.Framerate = ad.Framerate;
                        a.Name = ad.AnimationName;
                        TreeNode animationNode = new TreeNode(a.Name);
                        animationNode.Name = "AnimationNode";
                        animationNode.Tag = a;

                        animationNode.SelectedImageKey = animationNode.ImageKey = "anim.png";

                        s.Animations.Add(a);

                        projectTree.SelectedNode.Nodes.Add(animationNode);
                        main.Project.Saved = false;
                    }
                }
            }
        }

        private void projectTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is Animation)
            {
                Animation a = (Animation)e.Node.Tag;

                if (AnimationSelectionChanged != null)
                {
                    AnimationSelectionChanged(this, a);
                }
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.ShowAnimation((Animation)projectTree.SelectedNode.Tag);
        }

        private void ProjectExplorer_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
 
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SpriteSheet s = (SpriteSheet)projectTree.SelectedNode.Tag;

            using (SpriteSheetDialog ssd = new SpriteSheetDialog(main.Project, s))
            {
                if (ssd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    projectTree.SelectedNode.Text = ssd.SpriteSheetName;
                    s.Name = ssd.SpriteSheetName;
                    main.Project.Saved = false;
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpriteSheet s = (SpriteSheet)projectTree.SelectedNode.Parent.Tag;
            Animation a = (Animation)projectTree.SelectedNode.Tag;

            using (AnimationDialog ad = new AnimationDialog(s, a))
            {
                if (ad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    projectTree.SelectedNode.Text = ad.AnimationName;
                    a.Name = ad.AnimationName;
                    a.Framerate = ad.Framerate;
                    main.Project.Saved = false;
                }
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectTree.SelectedNode.BeginEdit();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode.Tag is Animation)
            {
                Animation a = (Animation)projectTree.SelectedNode.Tag;
                SpriteSheet s = (SpriteSheet)projectTree.SelectedNode.Parent.Tag;

                main.ClearAnimationIfActive(a);

                s.Animations.Remove(a);
                projectTree.SelectedNode.Remove();
                main.Project.Saved = false;
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode.Tag is SpriteSheet)
            {
                SpriteSheet s = (SpriteSheet)projectTree.SelectedNode.Tag;

                this.main.Project.SpriteSheets.Remove(s);
                projectTree.SelectedNode.Remove();
                main.Project.Saved = false;
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode.Tag is Sprite)
            {
                Sprite sprite = (Sprite)projectTree.SelectedNode.Tag;
                SpriteSheet s = (SpriteSheet)projectTree.SelectedNode.Parent.Tag;

                Animation[] anims = main.GetSpriteDependancies(s, sprite);

                if (anims.Length > 0)
                {
                    string message = "";

                    foreach (Animation a in anims)
                    {
                        message += string.Format("   Animation {2}.{0} is dependant on sprite {2}.{1}.\n", a.Name, sprite.Name, s.Name);

                    }

                    message += "\nPlease remove dependancies before trying again.";

                    MessageBox.Show(message, "Dependancy found.",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    s.Sprites.Remove(sprite);
                    projectTree.SelectedNode.Remove();
                    main.Project.Saved = false;
                }
            }
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode.Name.ToLower() == "spritefilternode" || projectTree.SelectedNode.Name.ToLower() == "spritesnode")
            {
                DeleteSprites(projectTree.SelectedNode);
                projectTree.SelectedNode.Nodes.Clear();

                if (projectTree.SelectedNode.Name.ToLower() != "spritesnode")
                {
                    projectTree.SelectedNode.Remove();
                }

                main.Project.Saved = false;
            }
        }

        private void DeleteSprites(TreeNode node)
        {
            if (node.Name.ToLower() == "spritefilternode" || node.Name.ToLower() == "spritesnode")
            {
                foreach (TreeNode n in node.Nodes)
                {
                    DeleteSprites(n);
                }
            }
            else if (node.Name.ToLower() == "spritenode")
            {
                
                SpriteSheet ss = (SpriteSheet)node.Parent.Tag;
                Sprite s = (Sprite)node.Tag;
                Animation[] anims = main.GetSpriteDependancies(ss, s);

                if (anims.Length > 0)
                {
                    string message = "";

                    foreach (Animation a in anims)
                    {
                        message += string.Format("   Animation {2}.{0} is dependant on sprite {2}.{1}.\n", a.Name, s.Name,ss.Name);
                    }

                    message += "\nPlease remove dependancies before trying again.";

                    MessageBox.Show(message, "Dependancy found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ss.Sprites.Remove(s);
                    main.Project.Saved = false;
                }
            }
        }

        private void editToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            projectTree.SelectedNode.BeginEdit();
        }

        private void previewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode.Tag is Sprite)
            {
                Sprite s = (Sprite)projectTree.SelectedNode.Tag;

                this.main.ShowPreview(s);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
