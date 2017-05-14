namespace PaintModel
{
    public class Rectangle : Shape
    {
        //
        public Rectangle(Boundary boundary) : base(boundary)
        {
        }

        public Rectangle() : base()
        {
        }

        //
        public override void Fill(IGraphics graphics)
        {
            graphics.FillRectangle(_rectangleBoundary);
        }

        //
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_rectangleBoundary);
        }

        //
        public override bool IsSelect(Point point)
        {
            return (_rectangleBoundary.X <= point.X && point.X <= (_rectangleBoundary.X + _rectangleBoundary.Width) && 
                    _rectangleBoundary.Y <= point.Y && point.Y <= (_rectangleBoundary.Y + _rectangleBoundary.Height));
        }
    }
}
