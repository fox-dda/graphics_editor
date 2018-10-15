using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor.Model
{
    class Line : IDraft
    {
        private Pen _pen;
        private Point _startPoint;
        private Point _endPoint;

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
