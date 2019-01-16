using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.Engine.UndoRedo
{
    [Serializable]
    public class UndoRedoStack
    {
        public Stack<ICommand> _undo;
        public Stack<ICommand> _redo;

        public UndoRedoStack()
        {
            Reset();
        }

        public void Reset()
        {
            _undo = new Stack<ICommand>();
            _redo = new Stack<ICommand>();
        }

        public void DoAll()
        {
            foreach (ICommand cmd in _undo)
                cmd.Do();
            _redo.Clear();
        }

        public void Do(ICommand command)
        {
            Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
            command.Do();
            _undo.Push(command);
            _redo.Clear();
            Console.WriteLine("Do " + command.GetType().ToString());
            Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
        }

        public void Undo()
        {
            Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
            if (_undo.Count > 0)
            {
                ICommand command = _undo.Pop();
                command.Undo();
                _redo.Push(command);
                Console.WriteLine("Undo " + command.GetType().ToString());
                Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
            }
        }

        public void Redo()
        {
            Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
            if (_redo.Count > 0)
            {
                ICommand command = _redo.Pop();
                command.Do();
                _undo.Push(command);
                Console.WriteLine("Redo " + command.GetType().ToString());
                Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
            }
        }
    }
}
