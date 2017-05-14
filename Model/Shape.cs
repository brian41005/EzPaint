using System;
namespace PaintModel
{
    public class Shape
    {
        protected Boundary _rectangleBoundary;
        protected Point _first;
        protected Point _second;
        protected Point _previous;

        //
        public Shape(Boundary rectangleBoundary)
        {
            _rectangleBoundary = rectangleBoundary;
            _first = new Point(rectangleBoundary.X, rectangleBoundary.Y);
            _previous = new Point();
            _second = new Point();
        }

        //
        public Shape()
        {
            _rectangleBoundary = new Boundary();
            _first = new Point();
            _previous = new Point();
            _second = new Point();
        }

        //
        public virtual void Fill(IGraphics graphics)
        {
        }
        
        //
        public virtual void Draw(IGraphics graphics)
        {
        }

        //
        public virtual bool IsSelect(Point point)
        {
            return false;
        }

        //
        public virtual void Move(Point temp)
        {
            _rectangleBoundary.X += temp.X - _previous.X;
            _rectangleBoundary.Y += temp.Y - _previous.Y;
            _previous = temp;

        }

        //
        public virtual void MoveEnd()
        {
            _first.X = _rectangleBoundary.X;
            _first.Y = _rectangleBoundary.Y;
            _previous = new Point();
        }

        //
        public Point firstPoint
        {
            get
            {
                return new Point(_first.X, _first.Y);
            }

            set
            {
                _rectangleBoundary.X = value.X;
                _rectangleBoundary.Y = value.Y;
                _first = value;
                _rectangleBoundary.firstPoint = _first;
            }
        }

        //
        public Point secondPoint
        {
            get
            {
                return new Point(_rectangleBoundary.X + _rectangleBoundary.Width, _rectangleBoundary.Y + _rectangleBoundary.Height);
            }

            set
            {
                _rectangleBoundary = new Boundary(Math.Min(value.X, _first.X), Math.Min(value.Y, _first.Y), Math.Abs(value.X - _first.X), Math.Abs(value.Y - _first.Y));
                _rectangleBoundary.firstPoint = _first;
                _rectangleBoundary.secondPoint = value;
                _second = value;
            }
        }
    }
}
