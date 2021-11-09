using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RPI_GUI_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click Done!", "Yes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world from RPI via C# on Desktop and run via Mono!", "Yes");
        }
    }
}
