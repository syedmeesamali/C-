﻿using System;
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
using System.Collections;

namespace my_paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList ListofPoints;  //Arraylist to store various points
        bool penDown;            //Check if pen is down

        public MainWindow()
        {
            InitializeComponent();
            ListofPoints = new ArrayList();
            penDown = false;
        }

        private void MainWindow_LeftButtonDown(object sender, MouseEventArgs e)
        {

            MessageBox.Show("Mouse pressed!");
            penDown = true;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mouse pressed!");
        }
    }
}
