using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class RemoveDraftCommand : ICommand
    {
        private List<IDrawable> _list;
        private IDrawable _removebleDraft;

        public void Do()
        {
            _list.Remove(_removebleDraft);
        }

        public void Undo()
        {
            _list.Add(_removebleDraft);
        }

        public RemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            _list = storage;
            _removebleDraft = draft;
        }
    }
}
