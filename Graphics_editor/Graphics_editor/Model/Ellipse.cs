using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Ellipse : IDrawable
    {
        private Point startPoint;
        private Point endPoint;
        private Pen pen;


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

        public void Draw(Graphics g)
        {
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
