using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel
{
    public class Circle : Shape
    {
        private const int TWO = 2;
        private const float ONE = 1.0f;
        //
        public Circle(Boundary rectangleBoundary) : base(rectangleBoundary)
        {
        }

        //
        public Circle() : base()
        {
        }

        //
        public override void Fill(IGraphics graphics)
        {
            graphics.FillEllipse(_rectangleBoundary);
        }

        //
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(_rectangleBoundary);
        }

        //
        public override bool IsSelect(Point point)
        {
            double tempFirst = (double)(_rectangleBoundary.X + _rectangleBoundary.Width / TWO) ;
            double tempSecond = (double)(_rectangleBoundary.Y + _rectangleBoundary.Height / TWO) ;
            double tempThird = (double)_rectangleBoundary.Width / TWO;
            double tempForth = (double)_rectangleBoundary.Height / TWO;
            return (Math.Pow((point.X - tempFirst) / tempThird, TWO) ) + (Math.Pow((point.Y - tempSecond) / tempForth, TWO)) <= ONE;
        }
    }
}
