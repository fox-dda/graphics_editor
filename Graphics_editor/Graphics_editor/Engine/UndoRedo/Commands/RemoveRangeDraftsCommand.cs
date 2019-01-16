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
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        private List<IDrawable> _removebleList;

        public void Do()
        {
            foreach (IDrawable draft in _removebleList)
            {
                TargetStorage.Remove(draft);
            }
        }

        public void Undo()
        {
            foreach (IDrawable draft in _removebleList)
            {
                TargetStorage.Add(draft);
            }
        }

        public RemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            TargetStorage = storage;
            _removebleList = new List<IDrawable>();
            foreach(IDrawable draft in removebleList)
            {
                _removebleList.Add(draft);
            }
        }
    }
}
