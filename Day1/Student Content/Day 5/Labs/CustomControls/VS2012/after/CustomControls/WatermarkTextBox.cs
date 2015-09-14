using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace CustomControls
{
    class WatermarkTextBox : TextBox
    {
        bool usingWatermark;

        public string WatermarkText
        {
            get { return (string)GetValue(WatermarkTextProperty); }
            set { SetValue(WatermarkTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), 
                        typeof(WatermarkTextBox), 
                        new UIPropertyMetadata(String.Empty, OnWatermarkChanged));

        static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WatermarkTextBox wtb = (WatermarkTextBox) d;
            if (e.Property == WatermarkTextProperty && wtb.usingWatermark)
                wtb.SetWatermark();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (string.IsNullOrEmpty(this.Text))
                SetWatermark();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (string.Compare(this.Text, WatermarkText) == 0)
            {
                this.Clear();
                this.ClearValue(TextBox.ForegroundProperty);
                usingWatermark = false;
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
                SetWatermark();

            base.OnLostFocus(e);
        }

        private void SetWatermark()
        {
            this.Foreground = (Brush) FindResource(SystemColors.InactiveCaptionTextBrushKey);
            this.Text = WatermarkText;
            usingWatermark = true;
        }
    }
}
