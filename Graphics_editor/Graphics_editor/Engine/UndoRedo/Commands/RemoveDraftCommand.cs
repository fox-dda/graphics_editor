using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using System.Windows.Forms;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class RemoveDraftCommand : ICommand
    {
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        private IDrawable _removebleDraft;

        public void Do()
        {
            TargetStorage.Remove(_removebleDraft);
        }

        public void Undo()
        {
            TargetStorage.Add(_removebleDraft);
        }

        public RemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            TargetStorage = storage;
            _removebleDraft = draft;
        }
    }
}
