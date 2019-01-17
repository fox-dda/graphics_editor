using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using System.Drawing;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class DragDropDotCommand : ICommand
    {
        private Point _targetDot;
        private Point _backUpDot;
        private Point _newDot;

        public void Do()
        {
            _targetDot = _newDot;
        }

        public void Undo()
        {
            _targetDot.X = _backUpDot.X;
            _targetDot.Y = _backUpDot.Y;
        }

        public DragDropDotCommand(Point targetPoint, Point newPoint)
        {
            _targetDot = targetPoint;
            _backUpDot = new Point(targetPoint.X, targetPoint.Y);
            _newDot = newPoint;
        }
    }
}
