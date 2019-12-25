using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_System.Screens.Products
{
    public partial class DefineProducts : MetroFramework.Forms.MetroForm
    {
        public DefineProducts()
        {
            InitializeComponent();
        }

        private void DefineProducts_Load(object sender, EventArgs e)
        {

        }


        private void CmdClose_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void DefineProducts_Load_1(object sender, EventArgs e)
        {

        }
    }
}
