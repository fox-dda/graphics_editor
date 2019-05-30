using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    /// Интерфейс команд
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        void Do();

        /// <summary>
        /// Откатить команду
        /// </summary>
        void Undo();
    }
}
