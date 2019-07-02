using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MementoPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Enabled = false;
            label2.Enabled = false;
        }

        private TextStateCaretaker caretaker = new TextStateCaretaker();
        private Text text = new Text();
        private TextStateMemento memento;
        private bool isClick = false;

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.AllowScriptChange = true;
            fontDialog.ShowColor = true;
            fontDialog.ShowHelp = true;
            fontDialog.ShowEffects = true;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                //获取选择的颜色给控件
                textBox.ForeColor = fontDialog.Color;
                text.TextColor = textBox.ForeColor;
                //获取选择的字体给控件，
                textBox.Font = fontDialog.Font;
                text.TextFont = textBox.Font;
                caretaker.addMemento(text.setState());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            memento = caretaker.revocationMemento();
            text.recoveryState(memento);
            setTextBox();
            setLabel();
            isClick = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            memento = caretaker.renewalMemento();         
            text.recoveryState(memento);
            setTextBox();
            setLabel();
            isClick = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if(isClick)
            {
                isClick = false;
            }
            else
            {
                text.TextStr = textBox.Text;
                caretaker.addMemento(text.setState());
                setLabel();
            }
        }

        public void setTextBox()
        {
            textBox.Text = text.TextStr;
            textBox.ForeColor = text.TextColor;
            textBox.Font = text.TextFont;
        }

        public void setLabel()
        {
            if(caretaker.isRevocation())
            {
                label1.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
            }

            if(caretaker.isRenewal())
            {
                label2.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
            }
        }
    }
}
