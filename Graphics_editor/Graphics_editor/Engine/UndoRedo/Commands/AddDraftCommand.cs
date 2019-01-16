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
    public class AddDraftCommand: ICommand
    {
        [field: NonSerialized] public List<IDrawable> DraftList;
        private IDrawable _draft;

        public void Do()
        {
            DraftList.Add(_draft);
        }

        public void Undo()
        {
            DraftList.Remove(_draft);
        }

        public AddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            DraftList = storage;
            _draft = draft;
        }
    }
}
