using System;
using System.Collections.Generic;
using System.IO.Ports;                  //This will make access to ports available
using System.Windows.Forms;

namespace RPI_GUI_02
{
    public partial class Form1 : Form
    {

        string ttyname;         //This is ports for RPI
        
        
        public Form1()
        {
            InitializeComponent();
        }


        //Open the serial port and send data to serial port of RPI
        private void btnSerial_Click(object sender, EventArgs e)
        {
            SerialPort serial_tty = new SerialPort();
            ttyname = @"/dev/ttyACM0";
            serial_tty.PortName = ttyname;
            serial_tty.BaudRate = 9600;
            serial_tty.Parity = Parity.None;
            serial_tty.DataBits = 8;
            serial_tty.StopBits = StopBits.One;

            try
            {
                serial_tty.Open();
                serial_tty.Write("A");
                serial_tty.Close();
                MessageBox.Show("Now sending data!", "Okay");
            } catch
            {
                MessageBox.Show("Error in opening the port!", "Okay");
            }

        }


        //Exit the app
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
