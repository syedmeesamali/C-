using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            if (!this.isUpdate)
            {

            }

            MessageBox.Show("Welcome to define products menu!");
        }
        public bool isUpdate { get; set; }

        //private void LoadAllSizesDateGridView();
        private void cmdClose_Click(object sender, EventArgs e)
        {
          //  SizesDataGridView.DataSource = GetSizeData();
        }

        private DataTable GetSizeData()
        {
            DataTable dtSizes = null;


            return dtSizes;
        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
