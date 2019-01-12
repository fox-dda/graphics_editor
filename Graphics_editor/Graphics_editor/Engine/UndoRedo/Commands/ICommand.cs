using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    public interface ICommand
    {
        void Do();
        void Undo();
    }
}
