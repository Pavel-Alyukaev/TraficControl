using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraficControl
{
    public partial class ParamDetect : Form
    {
        public ParamDetect()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            textBox3.Text = "20";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.WindowsSize = int.Parse(textBox3.Text);
            Form1.ScaleIncreaseRate = double.Parse(comboBox1.Text);
            Form1.MinNeighbors = int.Parse(comboBox2.Text);
            Close();

        }

        private void ParamDetect_Load(object sender, EventArgs e)
        {
            comboBox1.Text = Form1.ScaleIncreaseRate.ToString();
            comboBox2.Text = Form1.MinNeighbors.ToString();
            textBox3.Text = Form1.WindowsSize.ToString();
        }
    }
}
