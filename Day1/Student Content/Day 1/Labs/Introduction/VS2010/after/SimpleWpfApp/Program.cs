using System;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace SimpleWpfApp
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Window w = new Window
               {
                   Title = "Hello, Wpf",
                   Width = 480,
                   Height = 384,
                   Background = new LinearGradientBrush(Colors.LightSeaGreen, Colors.Yellow, 45.0)
               };

            w.Loaded += w_Loaded;

            Application app = new Application();
            app.Run(w);
        }

        static void w_Loaded(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse {Stroke = Brushes.Red, StrokeThickness = 1};

            ImageBrush brush = new ImageBrush();
            ImageSourceConverter isc = new ImageSourceConverter();
            brush.ImageSource = (ImageSource) isc.ConvertFrom(@".\img1.jpg");

            ellipse.Fill = brush;
            ellipse.MouseEnter += ellipse_MouseEnter;
            ellipse.MouseLeave += ellipse_MouseLeave;

            ellipse.Width = 200;
            ellipse.Height = 200;

            ListBox listBox = new ListBox();
            listBox.Items.Add(ellipse);

            listBox.Background = null;

            Button button = new Button();
            button.Width = 200;
            button.Height = 50;
            button.Content = "I Dare You to Click Me";
            button.Click += OnClick;

            listBox.Items.Add(button);

            Window win = (Window)sender;
            win.Content = listBox;
        }

        static void ellipse_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            ellipse.Effect = null;
        }

        static void ellipse_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            ellipse.Effect = new DropShadowEffect { Color = Colors.DeepPink, BlurRadius = 30, ShadowDepth = 0 };
        }

        static void OnClick(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(@".\tada.wav");
            sp.Play();
        }
    }
}
