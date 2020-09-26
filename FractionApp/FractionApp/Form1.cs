using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fraction frac = Fraction.FromDecimal(Decimal.Parse(textBox1.Text));

            if (checkBox1.Checked)
            {
                frac = frac.Reduce();
            }

            if (checkBox2.Checked)
            {
                frac = frac.Reciprocal();
            }

            textBox2.Text = frac.ToString();
        }
    }
}
