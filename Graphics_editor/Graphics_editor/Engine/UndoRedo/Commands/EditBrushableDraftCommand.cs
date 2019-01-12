using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    public class EditBrushableDraftCommand : ICommand
    {
        private IDrawable _editedDraft;
        //  private IDrawable _backUpDraft;
        private Point _spOld;
        private Point _epOld;
        private Pen _penOld;
        private Color _brushOld;
        private Point _sp;
        private Point _ep;
        private Pen _pen;
        private Color _brush;

        public void Do()
        {
            _editedDraft.StartPoint = _sp;
            _editedDraft.EndPoint = _ep;
            _editedDraft.Pen = _pen;
            (_editedDraft as IBrushable).BrushColor = _brush;
        }

        public void Undo()
        {
            _editedDraft.StartPoint = _spOld;
            _editedDraft.EndPoint = _epOld;
            _editedDraft.Pen = _penOld;
            (_editedDraft as IBrushable).BrushColor = _brushOld;
        }

        public EditBrushableDraftCommand(IDrawable draft, Point sp, Point ep, Pen pen, Color brush)
        {
            //  _backUpDraft = DraftFactory.Clone(draft);
            _spOld = new Point (draft.StartPoint.X, draft.StartPoint.Y);
            _epOld = new Point(draft.EndPoint.X, draft.EndPoint.Y);
            _penOld = draft.Pen.Clone() as Pen;
            _brushOld = (draft as IBrushable).BrushColor;
            _editedDraft = draft;
            _sp = sp;
            _ep = ep;
            _pen = pen;
            _brush = brush; 
        }
    }
}
