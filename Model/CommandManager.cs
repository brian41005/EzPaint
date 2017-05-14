using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintModel
{
    public class CommandManager
    {
        private Stack<ICommand> _undo;
        private Stack<ICommand> _redo;
        private const string MESSAGE = "Cannot Undo exception\n";

        public CommandManager()
        {
            _undo = new Stack<ICommand>();
            _redo = new Stack<ICommand>();
        }

        //
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);    
            _redo.Clear();      
        }

        //
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(MESSAGE);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.ReverseExecute();
        }

        //
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(MESSAGE);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        //
        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        //
        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
