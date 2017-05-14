using PaintModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace EzPaintWinApp.EzPresentationModel
{
    class WindowsAppGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        private const int TWO = 2;

        //
        public WindowsAppGraphicsAdaptor(Canvas canvas)
        {
            _canvas = canvas;
        }

        //
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //
        public void FillRectangle(Boundary rectangleBoundary)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = rectangleBoundary.Width;
            rectangle.Height = rectangleBoundary.Height;
            Canvas.SetLeft(rectangle, rectangleBoundary.X);
            Canvas.SetTop(rectangle, rectangleBoundary.Y);
            rectangle.Fill = new SolidColorBrush(Colors.BurlyWood);
            _canvas.Children.Add(rectangle);
        }

        //
        public void FillTriangle(Boundary triangleBoundary)
        {
            Polygon triangle = new Polygon();
            triangle.Points = new PointCollection()
            {
                new Windows.Foundation.Point(triangleBoundary.X + (triangleBoundary.Width / TWO), triangleBoundary.Y),
                new Windows.Foundation.Point(triangleBoundary.X, triangleBoundary.Y + triangleBoundary.Height),
                new Windows.Foundation.Point(triangleBoundary.X + triangleBoundary.Width, triangleBoundary.Y + triangleBoundary.Height)
            };
            triangle.Fill = new SolidColorBrush(Colors.SeaGreen);
            _canvas.Children.Add(triangle);
        }

        //
        public void FillEllipse(Boundary circleBoundary)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = circleBoundary.Width;
            ellipse.Height = circleBoundary.Height;
            Canvas.SetLeft(ellipse, circleBoundary.X);
            Canvas.SetTop(ellipse, circleBoundary.Y);
            ellipse.Fill = new SolidColorBrush(Colors.BlueViolet);
            _canvas.Children.Add(ellipse);
        }

        //
        public void DrawRectangle(Boundary rectangleBoundary)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = rectangleBoundary.Width;
            rectangle.Height = rectangleBoundary.Height;
            Canvas.SetLeft(rectangle, rectangleBoundary.X);
            Canvas.SetTop(rectangle, rectangleBoundary.Y);
            rectangle.Stroke = new SolidColorBrush(Colors.BurlyWood);
            _canvas.Children.Add(rectangle);

        }

        //
        public void DrawTriangle(Boundary triangleBoundary)
        {
            Polygon triangle = new Polygon();
            triangle.Points = new PointCollection()
            {
                new Windows.Foundation.Point(triangleBoundary.X + (triangleBoundary.Width / TWO), triangleBoundary.Y),
                new Windows.Foundation.Point(triangleBoundary.X, triangleBoundary.Y + triangleBoundary.Height),
                new Windows.Foundation.Point(triangleBoundary.X + triangleBoundary.Width, triangleBoundary.Y + triangleBoundary.Height)
            };
            triangle.Stroke = new SolidColorBrush(Colors.SeaGreen);
            _canvas.Children.Add(triangle);
        }

        //
        public void DrawEllipse(Boundary circleBoundary)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = circleBoundary.Width;
            ellipse.Height = circleBoundary.Height;
            Canvas.SetLeft(ellipse, circleBoundary.X);
            Canvas.SetTop(ellipse, circleBoundary.Y);
            ellipse.Stroke = new SolidColorBrush(Colors.BlueViolet);
            _canvas.Children.Add(ellipse);
        }

        //
        public void DrawLine(Boundary lineBoundary)
        {
            DrawAndFillLine(lineBoundary);
        }

        //
        public void FillLine(Boundary lineBoundary)
        {
            DrawAndFillLine(lineBoundary);
        }

        //
        private void DrawAndFillLine(Boundary lineBoundary)
        {
            var line = new Windows.UI.Xaml.Shapes.Line();
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.X1 = lineBoundary.firstPoint.X;
            line.X2 = lineBoundary.secondPoint.X;
            line.Y1 = lineBoundary.firstPoint.Y;
            line.Y2 = lineBoundary.secondPoint.Y;
            _canvas.Children.Add(line);
        }
    }
}
