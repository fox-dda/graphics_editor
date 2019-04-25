using System;
using System.Collections.Generic;
using GraphicsEditor.Model;
using SDK;
using GraphicsEditor.Enums;
using System.Drawing;
using System.Linq;

namespace GraphicsEditor
{
    /// <summary>
    /// Фабрика фигур
    /// </summary>
    public class DraftFactory
    {
        /// <summary>
        /// Создать фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="pointList">Список точек</param>
        /// <param name="gPen">Перо</param>
        /// <param name="brushColor">Цвет заливки</param>
        /// <returns>Созданная фигура</returns>
        public IDrawable CreateDraft(Figure figure, List<Point> pointList,
            PenSettings gPen, Color brushColor)
        {
            switch (figure)
            {
                case Figure.Polyline:
                    return new Polyline(pointList, gPen);
                case Figure.Polygon:
                    return new Polygon(pointList, gPen) { BrushColor = brushColor };
                case Figure.Line:
                    return new Line(pointList[0], pointList.Last(), gPen);
                case Figure.Circle:
                    return new Circle(pointList[0], pointList.Last(), gPen)
                        { BrushColor = brushColor };
                case Figure.Ellipse:
                    return new Ellipse(pointList[0], pointList.Last(), gPen)
                        { BrushColor = brushColor };
                case Figure.Select:
                    return new HighlightRect(pointList[0], pointList.Last());
                default:
                    return null;
            }
        }

        /// <summary>
        /// Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(Figure figure)
        {
            switch (figure)
            {
                case Figure.Line:
                case Figure.Ellipse:
                case Figure.Circle:
                    return Strategy.TwoPoint;
                case Figure.Polyline:
                case Figure.Polygon:
                    return Strategy.Multipoint;
                case Figure.DragPoint:
                case Figure.DragDraft:
                    return Strategy.DragAndDrop;
                default:
                    return Strategy.Selection;
            }
        }

        /// <summary>
        /// Создать клон фигуры
        /// </summary>
        /// <param name="draft">Клонируемая фигура</param>
        /// <returns>Клон фигуры</returns>
        public IDrawable Clone(IDrawable draft)
        {
            var cloneList = new List<Point>();
            if (draft is IMultipoint multipoint)
            {
                foreach (var point in multipoint.DotList)
                {
                    cloneList.Add(new Point(point.X, point.Y));
                }
            }

            switch (draft)
            {
                case Polygon polygon:
                {
                    return new Polygon(cloneList, polygon.Pen)
                    {
                        BrushColor = polygon.BrushColor
                    };
                }
                case Polyline polyline:
                {
                    return new Polyline(cloneList, polyline.Pen);
                }
                case Circle circle:
                    return new Circle(
                            new Point(circle.StartPoint.X, circle.StartPoint.Y),
                            new Point(circle.EndPoint.X, circle.EndPoint.Y),
                            new PenSettings
                            {
                                Color = circle.Pen.Color,
                                Width = circle.Pen.Width,
                                DashPattern = circle.Pen.DashPattern
                            })
                        { BrushColor = circle.BrushColor};
                case Ellipse ellipse:
                    return new Ellipse(
                            new Point(ellipse.StartPoint.X, ellipse.StartPoint.Y),
                            new Point(ellipse.EndPoint.X, ellipse.EndPoint.Y),
                            new PenSettings
                            {
                                Color = ellipse.Pen.Color,
                                Width = ellipse.Pen.Width,
                                DashPattern = ellipse.Pen.DashPattern
                            })
                        { BrushColor = ellipse.BrushColor };
                case Line _:
                    return new Line(
                        new Point(draft.StartPoint.X, draft.StartPoint.Y),
                        new Point(draft.EndPoint.X, draft.EndPoint.Y),
                        new PenSettings
                            {
                                Color = draft.Pen.Color,
                                Width = draft.Pen.Width,
                                DashPattern = draft.Pen.DashPattern
                            });
                default:
                    return null;
            }
        }

        /// <summary>
        /// Определить однородность фигур, в случае неоднородности вернуть null
        /// </summary>
        /// <param name="draftList">Список фигур</param>
        /// <returns>Тип однородных фигур</returns>
        public Type CheckUniformity(List<IDrawable> draftList)
        {
            if (draftList == null)
                return null;

            var type = draftList[0].GetType();

            foreach (var draft in draftList)
            {
                if (draft.GetType() != type)
                    return null;
            }
            return type;
        }
    }
}
