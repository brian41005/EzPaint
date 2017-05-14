using System.Collections.Generic;
using System;
namespace PaintModel
{
    public class Model
    {
        public delegate void ModelChangeEventHandler();
        public event ModelChangeEventHandler _modelChange;
        private CommandManager _commandManager;
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapeList;
        private Shape _hint;
        private Point _firstPoint;
        private Point _secondPoint;   
        private bool _isPressed;
        private int _shapeState;
        private bool _isInMoveMode;
        
        //
        public Model()
        {
            _commandManager = new CommandManager();
            _shapeFactory = new ShapeFactory();
            _shapeList = new List<Shape>();
            _isPressed = false;
            _shapeState = 0;
            _isInMoveMode = false;

        }

        //
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape eachShape in _shapeList)
                eachShape.Fill(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        //
        public void MouseDown(Point point)
        {
            if (point.X > 0 && point.Y > 0)
            {
                _isPressed = true;
                _firstPoint = point;
                _secondPoint = point;
                Shape movingHint = GoIntoSelectMode(_firstPoint);
                if (!_isInMoveMode)
                {
                    _hint = _shapeFactory.GetShape(_shapeState);
                    _hint.firstPoint = _firstPoint;
                    _hint.secondPoint = _secondPoint;

                }
                else               
                    _hint = movingHint;
            }
        }

        //
        private Shape GoIntoSelectMode(Point point)
        {
            for (int i = _shapeList.Count - 1; i >= 0; i--)
            {
                if (_shapeList[i].IsSelect(_firstPoint))
                {
                    _isInMoveMode = true;
                    return _shapeList[i];
                }
            }
                
            _isInMoveMode = false;
            return null;
        }

        //
        public void MouseMove(Point point)
        {
            if (_isPressed)
            {
                _secondPoint = point;
                if (!_isInMoveMode)
                    _hint.secondPoint = point;
                else
                    _hint.Move(new Point(_secondPoint.X - _firstPoint.X, _secondPoint.Y - _firstPoint.Y));
                NotifyModelChanged();
            }   
        }

        //
        public void MouseUp()
        {
            if (_isPressed)
            {
                _isPressed = false;
                Shape hint = _shapeFactory.GetShape(_shapeState);
                hint.firstPoint = _firstPoint;
                hint.secondPoint = _secondPoint;

                if (!_isInMoveMode)
                    _commandManager.Execute(new DrawCommand(this, hint));
                else
                    _commandManager.Execute(new MoveCommand(this, _hint, new Point(_secondPoint.X - _firstPoint.X, _secondPoint.Y - _firstPoint.Y)));
                _isInMoveMode = false;
                NotifyModelChanged();
            }
        }

        //
        public void DrawShape(Shape shape)
        {
            _shapeList.Add(shape);
        }

        //
        public void DeleteShape()
        {
            if (_shapeList.Count != 0) 
                _shapeList.RemoveAt(_shapeList.Count - 1);                  
        }

        //
        public void SetShape(int state)
        {
            _shapeState = state;
        }

        //
        public void Save(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape eachShape in _shapeList)
                eachShape.Fill(graphics);
        }

        //
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        //
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        //
        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        //
        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        //
        private void NotifyModelChanged()
        {
            if (_modelChange != null)
                _modelChange();
        }
    }
}
