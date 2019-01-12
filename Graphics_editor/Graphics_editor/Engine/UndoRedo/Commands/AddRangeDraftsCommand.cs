using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    public class AddRangeDraftCommand : ICommand
    {
        private List<IDrawable> _storage;
        private List<IDrawable> _addebleList;

        public void Do()
        {
            foreach(IDrawable draft in _addebleList)
            {
                _storage.Add(draft);
            }
        }

        public void Undo()
        {
            foreach (IDrawable draft in _addebleList)
            {
                _storage.Remove(draft);
            }
        }

        public AddRangeDraftCommand(List<IDrawable> storage, List<IDrawable> addebleList)
        {
            _storage = storage;
            _addebleList = addebleList;
        }
    }
}
