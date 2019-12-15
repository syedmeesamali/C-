using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;


namespace IMS_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Loginform : Window
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }//Exit application click

        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
                {
                string constring = ConfigurationManager.ConnectionStrings["rbx"].ConnectionString;
                MessageBox.Show(constring);
            };
        }//Login button click
    
        private bool IsValid()
        {
            if(userName.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("User name is required!", "Error");
                return false;
            }

            if (passBox.Password.TrimStart() == string.Empty)
            {
                MessageBox.Show("Password is required!", "Error");
                return false;
            }

            return true;
        }
            
    
    
    }
}
