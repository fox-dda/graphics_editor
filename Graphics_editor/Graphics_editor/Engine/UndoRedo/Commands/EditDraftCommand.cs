using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class EditDraftCommand : ICommand
    {
        private IDrawable _editedDraft;
        private IDrawable _backUpDraft;
        private Point _sp;
        private Point _ep;
        private Pen _pen;

        public void Do()
        {
            _editedDraft.StartPoint = _sp;
            _editedDraft.EndPoint = _ep;
            _editedDraft.Pen = _pen;
        }

        public void Undo()
        {
            _editedDraft = _backUpDraft;
        }

        public EditDraftCommand(IDrawable draft, Point sp, Point ep, Pen pen)
        {
            _backUpDraft = DraftFactory.Clone(draft);
            _editedDraft = draft;
            _sp = sp;
            _ep = ep;
            _pen = pen;
        }
    }
}
