using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class ClearStorageCommand : ICommand
    {
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        private List<IDrawable> _backUp;

        public void Do()
        {
            TargetStorage.Clear();
        }

        public void Undo()
        {
            foreach (IDrawable draft in _backUp)
            {
                TargetStorage.Add(draft);
            }
        }

        public ClearStorageCommand(List<IDrawable> storage)
        {
            TargetStorage = storage;
            _backUp = new List<IDrawable>();
            foreach(IDrawable draft in storage)
            {
                _backUp.Add(draft);
            }
        }
    }
}
