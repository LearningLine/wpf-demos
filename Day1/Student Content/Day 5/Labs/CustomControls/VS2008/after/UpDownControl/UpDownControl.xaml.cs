using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControls
{
    /// <summary>
    /// Interaction logic for UpDownControl.xaml
    /// </summary>
    public partial class UpDownControl : UserControl
    {
        public UpDownControl()
        {
            InitializeComponent();

            upBtn.Click += delegate { Value++; };
            dnBtn.Click += delegate { Value--; };
            tb.PreviewKeyDown += new KeyEventHandler(tb_PreviewKeyDown);
        }

        void tb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                e.Key == Key.Delete || e.Key == Key.Back ||
                e.Key == Key.Left || e.Key == Key.Right || 
                e.Key == Key.Tab)
                return;

            e.Handled = true;
        }

        int _min = Int32.MinValue;
        public int Minimum 
        {
            get { return _min; }
            set
            {
                _min = value;
                if (Value < _min)
                    Value = _min;
            }
        }

        int _max = Int32.MaxValue;
        public int Maximum
        {
            get { return _max; }
            set
            {
                _max = value;
                if (Value > _max)
                    Value = _max;
            }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UpDownControl), 
            new UIPropertyMetadata(0, OnValueChanged));

        static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == ValueProperty)
            {
                UpDownControl upc = (UpDownControl)d;
                if (upc.Value < upc.Minimum)
                    upc.Value = upc.Minimum;
                else if (upc.Value > upc.Maximum)
                    upc.Value = upc.Maximum;
            }
        }
    }
}
