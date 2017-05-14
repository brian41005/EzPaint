using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel
{
    public class ShapeFactory
    {
        private const int CIRCLE_STATE = 2;
        private const int LINE_STATE = 3;
        //
        public Shape GetShape(int shapeState)
        {
            if (shapeState == 0)
                return new Rectangle();
            else if (shapeState == 1)
                return new Triangle();
            else if (shapeState == CIRCLE_STATE)
                return new Circle();
            else if (shapeState == LINE_STATE)
                return new Line();
            else
                return new Shape();
        }
    }
}
