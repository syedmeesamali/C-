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
using IMS_System.Screens;


namespace IMS_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Loginform : Window
    {
        public Loginform() //Main loging form initialization function
        {
            InitializeComponent();
        }

        //Exit command button press
        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        //Login command button functionality
        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
                {
                //using (string constring = ConfigurationManager.ConnectionStrings["rbx"].ConnectionString) ;
                string dat1 = ConfigurationManager.ConnectionStrings["rbx"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["rbx"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Login_VerifyLoginDetails", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", userName.Text.TrimStart());
                        cmd.Parameters.AddWithValue("@Password", passBox.Password.TrimStart());
                        conn.Open();    //Open DB connection
                        
                        //MessageBox.Show(dat1);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            MessageBox.Show("Welcome!");
                            this.Hide();
                            DashboardForm df = new DashboardForm();
                            df.Show();
                            
                        } else
                        {
                            MessageBox.Show("Username or password is wrong!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    
                    } //End of sqlCommand
                        
                } //End of usingSql
                
            } //End of isValid()
        } //End of cmdLogin

        //Function to check if the input fields are empty or filled
        private bool IsValid()
        {
            if(userName.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("User name is required!", "Error");
                return false;
            }

            //Check password box
            if (passBox.Password.TrimStart() == string.Empty)
            {
                MessageBox.Show("Password is required!", "Error");
                return false;
            }

            return true;
    
        } //End of isValid function
    }//End of Login form class
} //End of main IMS system namespace
