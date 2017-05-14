using System;

namespace PaintModel
{
    public class DrawCommand : ICommand
    {
        private Shape _shape;
        private Model _model;
        //
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        //
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        //
        public void ReverseExecute()
        {
            _model.DeleteShape();
        }
    }
}
