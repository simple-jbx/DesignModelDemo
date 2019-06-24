using System;
using System.Windows.Forms;

namespace SingletonPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //toolStrip1.Click += tStripLabel1_Click;
            //toolStrip1.Click += tStripLabel2_Click;
            toolStrip1.Click += tStripLabel3_Click;
        }

        private void tStripLabel1_Click(object sender, EventArgs e)
        {
            Tool1 tool1 = new Tool1();
            tool1.Show();
            //tool1.ShowDialog();
        }

        private void tStripLabel2_Click(object sender, EventArgs e)
        {
            Tool2.GetInstance().Show();
        }

        private void tStripLabel3_Click(object sender, EventArgs e)
        {
            Tool3.GetInstance().Show();
        }
    }
}
