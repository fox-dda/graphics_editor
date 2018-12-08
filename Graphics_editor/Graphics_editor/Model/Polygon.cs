using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Polygon : IDrawable, IBrushable
    {
        private SolidBrush _brush;
        private Pen _pen;

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
        public List<Point> _dotList = new List<Point>();        
        public Point StartPoint
        {
            get
            {
                return DotList[0];
            }
            set
            {
                DotList[0] = value;
            }
        }
        public Point EndPoint
        {
            get
            {
                return DotList.Last();
            }
            set
            {
                DotList[DotList.Count - 1] = value;
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
        public List<Point> DotList
        {
            get
            {
                return _dotList;
            }
            set
            {
                if (value.Count < 2)
                {
                    throw new Exception("Нельзя создать линию из одной точки!");
                }
                else
                {
                    _dotList = value;
                }
            }
        }

        public void Draw(Graphics g)
        {
            if (_brush != null)
                g.FillPolygon(_brush, DotList.ToArray());
            g.DrawPolygon(Pen, DotList.ToArray());
        }

        public void AddPoint(Point point)
        {
            _dotList.Add(point);
        }

        public Polygon(List<Point> dotlist, Pen pen)
        {
            Pen = pen;
            DotList = dotlist;
        }
    }
}