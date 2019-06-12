using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignModelDemo
{
    public partial class StrategyPattern : Form
    {
        public StrategyPattern()
        {
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }
    }
}
