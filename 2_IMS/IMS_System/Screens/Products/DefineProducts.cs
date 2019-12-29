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
<<<<<<< HEAD
            if(!this.isUpdate)
            {

            }
=======
            MessageBox.Show("Welcome to define products menu!");
>>>>>>> 541848cca7cbb4a4dd11d6513e574ef531c0cd38
        }
        //sizes_LoadAllSizes

<<<<<<< HEAD
        public bool isUpdate { get; set; }
        
        private void LoadAllSizesDateGridView()
=======
        private void cmdClose_Click(object sender, EventArgs e)
>>>>>>> 541848cca7cbb4a4dd11d6513e574ef531c0cd38
        {
            SizesDataGridView.DataSource = GetSizeData();
        }

<<<<<<< HEAD
        private DataTable GetSizeData()
        {
            DataTable dtSizes = null;


            return dtSizes;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        //System.Windows.Application.Current.Shutdown();

=======
        // MessageBox.Show("Welcome to define products menu!");
        //System.Windows.Application.Current.Shutdown();

>>>>>>> 541848cca7cbb4a4dd11d6513e574ef531c0cd38
    }
}
