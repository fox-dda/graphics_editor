using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class RemoveRangeDraftsCommand : ICommand
    {
        private List<IDrawable> _storage;
        private List<IDrawable> _removebleList;

        public void Do()
        {
            foreach (IDrawable draft in _removebleList)
            {
                _storage.Remove(draft);
            }
        }

        public void Undo()
        {
            foreach (IDrawable draft in _removebleList)
            {
                _storage.Add(draft);
            }
        }

        public RemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            _storage = storage;
            _removebleList = removebleList;
        }
    }
}
