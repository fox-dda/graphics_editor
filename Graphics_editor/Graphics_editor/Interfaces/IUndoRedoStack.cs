using GraphicsEditor.Engine.UndoRedo.Commands;
using System.Collections.Generic;

namespace GraphicsEditor.Interfaces
{
    public interface IUndoRedoStack
    {
        /// <summary>
        /// Перезагрузить стек
        /// </summary>
        void Reset();

        /// <summary>
        /// Cтек отката
        /// </summary>
        /// <returns></returns>
        Stack<ICommand> UndoStack { get; }

        /// <summary>
        /// Стек наката
        /// </summary>
        Stack<ICommand> RedoStack { get; set; }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command"></param>
        void Do(ICommand command);

        /// <summary>
        /// Откатить команду
        /// </summary>
        void Undo();

        /// <summary>
        /// Накатить команду
        /// </summary>
        void Redo();
    }
}
