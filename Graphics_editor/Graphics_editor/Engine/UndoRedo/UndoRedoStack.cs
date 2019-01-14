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
        private Stack<ICommand> _undo;
        private Stack<ICommand> _redo;

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
        }

        public void Do(ICommand command)
        {
            command.Do();
            _undo.Push(command);
            _redo.Clear();
           // MessageBox.Show("Do");
        }

        public void Undo()
        {
            if (_undo.Count > 0)
            {
                ICommand cmd = _undo.Pop();
                cmd.Undo();
                _redo.Push(cmd);
             //   MessageBox.Show("Undo");
            }
        }

        public void Redo()
        {
            if (_redo.Count > 0)
            {
                ICommand cmd = _redo.Pop();
                cmd.Do();
                _undo.Push(cmd);
               // MessageBox.Show("Redo");
            }
        }
    }
}
