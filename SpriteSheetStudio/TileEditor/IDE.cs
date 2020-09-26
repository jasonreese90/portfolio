using EditorControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetCommon
{
    public partial class IDE : Form
    {
        public IDE()
        {
            InitializeComponent();
            //tileGrid1.LayerManager.Layers.Add(new TileLayer<Tile>(new Size(50,50)));
            //tileGrid1.LayerManager.Layers.Add(new TileLayer<Tile>(new Size(25, 25)));
            //tileGrid1.LayerManager.SetActiveLayer(0);

            PropertyWindow = new PropertiesWindow();
            //ProjectExplorer pe = new ProjectExplorer(this);
            PropertyWindow.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockRight);
           // pe.Show(dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
                      
        }

        public PropertiesWindow PropertyWindow { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tileGrid1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tileGrid1.LayerManager.SetActiveLayer(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tileGrid1.LayerManager.SetActiveLayer(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //tileGrid1.LayerManager.Layers[0].Visible = !tileGrid1.LayerManager.Layers[0].Visible;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateNewInstance();
        }

        private void CreateNewInstance()
        {
            this.CreateNewInstance(null);
        }

        private void CreateNewInstance(string args)
        {
            Process.Start(new ProcessStartInfo(Application.ExecutablePath,args));       
        }

    }
}
