using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor.Model
{
    class Circle : IDraft
    {
        private Point _startPoint;
        private Point _endPoint;
        private Pen _pen;


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
            float edge;
            if (StartPoint.X > EndPoint.X)
            {
                edge = (EndPoint.X - StartPoint.X);
                g.DrawEllipse(Pen, new RectangleF(StartPoint.X, StartPoint.Y, edge, edge));
            }
            if (StartPoint.X < EndPoint.X)
            {
                edge = (EndPoint.X - StartPoint.X);
                g.DrawEllipse(Pen, new RectangleF(StartPoint.X, EndPoint.Y, edge, edge));
            }

            //if (StartPoint.X > EndPoint.X)
        }

        /// <summary>
        /// Создает объект Circle с центром _centre, радиусом _radius и пером pen
        /// </summary>
        /// <param name="_centre"> Координаты центра</param>
        /// <param name="_radius">Величина радиуса</param>
        /// <param name="pen"></param>
        public Circle(Point _centre, Point _radius, Pen pen)
        {
            StartPoint = _centre;
            EndPoint = _radius;
            Pen = pen;
        }
    }
}
