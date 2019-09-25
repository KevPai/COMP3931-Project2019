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

namespace PanZoomingCanvas
{
    public partial class MainWindow : Window
    {
        private Point _pointOnClick; // Click Position for panning
        private ScaleTransform _scaleTransform;
        private TranslateTransform _translateTransform;
        private TransformGroup _transformGroup;
        private readonly double maxScale = 0.5;

        public MainWindow()
        {
            InitializeComponent();

            _translateTransform = new TranslateTransform();
            _scaleTransform = new ScaleTransform();
            _transformGroup = new TransformGroup();
            _transformGroup.Children.Add(_translateTransform);
            _transformGroup.Children.Add(_scaleTransform);

            MainCanvas.RenderTransform = _transformGroup;
        }

        private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Capture Mouse
            MainCanvas.CaptureMouse();
            //Store click position relation to Parent of the canvas
            _pointOnClick = e.GetPosition((FrameworkElement)MainCanvas.Parent);
        }

        private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Release Mouse Capture
            MainCanvas.ReleaseMouseCapture();
            //Set cursor by default
            Mouse.OverrideCursor = null;
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Return if mouse is not captured
            if (!MainCanvas.IsMouseCaptured) return;
            //Point on move from Parent
            Point pointOnMove = e.GetPosition((FrameworkElement)MainCanvas.Parent);
            //set TranslateTransform
            _translateTransform.X = MainCanvas.RenderTransform.Value.OffsetX - (_pointOnClick.X - pointOnMove.X);
            _translateTransform.Y = MainCanvas.RenderTransform.Value.OffsetY - (_pointOnClick.Y - pointOnMove.Y);
            //Update pointOnClic
            _pointOnClick = e.GetPosition((FrameworkElement)MainCanvas.Parent);
        }

        private void MainCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePosition = e.GetPosition(MainCanvas);
            //Actual Zoom
            double zoomNow = Math.Round(MainCanvas.RenderTransform.Value.M11, 1);
            //ZoomScale
            double zoomScale = 0.1;
            //Positive or negative zoom
            double valZoom = e.Delta > 0 ? zoomScale : -zoomScale;
            Point pointOnMove = e.GetPosition((FrameworkElement)MainCanvas.Parent);
            //RenderTransformOrigin (doesn't fully working)
            MainCanvas.RenderTransformOrigin = new Point(mousePosition.X / MainCanvas.ActualWidth, mousePosition.Y / MainCanvas.ActualHeight);
            Zoom(new Point(mousePosition.X, mousePosition.Y), zoomNow + valZoom);
        }

        /// Zoom function
        private void Zoom(Point point, double scale)
        {
            if (scale < maxScale)
            {
                _scaleTransform.ScaleX = maxScale;
                _scaleTransform.ScaleY = maxScale;
            }
            else
            {
                _scaleTransform.ScaleX = scale;
                _scaleTransform.ScaleY = scale;
            }

            double centerX = (point.X - _translateTransform.X) / _scaleTransform.ScaleX;
            double centerY = (point.Y - _translateTransform.Y) / _scaleTransform.ScaleY;

            _translateTransform.X = point.X - centerX * _scaleTransform.ScaleX;
            _translateTransform.Y = point.Y - centerY * _scaleTransform.ScaleY;
        }
    }
}