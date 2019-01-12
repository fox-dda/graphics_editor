using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.UndoRedo
{
    public interface ICommandS<T>
    {
        T Do(T input);
        T Undo(T input);
    }
}
