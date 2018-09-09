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

        public Point StartPoint;
        public Point EndPoint;
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
