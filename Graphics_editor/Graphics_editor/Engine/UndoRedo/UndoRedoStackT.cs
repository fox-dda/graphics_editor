/*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.UndoRedo
{
    public class UndoRedoStack<T>
    {
        private Stack<ICommandS<T>> _undo;
        private Stack<ICommandS<T>> _redo;

        public UndoRedoStack()
        {
            Reset();
        }

        public int UndoCount
        {
            get
            {
                return _undo.Count;
            }
        }

        public int RedoCount
        {
            get
            {
                return _redo.Count;
            }
        }

        public void Reset()
        {
            _undo = new Stack<ICommandS<T>>();
            _redo = new Stack<ICommandS<T>>();
        }

        public T Do(ICommandS<T> cmd, T input)
        {
            T output = cmd.Do(input);
            _undo.Push(cmd);
            _redo.Clear();
            return output;
        }

        public T Undo(T input)
        {
            if (_undo.Count > 0)
            {
                ICommandS<T> cmd = _undo.Pop();
                T output = cmd.Undo(input);
                _redo.Push(cmd);
                return output;
            }
            else
            {
                return input;
            }
        }
    
        public T Redo(T input)
        {
            if (_redo.Count > 0)
            {
                ICommandS<T> cmd = _redo.Pop();
                T output = cmd.Do(input);
                _undo.Push(cmd);
                return output;
            }
            else
            {
                return input;
            }
        }
    }
}
/*/