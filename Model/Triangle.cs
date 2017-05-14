using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel
{
    public class Triangle : Shape
    {
        private const int TWO = 2;
        private const float ZERO = 0.0f;

        //
        public Triangle(Boundary boundary) : base(boundary)
        {
        }

        //
        public Triangle() : base()
        {
        }

        //
        public override void Fill(IGraphics graphics)
        {
            graphics.FillTriangle(_rectangleBoundary);
        }

        //
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(_rectangleBoundary);
        }

        //
        public override bool IsSelect(Point point)
        {
            Point pointX = new Point(_rectangleBoundary.X + (_rectangleBoundary.Width / TWO), _rectangleBoundary.Y);
            Point pointY = new Point(_rectangleBoundary.X + _rectangleBoundary.Width, _rectangleBoundary.Y + _rectangleBoundary.Height);
            Point pointI = new Point(_rectangleBoundary.X, _rectangleBoundary.Y + _rectangleBoundary.Height);
            bool isOne = GetSign(point, pointX, pointY) < ZERO;
            bool isTwo = GetSign(point, pointY, pointI) < ZERO;
            bool isThree = GetSign(point, pointI, pointX) < ZERO;
            return (isOne == isTwo) && (isTwo == isThree);
        }

        //
        private float GetSign(Point point1, Point point2, Point point3)
        {
            return ((float)point1.X - (float)point3.X) * ((float)point2.Y - (float)point3.Y) - ((float)point2.X - (float)point3.X) * ((float)point1.Y - (float)point3.Y);
        }
    }
}
