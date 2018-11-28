using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Ellipse : IDrawable, IBrushable
    {
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
        private Point startPoint;
        private Point endPoint;
        private Pen pen;
        private bool isHighlighting = false;
        protected  SolidBrush _brush;

        public Point StartPoint
        {
            get
            {
                return startPoint;
            }
            set
            {
                startPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return endPoint;
            }
            set
            {
                endPoint = value;
            }
        }

        public Pen Pen
        {
            get
            {
                return pen;
            }
            set
            {
                pen = value;
            }
        }

        public bool IsHighlighting
        {
            get
            {
                return isHighlighting;
            }
            set
            {
                isHighlighting = value;
            }
        }

        public void Draw(Graphics g)
        {
            if (_brush != null)
                g.FillEllipse(_brush, new RectangleF(StartPoint.X, StartPoint.Y,
                -(StartPoint.X - EndPoint.X), -(StartPoint.Y - EndPoint.Y)));
            g.DrawEllipse(Pen, new RectangleF(StartPoint.X, StartPoint.Y, 
                -(StartPoint.X - EndPoint.X), -(StartPoint.Y - EndPoint.Y)));
        }

        public Ellipse(Point _startPoint, Point _endPoint, Pen _pen)
        {
            StartPoint = _startPoint;
            EndPoint = _endPoint;
            Pen = _pen;
        }
    }
}
