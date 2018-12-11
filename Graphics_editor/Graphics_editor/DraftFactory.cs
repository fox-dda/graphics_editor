using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;

namespace GraphicsEditor
{
    static class DraftFactory
    {
        //Создание объекта фигуры с количеством точек равным 2
        public static IDrawable CreateDraft(Figure figure, Point startPoint, Point endPoint, Pen gPen, Color brushColor)
        {
            switch (figure)
            {
                case Figure.line:
                    return new Line(startPoint, endPoint, gPen);
                case Figure.circle:
                    return new Circle(startPoint, endPoint, gPen) { BrushColor = brushColor };
                case Figure.triangle:
                    return new Triangle(startPoint, endPoint, gPen) { BrushColor = brushColor };
                case Figure.ellipse:
                    return new Ellipse(startPoint, endPoint, gPen) { BrushColor = brushColor };
                default:
                    return null;
            }
        }

        public static HighlightRect CreateDraft(Figure figure, Point startPoint, Point endPoint)
        {
            switch (figure)
            {
                case Figure.select:
                    return new HighlightRect(startPoint, endPoint); 
                default:
                    return null;
            }
        }

        public static HighlightRect CreateDraft(Figure figure, IDrawable frameItem)
        {
            switch (figure)
            {
                case Figure.select:
                    return new HighlightRect(frameItem);
                default:
                    return null;
            }
        }
        //Перегрузка для создания объектов с количеством точек 2 и более
        public static IDrawable CreateDraft(Figure figure, List<Point> pointList, Pen gPen, Color brushColor)
        {
            switch (figure)
            {
                case Figure.polyline:
                    return new Polyline(pointList, gPen);
                case Figure.polygon:
                    return new Polygon(pointList, gPen) { BrushColor = brushColor };
                default:
                    return null;
            }
        }

        //Определение стратегии отрисовки фигуры по её классу
        public static Strategy DefineStrategy(Figure figure)
        {
            if ((figure == Figure.line) || (figure == Figure.ellipse) || (figure == Figure.triangle) || (figure == Figure.circle))
                return Strategy.twoPoint;
            else if ((figure == Figure.polyline) || (figure == Figure.polygon))
                return Strategy.multipoint;
            else if ((figure == Figure.dragPoint) || (figure == Figure.dragDraft))
                return Strategy.dragAndDrop;
            else
                return Strategy.selection;
        }
        
        public static void BaisObject(IDrawable draft, Point bais)
        {
            if (draft is Polygon)
            {
                for (int i = 0; i < (draft as Polygon).DotList.Count; i++)
                {
                    (draft as Polygon).DotList[i] = new Point((draft as Polygon).DotList[i].X + bais.X,
                        (draft as Polygon).DotList[i].Y + +bais.Y);
                }
            }
            else if (draft is Polyline)
            {
                for (int i = 0; i < (draft as Polyline).DotList.Count; i++)
                {
                    (draft as Polyline).DotList[i] = new Point((draft as Polyline).DotList[i].X + bais.X,
                        (draft as Polyline).DotList[i].Y + +bais.Y);
                }
            }
            else
            {
                draft.StartPoint = new Point(draft.StartPoint.X + bais.X, draft.StartPoint.Y + bais.Y);
                draft.EndPoint = new Point(draft.EndPoint.X + bais.X, draft.EndPoint.Y + bais.Y);
            }
        }

        public static void DragDotInDraft(DotInDraft dotInDraft, Point newPoint)
        {
            var item = dotInDraft.Draft;
            var point = dotInDraft.Point;

            if (item is Polygon)
            {
                if ((item as Polygon).DotList[(item as Polygon).DotList.IndexOf(point)] != newPoint)
                    (item as Polygon).DotList[(item as Polygon).DotList.IndexOf(point)] = newPoint;
            }
            else if (item is Polyline)
            {
                if ((item as Polyline).DotList[(item as Polyline).DotList.IndexOf(point)] != newPoint)
                    (item as Polyline).DotList[(item as Polyline).DotList.IndexOf(point)] = newPoint;
            }
            else
            {
                if (item.StartPoint == point)
                {
                    if (item.StartPoint != newPoint)
                        item.StartPoint = newPoint;
                }
                else if (item.EndPoint == point)
                {
                    if (item.EndPoint != newPoint)
                        item.EndPoint = newPoint;
                }
            }
        }
    }
}
