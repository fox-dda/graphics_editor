using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    public class AddDraftCommand: ICommand
    {
        private List<IDrawable> _list;
        private IDrawable _draft;

        public void Do()
        {
            _list.Add(_draft);
        }

        public void Undo()
        {
            _list.Remove(_draft);
        }

        public AddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            _list = storage;
            _draft = draft;
        }
    }
}
