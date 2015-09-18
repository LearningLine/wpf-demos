using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

// Identify where theme dictionaries are stored
[assembly: ThemeInfo(ResourceDictionaryLocation.SourceAssembly, ResourceDictionaryLocation.SourceAssembly)]

namespace RatingControl
{
    [TemplatePart(Name="PART_Track", Type=typeof(FrameworkElement))]
    public class Rating : Control
    {
        const int MINIMUM_VALUE = 0;
        const int MAXIMUM_VALUE = 5;

        static Rating()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Rating),
                new FrameworkPropertyMetadata(typeof(Rating)));
        }

        public static RoutedEvent ScoreChangedEvent =
            EventManager.RegisterRoutedEvent("ScoreChanged", RoutingStrategy.Direct,
                    typeof(RoutedEventHandler), typeof(Rating));

        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(int), typeof(Rating),
            new UIPropertyMetadata(0, OnScoreChanged, OnCoerceScore));

        public event RoutedEventHandler ScoreChanged
        {
            add
            {
                this.AddHandler(ScoreChangedEvent, value);
            }
            
            remove
            {
                this.RemoveHandler(ScoreChangedEvent, value);
            }
        }

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        static void OnScoreChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Rating r = (Rating)d;
            r.OnScoreChanged((int) e.OldValue, (int) e.NewValue);
        }

        static object OnCoerceScore(DependencyObject d, object value)
        {
            Rating r = (Rating)d;
            int proposedValue = (int)value;
            if (proposedValue < MINIMUM_VALUE)
                proposedValue = MINIMUM_VALUE;
            else if (proposedValue > MAXIMUM_VALUE)
                proposedValue = MAXIMUM_VALUE;

            return proposedValue;
        }

        public virtual void OnScoreChanged(int oldValue, int newValue)
        {
            RaiseEvent(new RoutedEventArgs(ScoreChangedEvent));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            FrameworkElement fe = this.Template.FindName("PART_Track", this) as FrameworkElement;
            if (fe == null)
                throw new Exception("Missing PART_Track from Rating control template");
            
            fe.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, 
                new MouseButtonEventHandler(OnClickRating), true);
        }

        void OnClickRating(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = (FrameworkElement)sender;
            Debug.Assert(fe != null);

            Point pt = e.GetPosition(fe);
            double width = fe.ActualWidth;
            if (width != Double.NaN)
                Score = (int) Math.Round(pt.X / (width / MAXIMUM_VALUE), 0, MidpointRounding.AwayFromZero);
        }
    }
}
