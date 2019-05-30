using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEditor.Core.UndoRedo.Commands;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Core.UndoRedo
{
    /// <summary>
    /// Стек команд
    /// </summary>
    [Serializable]
    public class UndoRedoStack: IUndoRedoStack
    {
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
            UndoStack = new Stack<ICommand>();
            RedoStack = new Stack<ICommand>();
        }

        /// <summary>
        /// Cтек отката
        /// </summary>
        /// <returns></returns>
        public Stack<ICommand> UndoStack { get; set; }

        /// <summary>
        /// Стек наката
        /// </summary>
        public Stack<ICommand> RedoStack { get; set; }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command"></param>
        public void Do(ICommand command)
        {
            command.Do();
            UndoStack.Push(command);
            RedoStack.Clear();
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                ICommand command = UndoStack.Pop();
                command.Undo();
                RedoStack.Push(command);
            }
        }
        
        /// <summary>
        /// Накатить команду
        /// </summary>
        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                ICommand command = RedoStack.Pop();
                command.Do();
                UndoStack.Push(command);
            }
        }
    }
}
