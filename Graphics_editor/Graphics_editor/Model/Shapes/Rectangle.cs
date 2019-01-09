using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Rectangle : IDrawable, IBrushable
    {
        private Pen _pen;
        private Point _startPoint;
        private Point _endPoint;
        private SolidBrush _brush;

        public Color BrushColor
        {
            get
            {
                return _brush.Color;
            }
            set
            {
                _brush = new SolidBrush(value);
            }
        }

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

        public Pen Pen
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
    }
}
