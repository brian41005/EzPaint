using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace PaintModel
{
    public class Line : Shape
    {
        private const int RANGE = 5;
        private const float ZERO = 0.0f;
        private const float LINE_SELECT_RANGE = 10;
        //
        public Line(Boundary rectangleBoundary) : base(rectangleBoundary)
        {

        }

        //
        public Line() : base()
        {

        }

        //
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_rectangleBoundary);
        }

        //
        public override void Fill(IGraphics graphics)
        {
            graphics.DrawLine(_rectangleBoundary);
        }

        //
        public override bool IsSelect(Point point)
        {
            if (_rectangleBoundary.Y - RANGE <= point.Y && point.Y <= _rectangleBoundary.Y + _rectangleBoundary.Height + RANGE && point.X >= _rectangleBoundary.X - RANGE && point.X <= _rectangleBoundary.X + _rectangleBoundary.Width + RANGE)
            {
                Point y = new Point(point - _rectangleBoundary.firstPoint);
                Point u = new Point(_rectangleBoundary.secondPoint - _rectangleBoundary.firstPoint);
                if (u.X == ZERO && u.Y == ZERO)
                    return false;
                float c = (y * u) / (u * u);
                Point yy = new Point(u * c);
                Point z = new Point(y - yy);
                return z.GetLength() < LINE_SELECT_RANGE;
            }
            return false;
        }

        //

        public override void Move(Point temp)
        {
            _rectangleBoundary.firstPoint.X = _first.X + temp.X - _previous.X;
            _rectangleBoundary.firstPoint.Y = _first.Y + temp.Y - _previous.Y;
            _rectangleBoundary.secondPoint.X = _second.X + temp.X - _previous.X;
            _rectangleBoundary.secondPoint.Y = _second.Y + temp.Y - _previous.Y;
            _rectangleBoundary.X = Math.Min(_rectangleBoundary.firstPoint.X, _rectangleBoundary.secondPoint.X);
            _rectangleBoundary.Y = Math.Min(_rectangleBoundary.firstPoint.Y, _rectangleBoundary.secondPoint.Y);
            _previous.X = temp.X;
            _previous.Y = temp.Y;
        }

        //
        public override void MoveEnd()
        {
            _first = _rectangleBoundary.firstPoint;
            _second = _rectangleBoundary.secondPoint;
            _previous.X = 0;
            _previous.Y = 0;

        }
    }
}
