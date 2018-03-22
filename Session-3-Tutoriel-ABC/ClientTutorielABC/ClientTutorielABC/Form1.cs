using ClientTutorielABC.MathsService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTutorielABC
{
    public partial class Form1 : Form
    {
        private MathsOperationsClient serviceReference0 = new MathsOperationsClient("basic0");
        private MathsOperationsClient serviceReference1 = new MathsOperationsClient("basic1");
        private MathsOperationsClient serviceReference2 = new MathsOperationsClient("ws0");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = serviceReference0.Add(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
            label3.Text = serviceReference1.Add(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
            label4.Text = serviceReference2.Add(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = serviceReference0.Sub(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
            label3.Text = serviceReference1.Sub(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
            label4.Text = serviceReference2.Sub(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = serviceReference0.Divide(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
            label3.Text = serviceReference1.Divide(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
            label4.Text = serviceReference2.Divide(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)).ToString();
        }
    }
}
