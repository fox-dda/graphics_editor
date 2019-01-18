using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.Engine.UndoRedo
{
    /// <summary>
    /// Стек команд
    /// </summary>
    [Serializable]
    public class UndoRedoStack
    {
        /// <summary>
        /// Стек отката команд
        /// </summary>
        private Stack<ICommand> _undo;
        /// <summary>
        /// Стек наката команд
        /// </summary>
        private Stack<ICommand> _redo;

        /// <summary>
        /// Конструктор стека команд
        /// </summary>
        public UndoRedoStack()
        {
            Reset();
        }

        /// <summary>
        /// Перезагрузить стек
        /// </summary>
        public void Reset()
        {
            _undo = new Stack<ICommand>();
            _redo = new Stack<ICommand>();
        }

        /// <summary>
        /// Вернуть стек отката
        /// </summary>
        /// <returns></returns>
        public Stack<ICommand> GetUndo()
        {
            return _undo;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command"></param>
        public void Do(ICommand command)
        {
            Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
            command.Do();
            _undo.Push(command);
            _redo.Clear();
            Console.WriteLine("Do " + command.GetType().ToString());
            Console.WriteLine("Undo stack length = " + _undo.Count().ToString());
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
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
        
        /// <summary>
        /// Накатить команду
        /// </summary>
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
