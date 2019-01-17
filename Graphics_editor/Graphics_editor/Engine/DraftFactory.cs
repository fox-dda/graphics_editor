using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using GraphicsEditor.Enums;
using System.Drawing;

namespace GraphicsEditor
{
    static class DraftFactory
    {
        //Создание объекта фигуры с количеством точек равным 2
        public static IDrawable CreateDraft(Figure figure, Point startPoint, Point endPoint, PenSettings gPen, Color brushColor)
        {
            switch (figure)
            {
                case Figure.line:
                    return new Line(startPoint, endPoint, gPen);
                case Figure.circle:
                    return new Circle(startPoint, endPoint, gPen) { BrushColor = brushColor };
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
        public static IDrawable CreateDraft(Figure figure, List<Point> pointList, PenSettings gPen, Color brushColor)
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

        public static IDrawable CreateDraft(Figure figure, List<Point> pointList, PenSettings gPen)
        {
            switch (figure)
            {
                case Figure.polyline:
                    return new Polyline(pointList, gPen);
                default:
                    return null;
            }
        }

        public static IDrawable CreateDraft(Figure figure, Point startPoint, Point endPoint, PenSettings gPen)
        {
            switch (figure)
            {
                case Figure.line:
                    return new Line(startPoint, endPoint, gPen);
                default:
                    return null;
            }
        }

        public static Figure DefineDraftEnum(IDrawable draft)
        {
            switch(draft.GetType().ToString().Split('.').Last())
            {
                case "Line":
                    {
                        return Figure.line;              
                    }
                case "Ellipse":
                    {
                        return Figure.ellipse;
                    }
                case "Circle":
                    {
                        return Figure.circle;
                    }
                case "Polyline":
                    {
                        return Figure.polyline;
                    }
                default:
                    {
                        return Figure.polygon;
                    }
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

        public static Pen CreatePen(PenSettings settings)
        {
            if(settings.DashPattern != null)
            {
                return new Pen(settings.Color, settings.Width) { DashPattern = settings.DashPattern};
            }
            else
            {
                return new Pen(settings.Color, settings.Width);
            }
        }

        public static IDrawable Clone(IDrawable draft)
        {
            if (draft is Polygon)
            {
                List<Point> cloneList = new List<Point>();
                foreach (Point point in (draft as Polygon).DotList)
                {
                    cloneList.Add(new Point(point.X, point.Y));
                }

                return new Polygon(cloneList, (draft as Polygon).Pen) { BrushColor = (draft as Polygon).BrushColor };
            }
            else if (draft is Polyline)
            {
                List<Point> cloneList = new List<Point>();
                foreach (Point point in (draft as Polyline).DotList)
                {
                    cloneList.Add(new Point(point.X, point.Y));
                }

                return new Polyline(cloneList, (draft as Polyline).Pen);
            }
            else if (draft is Circle)
            {
                return new Circle(new Point(draft.StartPoint.X, draft.StartPoint.Y),
                    new Point(draft.EndPoint.X, draft.EndPoint.Y), new PenSettings() {Color = draft.Pen.Color, Width = draft.Pen.Width, DashPattern = draft.Pen.DashPattern })
                { BrushColor = (draft as Circle).BrushColor};
            }
            else if (draft is Ellipse)
            {
                return new Ellipse(new Point(draft.StartPoint.X, draft.StartPoint.Y),
                    new Point(draft.EndPoint.X, draft.EndPoint.Y), new PenSettings()
                    { Color = draft.Pen.Color, Width = draft.Pen.Width, DashPattern = draft.Pen.DashPattern })
                    { BrushColor = (draft as Ellipse).BrushColor };
            }
            else if (draft is Line)
            {
                return new Line(new Point(draft.StartPoint.X, draft.StartPoint.Y),
                    new Point(draft.EndPoint.X, draft.EndPoint.Y), new PenSettings()
                    { Color = draft.Pen.Color, Width = draft.Pen.Width, DashPattern = draft.Pen.DashPattern });
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
