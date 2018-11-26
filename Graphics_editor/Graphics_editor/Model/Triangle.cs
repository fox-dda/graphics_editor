using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Triangle : IDrawable, IBrushable
    {
        private Point _startPoint;
        private Point _endPoint;
        private Pen _pen;
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

        public void Draw(Graphics g)
        {
            Point vertex = new Point(Math.Abs((EndPoint.X - StartPoint.X) / 2) + StartPoint.X, StartPoint.Y);
            if (_brush != null)
                g.FillPolygon(_brush, new PointF[] {
                    vertex,
                    _endPoint,
                    _endPoint,
                    new Point(StartPoint.X, EndPoint.Y),
                    new Point(StartPoint.X, EndPoint.Y),
                    vertex
                });
            g.DrawLine(Pen, vertex, EndPoint);                                  // Линия "\"
            g.DrawLine(Pen, EndPoint, new Point(StartPoint.X, EndPoint.Y));     // Линия "_"
            g.DrawLine(Pen, new Point(StartPoint.X, EndPoint.Y), vertex);       // Линия "/"

        }

        /// <summary>
        /// Создает объект Triangle внутри прямоугольника с координатами левого верхнего угла startPoint и правого нижнего угла endPoint
        /// </summary>
        /// <param name="startPoint"> Левый верхний угол прямоугольника, в который будет вписан треугольник</param>
        /// <param name="endPoint"> Правый верхний угол прямоугольника, в который будет вписан треугольник</param>
        /// <param name="pen"> Перо</param>
        public Triangle(Point startPoint, Point endPoint, Pen pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Pen = pen;
        }
    }
}
