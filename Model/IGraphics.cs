
namespace PaintModel
{
    public interface IGraphics
    {
        //
        void ClearAll();
        //
        void FillRectangle(Boundary rectangleBoundary);
        //
        void FillTriangle(Boundary triangleBoundary);
        //
        void FillEllipse(Boundary circleBoundary);
        //
        void DrawRectangle(Boundary rectangleBoundary);
        //
        void DrawTriangle(Boundary triangleBoundary);
        //
        void DrawEllipse(Boundary circleBoundary);
        //
        void DrawLine(Boundary lineBoundary);

        //
        void FillLine(Boundary lineBoundary);
    }
}
