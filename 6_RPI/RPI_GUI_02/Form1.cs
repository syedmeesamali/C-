using System;
using System.Collections.Generic;
using System.IO.Ports;                  //This will make access to ports available
using System.Windows.Forms;

namespace RPI_GUI_02
{
    public partial class Form1 : Form
    {
        string ttyname;         //This is ports for RPI
        SerialPort serial_tty = new SerialPort();
        
        public Form1()
        {
            InitializeComponent();
            ttyname = @"/dev/ttyACM0";
            serial_tty.PortName = ttyname;
            serial_tty.BaudRate = 9600;
            serial_tty.Parity = Parity.None;
            serial_tty.DataBits = 8;
            serial_tty.StopBits = StopBits.One;
        }


        //Send 1 to serial port
        private void btnBase_Click(object sender, EventArgs e)
        {
            try
            {
                serial_tty.Open();
                serial_tty.Write("1");
                serial_tty.Close();
                MessageBox.Show("Sent 1 to Serial Port!", "Okay");
            } catch
            {
                MessageBox.Show("Error in opening the port!", "Okay");
            }
        } //End of base button

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Send 2 to serial port
        private void btnArm1_Click(object sender, EventArgs e)
        {
            try
            {
                serial_tty.Open();    serial_tty.Write("2");
                serial_tty.Close();
                MessageBox.Show("Sent 2 to Serial Port!", "Okay");
            } catch
            {
                MessageBox.Show("Error in opening the port!", "Okay");
            }
        }

        //Close the gripper - 3
        private void btnArm2_Click(object sender, EventArgs e)
        {
            try
            {
                serial_tty.Open(); serial_tty.Write("3");
                serial_tty.Close();
                MessageBox.Show("Sent 3 to Serial Port!", "Okay");
            }
            catch
            {
                MessageBox.Show("Error in opening the port!", "Okay");
            }
        }

        //Close the gripper - 4
        private void btnOpenGrip_Click(object sender, EventArgs e)
        {
            try
            {
                serial_tty.Open(); serial_tty.Write("4");
                serial_tty.Close();
                MessageBox.Show("Sent 4 to Serial Port!", "Okay");
            }
            catch
            {
                MessageBox.Show("Error in opening the port!", "Okay");
            }
        }

        //Close the gripper - 5
        private void btnCloseGrip_Click(object sender, EventArgs e)
        {
            try
            {
                serial_tty.Open(); serial_tty.Write("5");
                serial_tty.Close();
                MessageBox.Show("Sent 5 to Serial Port!", "Okay");
            }
            catch
            {
                MessageBox.Show("Error in opening the port!", "Okay");
            }
        }
    }
}
