using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    class DraftClipboard
    {
        private List<IDrawable> _clipboard = new List<IDrawable>();

        public void SetRange(List<IDrawable> items)
        {
            _clipboard.Clear();
            foreach(IDrawable item in items)
            {
                if(item is Polygon)
                {
                    var dotList = new List<Point>();
                    foreach(Point point in (item as Polygon).DotList)
                    {
                        dotList.Add(DraftFactory.CreatePoint(point.X, point.Y));
                    }
                    _clipboard.Add(DraftFactory.CreateDraft(Enums.Figure.polygon, (item as Polygon).DotList, item.Pen, (item as Polygon).BrushColor));
                }
                else if(item is Polyline)
                {
                    var dotList = new List<Point>();
                    foreach (Point point in (item as Polyline).DotList)
                    {
                        dotList.Add(DraftFactory.CreatePoint(point.X, point.Y));
                    }
                    _clipboard.Add(DraftFactory.CreateDraft(Enums.Figure.polyline, (item as Polyline).DotList, item.Pen));
                }
                else if (item is Circle)
                {
                    _clipboard.Add(DraftFactory.CreateDraft(Enums.Figure.circle, item.StartPoint, item.EndPoint, item.Pen, (item as Circle).BrushColor));
                }
                else if (item is Ellipse)
                {
                    _clipboard.Add(DraftFactory.CreateDraft(Enums.Figure.circle, item.StartPoint, item.EndPoint, item.Pen, (item as Ellipse).BrushColor));
                }
                else if (item is Line)
                {
                    _clipboard.Add(DraftFactory.CreateDraft(Enums.Figure.line, item.StartPoint, item.EndPoint, item.Pen));
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
                    returnList.Add(DraftFactory.CreateDraft(Enums.Figure.polygon, (item as Polygon).DotList, item.Pen, (item as Polygon).BrushColor));
                }
                else if (item is Polyline)
                {
                    returnList.Add(DraftFactory.CreateDraft(Enums.Figure.polyline, (item as Polyline).DotList, item.Pen));
                }
                else if (item is Circle)
                {
                    returnList.Add(DraftFactory.CreateDraft(Enums.Figure.circle, item.StartPoint, item.EndPoint, item.Pen, (item as Circle).BrushColor));
                }
                else if (item is Ellipse)
                {
                    returnList.Add(DraftFactory.CreateDraft(Enums.Figure.circle, item.StartPoint, item.EndPoint, item.Pen, (item as Ellipse).BrushColor));
                }
                else if (item is Line)
                {
                    returnList.Add(DraftFactory.CreateDraft(Enums.Figure.line, item.StartPoint, item.EndPoint, item.Pen));
                }
            }
            return returnList;
        }
    }
}