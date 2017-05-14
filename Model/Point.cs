using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel
{
    public class Point
    {
        private int _x;
        private int _y;
        private const int TWO = 2; 

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        //
        public Point()
        {
            _x = 0;
            _y = 0;
        }

        //
        public Point(int pointX, int pointY)
        {
            _x = pointX;
            _y = pointY;
        }
        //
        public Point(Point point)
        {
            _x = point.X;
            _y = point.Y;
        }

        //
        public static Point operator +(Point tempFirst, Point tempSecond)
        {
            return new Point(tempFirst.X + tempSecond.X, tempFirst.Y + tempSecond.Y);
        }

        //
        public static Point operator -(Point tempFirst, Point tempSecond)
        {
            return new Point(tempFirst.X - tempSecond.X, tempFirst.Y - tempSecond.Y);
        }

        //
        public static Point operator *(Point tempFirst, float temp)
        {
            return new Point((int)(tempFirst.X * temp), (int)(tempFirst.Y * temp));
        }

        //
        public static float operator *(Point tempFirst, Point tempSecond)
        {
            return tempFirst.X * tempSecond.X + tempFirst.Y * tempSecond.Y;
        }

        //
        public float GetLength()
        {
            return (float)Math.Sqrt(_x * _x + _y * _y);
        }
    }
}
