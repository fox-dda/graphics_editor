using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class AddRangeDraftCommand : ICommand
    {
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        private List<IDrawable> _addebleList;

        public void Do()
        {
            foreach(IDrawable draft in _addebleList)
            {
                TargetStorage.Add(draft);
            }
        }

        public void Undo()
        {
            foreach (IDrawable draft in _addebleList)
            {
                TargetStorage.Remove(draft);
            }
        }

        public AddRangeDraftCommand(List<IDrawable> storage, List<IDrawable> addebleList)
        {
            TargetStorage = storage;
            _addebleList = new List<IDrawable>();
            foreach (IDrawable draft in addebleList)
            {
                _addebleList.Add(draft);
            }
        }
    }
}
