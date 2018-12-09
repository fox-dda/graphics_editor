using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEditor.Model;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class HighlightRect
    {
        private Point _startPoint;
        private Point _endPoint;
        private List<Point> _dotList = null;

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

        public void RemoveFrame(Graphics g, Color canvasColor)
        {
            Draw(g, canvasColor);
        }

        public void AddFrame(Graphics g)
        {
            Draw(g, Color.Gray);
        }

        private void Draw(Graphics g, Color color)
        {
            var _pen = new Pen(color, 1);
            _pen.DashPattern = new float[] { 2, 2 };

            //сверху вниз слево направа
            if ((StartPoint.Y < EndPoint.Y) && (StartPoint.X < EndPoint.X))
            {
                g.DrawRectangle(_pen, StartPoint.X, StartPoint.Y,
                    Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
            }
            //сверху вниз справа налево
            else if ((StartPoint.Y < EndPoint.Y) && (StartPoint.X > EndPoint.X))
            {
                g.DrawRectangle(_pen, EndPoint.X, StartPoint.Y,
                    Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
            }
            //cнизу вверх слево на права
            else if ((StartPoint.Y > EndPoint.Y) && (StartPoint.X < EndPoint.X))
            {
                g.DrawRectangle(_pen, StartPoint.X, EndPoint.Y,
                    Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
            }

            //cнизу вверх справа налево
            else if ((StartPoint.Y > EndPoint.Y) && (StartPoint.X > EndPoint.X))
            {
                g.DrawRectangle(_pen, EndPoint.X, EndPoint.Y,
                    Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
            }

            if (_dotList != null)
            {
                foreach (Point dot in _dotList)
                {
                    g.DrawRectangle(new Pen(Color.Red), dot.X, dot.Y, 4, 4);
                    g.FillEllipse(new SolidBrush(Color.Blue), dot.X, dot.Y, 3, 3);
                }
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.Blue), StartPoint.X, StartPoint.Y, 3, 3);
                g.FillEllipse(new SolidBrush(Color.Blue), EndPoint.X, EndPoint.Y, 3, 3);
                g.DrawRectangle(new Pen(Color.Red), StartPoint.X, StartPoint.Y, 4, 4);
                g.DrawRectangle(new Pen(Color.Red), EndPoint.X, EndPoint.Y, 4, 4);
            }
        }

        public HighlightRect(IDrawable frameItem)
        {
            StartPoint = frameItem.StartPoint;
            EndPoint = frameItem.EndPoint;
            if (frameItem is Polygon)
                _dotList = (frameItem as Polygon).DotList;
            if (frameItem is Polyline)
                _dotList = (frameItem as Polyline).DotList;
        }
        public HighlightRect(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
