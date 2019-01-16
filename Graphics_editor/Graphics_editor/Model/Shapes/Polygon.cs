using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    [Serializable]
    class Polygon : IDrawable, IBrushable
    {
        private Color _brush;
        private PenSettings _pen;

        public Color BrushColor
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }
        private List<Point> _dotList = new List<Point>();        
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
        public PenSettings Pen
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

        public void AddPoint(Point point)
        {
            _dotList.Add(point);
        }

        public Polygon(List<Point> dotlist, PenSettings pen)//, Color brushColor)
        {
            Pen = pen;
            DotList = dotlist;
           // BrushColor = brushColor;
        }
        public Polygon() { }
    }
}