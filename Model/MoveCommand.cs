using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel
{
    public class MoveCommand : ICommand
    {
        private Point _temp;
        private Model _model;
        private Shape _shape;

        //
        public MoveCommand(Model model, Shape shape, Point temp)
        {
            _model = model;
            _temp = temp;
            _shape = shape;
        }
        //
        public void Execute()
        {
            _shape.Move(_temp);
            _shape.MoveEnd();
        }

        //
        public void ReverseExecute()
        {
            _shape.Move(new Point(-_temp.X, -_temp.Y));
            _shape.MoveEnd();
        }
    }
}
