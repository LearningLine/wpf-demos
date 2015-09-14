using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RatingControl;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void OnChangeWatermarkText(object sender, RoutedEventArgs e)
        {
            wtb.WatermarkText = "C'mon, Enter your Name!!";
        }

        private void OnScoreChanged(object sender, RoutedEventArgs e)
        {
            wtb.WatermarkText = "Current Score is: " + ((Rating)sender).Score.ToString();
        }
    }
}
