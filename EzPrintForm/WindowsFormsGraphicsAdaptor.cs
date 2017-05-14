using System.Drawing;
using System;
using PaintModel;

namespace EzPrintForm
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        private Graphics _graphics;
        private const float WIDTH = 1.5f;
        private const float DASH_WIDTH = 3.0f;
        private const float SECOND_DASH_WIDTH = 20.0f;
        private const int TWO = 2;

        //
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;

        }

        //
        public void ClearAll()
        {
            _graphics.Clear(Color.White);
        }

        //
        public void FillEllipse(Boundary circleBoundary)
        {
            System.Drawing.Rectangle circle = new System.Drawing.Rectangle(circleBoundary.X, circleBoundary.Y, circleBoundary.Width, circleBoundary.Height);
            Brush brush = new SolidBrush(Color.Red);
            _graphics.FillEllipse(brush, circle);
        }

        //
        public void FillRectangle(Boundary rectangleBoundary)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(rectangleBoundary.X,
                rectangleBoundary.Y,
                rectangleBoundary.Width,
                rectangleBoundary.Height);
            Brush brush = new SolidBrush(Color.Blue);
            _graphics.FillRectangle(brush, rectangle);
        }

        //
        public void FillTriangle(Boundary triangleBoundary)
        {
            System.Drawing.Rectangle triangle = new System.Drawing.Rectangle(triangleBoundary.X,
                triangleBoundary.Y,
                triangleBoundary.Width,
                triangleBoundary.Height);
            Brush brush = new SolidBrush(Color.Green);
            PointF pointX = new PointF(triangle.X + (triangleBoundary.Width / TWO), triangle.Top);
            PointF pointY = new PointF(triangle.Right, triangle.Bottom);
            PointF pointI = new PointF(triangle.X, triangle.Bottom);
            _graphics.FillPolygon(brush, new PointF[] 
            {
                pointX, pointY, pointI
            });
        }

        //
        public void DrawRectangle(Boundary rectangleBoundary)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(rectangleBoundary.X,
                rectangleBoundary.Y,
                rectangleBoundary.Width,
                rectangleBoundary.Height);
            Pen dashPen = new Pen(Color.Green, WIDTH);
            dashPen.DashPattern = new float[] { DASH_WIDTH, DASH_WIDTH };
            _graphics.DrawRectangle(dashPen, rectangle);
        }

        //
        public void DrawTriangle(Boundary triangleBoundary)
        {
            System.Drawing.Rectangle triangle = new System.Drawing.Rectangle(triangleBoundary.X,
                triangleBoundary.Y,
                triangleBoundary.Width,
                triangleBoundary.Height);
            Pen dashPen = new Pen(Color.Green, WIDTH);
            dashPen.DashPattern = new float[] { DASH_WIDTH, DASH_WIDTH };
            PointF pointX = new PointF(triangle.X + (triangle.Width / TWO), triangle.Top);
            PointF pointY = new PointF(triangle.Right, triangle.Bottom);
            PointF pointI = new PointF(triangle.X, triangle.Bottom);
            _graphics.DrawPolygon(dashPen, new PointF[] { pointX, pointY, pointI });
            dashPen.DashPattern = new float[] { DASH_WIDTH, SECOND_DASH_WIDTH };
            _graphics.DrawRectangle(dashPen, triangle);
        }

        //
        public void DrawEllipse(Boundary circleBoundary)
        {
            System.Drawing.Rectangle circle = new System.Drawing.Rectangle(circleBoundary.X,
                circleBoundary.Y,
                circleBoundary.Width,
                circleBoundary.Height);
            Pen dashPen = new Pen(Color.Green, WIDTH);
            dashPen.DashPattern = new float[] { DASH_WIDTH, DASH_WIDTH };
            _graphics.DrawEllipse(dashPen, circle);
            dashPen.DashPattern = new float[] { DASH_WIDTH, SECOND_DASH_WIDTH };
            _graphics.DrawRectangle(dashPen, circle);
        }

        //
        public void DrawLine(Boundary lineBoundary)
        {
            _graphics.DrawLine(Pens.DarkViolet, lineBoundary.firstPoint.X, lineBoundary.firstPoint.Y, lineBoundary.secondPoint.X, lineBoundary.secondPoint.Y);
        }

        //
        public void FillLine(Boundary lineBoundary)
        {
            _graphics.DrawLine(Pens.DarkViolet, lineBoundary.firstPoint.X, lineBoundary.firstPoint.Y, lineBoundary.secondPoint.X, lineBoundary.secondPoint.Y);
        }

    }
}
