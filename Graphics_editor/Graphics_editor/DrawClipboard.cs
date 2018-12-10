using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    class DrawClipboard
    {
        private List<IDrawable> _clipboard = new List<IDrawable>();

        public void SetRange(List<IDrawable> items)
        {
            _clipboard.Clear();
            foreach(IDrawable item in items)
            {
                if(item is Polygon)
                {
                    _clipboard.Add(new Polygon((item as Polygon).DotList, item.Pen) { BrushColor = (item as Polygon).BrushColor});
                }
                else if(item is Polyline)
                {
                    _clipboard.Add(new Polyline((item as Polyline).DotList, item.Pen));
                }
                else if (item is Circle)
                {
                    _clipboard.Add(new Circle(item.StartPoint, item.EndPoint, item.Pen) { BrushColor = (item as Circle).BrushColor });
                }
                else if (item is Ellipse)
                {
                    _clipboard.Add(new Ellipse(item.StartPoint, item.EndPoint, item.Pen) { BrushColor = (item as Ellipse).BrushColor });
                }
                else if (item is Line)
                {
                    _clipboard.Add(new Line(item.StartPoint, item.EndPoint, item.Pen));
                }
                else if (item is Triangle)
                {
                    _clipboard.Add(new Triangle(item.StartPoint, item.EndPoint, item.Pen) { BrushColor = (item as Triangle).BrushColor });
                }
            }
        }

        public List<IDrawable> GetAll()
        {
            List<IDrawable> returnList = new List<IDrawable>();

            foreach (IDrawable item in _clipboard)
            {
                if (item is Polygon)
                {
                    returnList.Add(new Polygon((item as Polygon).DotList, item.Pen) { BrushColor = (item as Polygon).BrushColor });
                }
                else if (item is Polyline)
                {
                    returnList.Add(new Polyline((item as Polyline).DotList, item.Pen));
                }
                else if (item is Circle)
                {
                    returnList.Add(new Circle(item.StartPoint, item.EndPoint, item.Pen) { BrushColor = (item as Circle).BrushColor });
                }
                else if (item is Ellipse)
                {
                    returnList.Add(new Ellipse(item.StartPoint, item.EndPoint, item.Pen) { BrushColor = (item as Ellipse).BrushColor });
                }
                else if (item is Line)
                {
                    returnList.Add(new Line(item.StartPoint, item.EndPoint, item.Pen));
                }
                else if (item is Triangle)
                {
                    returnList.Add(new Triangle(item.StartPoint, item.EndPoint, item.Pen) { BrushColor = (item as Triangle).BrushColor });
                }
            }
            return returnList;
        }
    }
}