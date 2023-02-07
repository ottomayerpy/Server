using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_WriteText : Form
    {
        public string PathOne;
        public string PathTwo;
        public bool TrueExit;

        public Form_WriteText(string Com, string Path, byte mode)
        {
            InitializeComponent();
            if (Com != null)
                Text = Com;
            if (mode == 1)
            {
                TxtBoxPathOne.Text = Path;
                TxtBoxPathOne.ReadOnly = true;
                TxtBoxPathOne.BackColor = System.Drawing.SystemColors.Control;
            }
            if (mode == 2)
            {
                TxtBoxPathTwo.Text = Path;
                TxtBoxPathTwo.ReadOnly = true;
                TxtBoxPathTwo.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (TxtBoxPathOne != null)
            {
                if (TxtBoxPathTwo.Enabled)
                {
                    if (TxtBoxPathTwo != null)
                    {
                        PathOne = TxtBoxPathOne.Text;
                        PathTwo = TxtBoxPathTwo.Text;
                        TrueExit = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены должным образом");
                    }
                }
                else
                {
                    PathOne = TxtBoxPathOne.Text;
                    TrueExit = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены должным образом");
            }
        }
    }
}