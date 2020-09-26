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
using EditorControls;

namespace SpriteSheetCommon
{
    public partial class ProjectExplorer : DockContent
    {
       // private CompositionHost<IImporter, IImporterMetadata> _importer = new CompositionHost<IImporter, IImporterMetadata>(Application.StartupPath + "/Importers");
        private IDE _ide;

        //public ProjectExplorer(IDE ide)
        //{
        //    InitializeComponent();

        //    this._ide = ide;
        //    this.projectTree.DrawNode += projectTree_DrawNode;

        //    foreach (Lazy<IImporter, IImporterMetadata> plugin in _importer.GetLoadedPlugins())
        //    {
        //        importToolStripMenuItem.DropDownItems.Add(plugin.Metadata.Description, null, new EventHandler(delegate { this.ImportTiles(plugin.Value.ImportTiles()); }));
        //    }
        //}

        private void projectTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            FontStyle style = this.projectTree.Font.Style;

            if (e.Node.Tag is TileLayer<Tile>)
            {
                TileLayer<Tile> layer = (TileLayer<Tile>)e.Node.Tag;

                if (!layer.Visible)
                {
                    style |= FontStyle.Strikeout;
                }

                if (e.Node.Parent.Tag is Map)
                {
                    Map map = (Map)e.Node.Parent.Tag;

                    if (map.LayerManager.ActiveLayer == layer)
                    {
                        style |= FontStyle.Bold;
                    }
                }
            }

            e.Graphics.DrawString(e.Node.Text, new Font(this.projectTree.Font.FontFamily,this.projectTree.Font.Size,style), new SolidBrush(projectTree.ForeColor), e.Bounds);
        }

        private void projectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ImportTiles(IEnumerable<Bitmap> bitmaps)
        {
            if (bitmaps != null)
            {
                TreeNode selectedNode = this.projectTree.SelectedNode;

                if (selectedNode != null)
                {
                    foreach (Bitmap bitmap in bitmaps)
                    {
                        TreeNode node = new TreeNode("test");
                        node.Tag = bitmap;
                        selectedNode.Nodes.Add(node);
                    }
                }
            }
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
                case "mapsnode":
                    {
                        MapsMenu.Show(mouseLocation);
                        break;
                    }
                case "mapnode":
                    {
                        MapMenu.Show(mouseLocation);
                        break;
                    }
                case "tilesnode":
                    {
                        TilesMenu.Show(mouseLocation);
                        break;
                    }
                case "layernode":
                    {
                        if (selectedNode.Tag is TileLayer<Tile>)
                        {
                            TileLayer<Tile> layer = (TileLayer<Tile>)selectedNode.Tag;
                            visibleToolStripMenuItem.Checked = layer.Visible;
                            LayerMenu.Show(mouseLocation);
                        }
                        break;
                    }
                case "tilefilternode":
                    {
                        TilesMenu.Show(mouseLocation);
                        break;
                    }
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Filter");
            node.Name = "TileFilterNode";

            this.projectTree.SelectedNode.Nodes.Add(node);
        }

        private void projectTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.Node.Tag is Map)
                {
                    GridWindow grid = new GridWindow((Map)e.Node.Tag);
                    grid.Show(this.DockPanel);
                }
                else if (e.Node.Tag is TileLayer<Tile>)
                {
                    TileLayer<Tile> layer = (TileLayer<Tile>)e.Node.Tag;

                    if (e.Node.Parent.Tag is Map)
                    {
                        Map map = (Map)e.Node.Parent.Tag;
                        map.LayerManager.ActiveLayer = layer;
                        this.projectTree.Invalidate();
                    }
                }
            }
        }

        private void projectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.projectTree.SelectedNode = e.Node;
                this.ShowContextMenu(e.Node,this.PointToScreen(e.Location));
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ((IDE)this.ParentForm).PropertyWindow.SelectedObject = e.Node.Tag;
            }
        }

        private void projectTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeNode node = this.projectTree.GetNodeAt(e.Location);

                if (node != null)
                {
                    this.projectTree.SelectedNode = node;

                    if (node.Tag is Bitmap)
                    {
                        this.DoDragDrop(new DragDropTile(new BitmapTile((Bitmap)node.Tag)), DragDropEffects.Copy);
                    }
                }
            }
        }

        private void projectTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Untitled");
            node.Name = "MapNode";
            node.Tag = new Map(new Size(500,500));
            
            this.projectTree.SelectedNode.Nodes.Add(node);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void layerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = this.projectTree.SelectedNode;

            if (treeNode != null)
            {
                if (treeNode.Tag is Map)
                {
                    Map map = (Map)treeNode.Tag;
                    TreeNode node = new TreeNode("Untitled");
                    node.Name = "LayerNode";
                    Random random = new Random();
                    int size = random.Next(10, 150);
                    TileLayer<Tile> tileLayer = new TileLayer<Tile>(new Size(size,size));
                    node.Tag = tileLayer;
                    map.LayerManager.Add(tileLayer);
                    map.LayerManager.ActiveLayer = tileLayer;
                    this.projectTree.SelectedNode.Nodes.Add(node);
                }
            }
           
        }

        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.projectTree.SelectedNode;
            if (node != null)
            {
                if (node.Tag is TileLayer<Tile>)
                {
                    TileLayer<Tile> layer = (TileLayer<Tile>)node.Tag;

                    layer.Visible = !layer.Visible;
                    this.projectTree.Invalidate();
                }
            }
        }
    }
}
