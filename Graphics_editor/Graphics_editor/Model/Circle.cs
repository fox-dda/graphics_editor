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
        private Point centre;
        private int radius;
        public Pen _pen;


        public Point StartPoint
        {
            get
            {
                return centre;
            }
            set
            {
                centre = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return new Point(centre.X + radius, centre.Y);
            }
            set
            {
                radius = Math.Abs(centre.X - value.X);
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
            g.DrawEllipse(Pen, centre.X - radius, centre.Y - radius, radius * 2, radius * 2);
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
