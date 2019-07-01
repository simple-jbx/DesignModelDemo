using System;
using System.Windows.Forms;

namespace SingletonPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Tool1 tool1 = new Tool1();
            tool1.MdiParent = this;
            tool1.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Tool2.GetInstance().Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Tool3.GetInstance().Show();
        }
    }
}
