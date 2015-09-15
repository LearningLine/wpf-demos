using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace ArtCanvas
{
    public partial class MainWindow
    {
        #region Private Data
        private double _currentThickness = 2;
        private bool _mouseDown, _existingShape;
        private Shape _tempShape;
        private Point _startPoint;
        private int _lastZIndex = 1;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            currentBackground.IsChecked = true;
            currentForeground.IsChecked = true;
            currentShape.IsChecked = true;

            DrawingSurface.PreviewMouseLeftButtonDown += OnStartShape;
            DrawingSurface.PreviewMouseMove += OnMoveOrSizeShape;
            DrawingSurface.PreviewMouseLeftButtonUp += OnEndShape;
        }

        /// <summary>
        /// Called to change the background color of the shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangeBackground(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton) e.Source;
            if (currentBackground != null)
                currentBackground.IsChecked = false;
            tb.IsChecked = true;
            currentBackground = tb;
        }

        /// <summary>
        /// Called to change the foreground color of the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangeForeground(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton)e.Source;
            if (currentForeground != null)
                currentForeground.IsChecked = false;
            tb.IsChecked = true;
            currentForeground = tb;
        }

        /// <summary>
        /// Called to change the shape geometry (ellipse or rectangle)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangeShape(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton)e.Source;
            if (currentShape != null)
                currentShape.IsChecked = false;
            tb.IsChecked = true;
            currentShape = tb;
        }

        /// <summary>
        /// Called to change the thickness of the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangeThickness(object sender, RoutedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            _currentThickness = ((Rectangle)cb.SelectedItem).Height;
        }

        /// <summary>
        /// This is used when the MouseDown event occurs to begin drawing or moving a shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnStartShape(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _startPoint = e.GetPosition(DrawingSurface);

            // See if we hit an existing shape in the Canvas.
            _tempShape = DrawingSurface.InputHitTest(_startPoint) as Shape; 
            if (_tempShape != null)
            {
                _existingShape = true;
            }
            else
            {
                _existingShape = false;
                _tempShape = (Shape)Activator.CreateInstance(currentShape.Content.GetType());
                Canvas.SetLeft(_tempShape, _startPoint.X);
                Canvas.SetTop(_tempShape, _startPoint.Y);
                DrawingSurface.Children.Add(_tempShape);
            }

            // Set the properties based on the current settings
            _tempShape.Opacity = .5;
            _tempShape.Stroke = ((Shape)currentForeground.Content).Fill;
            _tempShape.Fill = ((Shape)currentBackground.Content).Fill;
            _tempShape.StrokeThickness = _currentThickness;

            // Push this shape on top of all the others.
            Panel.SetZIndex(_tempShape, _lastZIndex++);
        }

        /// <summary>
        /// This continues the shape draw/drag operation on MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMoveOrSizeShape(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                Point currPos = e.GetPosition(DrawingSurface);

                // Resize new shape
                if (!_existingShape)
                {
                    if (currPos.X < _startPoint.X)
                        Canvas.SetLeft(_tempShape, currPos.X);
                    if (currPos.Y < _startPoint.Y)
                        Canvas.SetTop(_tempShape, currPos.Y);

                    _tempShape.Width = Math.Abs(currPos.X - _startPoint.X);
                    _tempShape.Height = Math.Abs(currPos.Y - _startPoint.Y);
                }
                // Move existing shape
                else
                {
                    double xPos = currPos.X - _startPoint.X;
                    double yPos = currPos.Y - _startPoint.Y;

                    Canvas.SetLeft(_tempShape, Canvas.GetLeft(_tempShape) + xPos);
                    Canvas.SetTop(_tempShape, Canvas.GetTop(_tempShape) + yPos);

                    _startPoint = currPos;
                }
            }
        }

        /// <summary>
        /// Called when the MouseUp occurs to end the drawing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEndShape(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                _tempShape.Opacity = 1;
                _mouseDown = false;
                _tempShape = null;
            }
        }
    }
}