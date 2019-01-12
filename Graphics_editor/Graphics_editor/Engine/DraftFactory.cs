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

        public static IDrawable CreateDraft(Figure figure, List<Point> pointList, Pen gPen)
        {
            switch (figure)
            {
                case Figure.polyline:
                    return new Polyline(pointList, gPen);
                default:
                    return null;
            }
        }

        public static IDrawable CreateDraft(Figure figure, Point startPoint, Point endPoint, Pen gPen)
        {
            switch (figure)
            {
                case Figure.line:
                    return new Line(startPoint, endPoint, gPen);
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

        public static IDrawable Clone(IDrawable draft)
        {
            if (draft is Polygon)
            {
                List<Point> cloneList = new List<Point>();
                foreach (Point point in (draft as Polygon).DotList)
                {
                    cloneList.Add(point);
                }

                return new Polygon(cloneList, (draft as Polygon).Pen) { BrushColor = (draft as Polygon).BrushColor };
            }
            else if (draft is Polyline)
            {
                List<Point> cloneList = new List<Point>();
                foreach (Point point in (draft as Polyline).DotList)
                {
                    cloneList.Add(point);
                }

                return new Polyline(cloneList, (draft as Polyline).Pen);
            }
            else if (draft is Circle)
            {
                return new Circle(new Point(draft.StartPoint.X, draft.StartPoint.Y),
                    new Point(draft.EndPoint.X, draft.EndPoint.Y), new Pen(draft.Pen.Color, draft.Pen.Width)){ BrushColor = (draft as Circle).BrushColor};
            }
            else if (draft is Ellipse)
            {
                return new Ellipse(new Point(draft.StartPoint.X, draft.StartPoint.Y),
                    new Point(draft.EndPoint.X, draft.EndPoint.Y), draft.Pen)
                { BrushColor = (draft as Ellipse).BrushColor };
            }
            else if (draft is Line)
            {
                return new Line(new Point(draft.StartPoint.X, draft.StartPoint.Y),
                    new Point(draft.EndPoint.X, draft.EndPoint.Y), draft.Pen);
            }
            return null;
        }

        public static Point CreatePoint(int X, int Y)
        {
            return new Point(X, Y);
        }

        public static Type CheckUniformity(List<IDrawable> draftList)
        {
            if (draftList == null)
                return null;

            var type = draftList[0].GetType();

            foreach (IDrawable draft in draftList)
            {
                if (draft.GetType() != type)
                    return null;
            }
            return type;
        }
    }
}
