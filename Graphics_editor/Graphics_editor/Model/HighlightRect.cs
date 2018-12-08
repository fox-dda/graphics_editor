using System;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class HighlightRect
    {
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

            g.FillEllipse(new SolidBrush(Color.Blue), StartPoint.X, StartPoint.Y, 3, 3);
            g.FillEllipse(new SolidBrush(Color.Blue), EndPoint.X, EndPoint.Y, 3, 3);
            g.DrawRectangle(new Pen(Color.Red), StartPoint.X, StartPoint.Y, 4, 4);
            g.DrawRectangle(new Pen(Color.Red), EndPoint.X, EndPoint.Y, 4, 4);
        }
    }
}
