using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Line : IDrawable
    {
        private Pen _pen;
        private Point _startPoint;
        private Point _endPoint;
        private bool isHighlighting = false;

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

        public void Draw(Graphics g)
        {
            if (IsHighlighting)
            {
                var pen = new Pen(Color.Gray, 1);
                pen.DashPattern = new float[] { 2, 2 };
                g.DrawRectangle(pen, StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
            }
            g.DrawLine(Pen, StartPoint, EndPoint);
        }

        public Line(Point startPoint, Point endPoint, Pen pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            this.Pen = pen;
        }
    }
}
