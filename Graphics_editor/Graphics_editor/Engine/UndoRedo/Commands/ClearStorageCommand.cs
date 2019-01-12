using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    public class ClearStorageCommand : ICommand
    {
        private List<IDrawable> _storage;
        private List<IDrawable> _backUp;

        public void Do()
        {
            _storage.Clear();
        }

        public void Undo()
        {
            foreach (IDrawable draft in _backUp)
            {
                _storage.Add(draft);
            }
        }

        public ClearStorageCommand(List<IDrawable> storage)
        {
            _storage = storage;
            _backUp = new List<IDrawable>();
            foreach(IDrawable draft in storage)
            {
                _backUp.Add(draft);
            }
        }
    }
}
