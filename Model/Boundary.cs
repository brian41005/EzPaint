using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel
{
    public class Boundary
    {
        private int _pointX;
        private int _pointY;
        private int _width;
        private int _height;
        private Point _firstPoint;
        private Point _secondPoint;

        public Boundary()
        {
            _pointX = 0;
            _pointY = 0;
            _width = 0;
            _height = 0;
            _firstPoint = new Point();
            _secondPoint = new Point();
        }

        public Boundary(int pointX, int pointY, int width, int height)
        {
            _pointX = pointX;
            _pointY = pointY;
            _width = width;
            _height = height;
        }

        public Point firstPoint
        {
            get
            {
                return _firstPoint;
            }

            set
            {
                _firstPoint = value;
            }

        }

        public Point secondPoint
        {
            get
            {
                return _secondPoint;
            }

            set
            {
                _secondPoint = value;
            }

        }

        public int X
        {
            get
            {
                return _pointX;
            }

            set
            {
                _pointX = value;
            }

        }

        public int Y
        {
            get
            {
                return _pointY;
            }

            set
            {
                _pointY = value;
            }

        }

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }

        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }

        }
    }
}
