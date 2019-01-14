using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    [Serializable]
    class Ellipse : IDrawable, IBrushable
    {
        public Color BrushColor
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }
        private Point _startPoint;
        private Point _endPoint;
        private PenSettings _pen;
        protected  Color _brush;

        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
            }
        }

        public PenSettings Pen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        public Ellipse(Point _startPoint, Point _endPoint, PenSettings _pen)
        {
            StartPoint = _startPoint;
            EndPoint = _endPoint;
            Pen = _pen;
        }
    }
}
