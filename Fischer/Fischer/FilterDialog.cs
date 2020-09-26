using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fischer
{
    public partial class FilterDialog : Form
    {
        public FilterDialog()
        {
            InitializeComponent();
            groupBox2.Enabled = false;
        }

        public FilterMode Filter
        {
            get;
            private set;
        }

        /// <summary>
        /// Only applicable if filter is range
        /// </summary>
        public DateTime FilterDateStart
        {
            get;
            private set;
        }

        /// <summary>
        /// Only applicable if filter is range
        /// </summary>
        public DateTime FilterDateEnd
        {
            get;
            private set;
        }


        private void FilterDialog_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Filter = FilterMode.All;
            groupBox2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Filter = FilterMode.Today;
            groupBox2.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Filter = FilterMode.Range;
            groupBox2.Enabled = true;


        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterDateStart = dateTimePicker1.Value;
            FilterDateEnd = dateTimePicker2.Value;
        }
    }
}
