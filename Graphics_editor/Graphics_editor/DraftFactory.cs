﻿using System;
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
            else if (figure == Figure.drag)
                return Strategy.dragAndDrop;
            else
                return Strategy.selection;
        }
        
    }
}
