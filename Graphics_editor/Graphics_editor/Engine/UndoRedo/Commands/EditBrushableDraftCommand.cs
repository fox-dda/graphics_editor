using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using System.Windows.Forms;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class EditBrushableDraftCommand : ICommand
    {
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        private IDrawable _editedDraft;
        private IDrawable _backUpDraft;
        private List<Point> _pointList;
        private PenSettings _penSettings;
        private Color _brush;


        public void Do()
        {
            if (_editedDraft is Polygon)
            {
                (_editedDraft as Polygon).DotList = _pointList;
                (_editedDraft as IBrushable).BrushColor = _brush;
                _editedDraft.Pen = _penSettings;
            }
            else if (_editedDraft is Polyline)
            {
                (_editedDraft as Polyline).DotList = _pointList;
                _editedDraft.Pen = _penSettings;
            }
            else
            {
                _editedDraft.StartPoint = _pointList[0];
                _editedDraft.EndPoint = _pointList.Last();
                if(_editedDraft is IBrushable)
                    (_editedDraft as IBrushable).BrushColor = _brush;
                _editedDraft.Pen = _penSettings;
            }
        }

        public void Undo()
        {          
            if (_editedDraft is Polygon)
            {
                (_editedDraft as Polygon).DotList = (_backUpDraft as Polygon).DotList;
                (_editedDraft as IBrushable).BrushColor = (_backUpDraft as IBrushable).BrushColor;
                _editedDraft.Pen = _backUpDraft.Pen;
            }
            if (_editedDraft is Polyline)
            {
                (_editedDraft as Polyline).DotList = (_backUpDraft as Polyline).DotList;
                _editedDraft.Pen = _backUpDraft.Pen;
            }
            else
            {
                _editedDraft.StartPoint = _backUpDraft.StartPoint;
                _editedDraft.EndPoint = _backUpDraft.EndPoint;
                if(_editedDraft is IBrushable)
                    (_editedDraft as IBrushable).BrushColor = (_backUpDraft as IBrushable).BrushColor;
                _editedDraft.Pen = _backUpDraft.Pen;
            }
        }

        public EditBrushableDraftCommand(List<IDrawable> targetStorage, IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            TargetStorage = targetStorage;
            _editedDraft = draft;
            _backUpDraft = DraftFactory.Clone(draft);
            _pointList = pointList;
            _penSettings = pen;
            if (brush != null)
                _brush = brush;
        }
    }
}
