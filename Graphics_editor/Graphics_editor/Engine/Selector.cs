using System.Collections.Generic;
using System.Drawing;
using System;
using GraphicsEditor.Model;
using System.Windows.Forms;

namespace GraphicsEditor
{
    /// <summary>
    /// Искатель фигур
    /// </summary>
    static class Selector
    {
        /// <summary>
        /// Поиск фигуры по точке
        /// </summary>
        /// <param name="mousePoint">Точка для поиска</param>
        /// <param name="draftList">Список фигур, где производится поиск</param>
        /// <returns>Найденная фигура</returns>
        public static IDrawable PointSearch(Point  mousePoint, List<IDrawable> draftList)
        {
            if (draftList == null)
                return null;
            
            for (int i = draftList.Count - 1; i > -1; i--)
            {
                if (draftList[i] == null)
                    continue;

                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;
                var my = mousePoint.Y;
                var mx = mousePoint.X;

                if (draftList[i] is Polygon)
                {
                    int minX = draftList[i].StartPoint.X;
                    int maxX = draftList[i].StartPoint.X;
                    int minY = draftList[i].StartPoint.Y;
                    int maxY = draftList[i].StartPoint.Y;
                    foreach (Point point in (draftList[i] as Polygon).DotList)
                    {
                        if (minX > point.X)
                        {
                            minX = point.X;
                        }
                        if (maxX < point.X)
                        {
                            maxX = point.X;
                        }
                        if (minY > point.Y)
                        {
                            minY = point.Y;
                        }
                        if (maxY < point.Y)
                        {
                            maxY = point.Y;
                        }
                    }
                    sx = minX;
                    sy = minY;
                    ex = maxX;
                    ey = maxY;
                }
                else if(draftList[i] is Polyline)
                {
                    int minX = draftList[i].StartPoint.X;
                    int maxX = draftList[i].StartPoint.X;
                    int minY = draftList[i].StartPoint.Y;
                    int maxY = draftList[i].StartPoint.Y;
                    foreach (Point point in (draftList[i] as Polyline).DotList)
                    {
                        if (minX > point.X)
                        {
                            minX = point.X;
                        }
                        if (maxX < point.X)
                        {
                            maxX = point.X;
                        }
                        if (minY > point.Y)
                        {
                            minY = point.Y;
                        }
                        if (maxY < point.Y)
                        {
                            maxY = point.Y;
                        }
                    }
                    sx = minX;
                    sy = minY;
                    ex = maxX;
                    ey = maxY;
                }
                else if (draftList[i] is Circle)
                {
                    var size = Math.Abs(draftList[i].EndPoint.X - draftList[i].StartPoint.X) > Math.Abs(draftList[i].EndPoint.Y - draftList[i].StartPoint.Y) ?
                        Math.Abs(draftList[i].EndPoint.X - draftList[i].StartPoint.X) : Math.Abs(draftList[i].EndPoint.Y - draftList[i].StartPoint.Y);

                    //сверху вниз слево направа
                    if ((draftList[i].StartPoint.Y < draftList[i].EndPoint.Y) && (draftList[i].StartPoint.X < draftList[i].EndPoint.X))
                    {

                    }
                    //сверху вниз справа налево
                    else if ((draftList[i].StartPoint.Y < draftList[i].EndPoint.Y) && (draftList[i].StartPoint.X > draftList[i].EndPoint.X))
                    {
                        sx = draftList[i].StartPoint.X - size;
                        sy = draftList[i].StartPoint.Y;
                    }
                    //cнизу вверх слево на права
                    else if ((draftList[i].StartPoint.Y > draftList[i].EndPoint.Y) && (draftList[i].StartPoint.X < draftList[i].EndPoint.X))
                    {
                        sx = draftList[i].StartPoint.X;
                        sy = draftList[i].StartPoint.Y - size;
                    }
                    //cнизу вверх справа налево
                    else if ((draftList[i].StartPoint.Y > draftList[i].EndPoint.Y) && (draftList[i].StartPoint.X > draftList[i].EndPoint.X))
                    {
                        sx = draftList[i].StartPoint.X - size;
                        sy = draftList[i].StartPoint.Y - size;
                    }
                    ex = draftList[i].StartPoint.X + size;
                    ey = draftList[i].StartPoint.Y + size;
                }

                if ((sy < my) && (sx < mx) && (ey > my) && (ex > mx))
                    return draftList[i];
                else if ((sy > my) && (sx > mx) && (ey < my) && (ex < mx))
                    return draftList[i];
                else if ((sy < my) && (sx > mx) && (ey > my) && (ex < mx))
                    return draftList[i];
                else if ((sy > my) && (sx < mx) && (ey < my) && (ex > mx))
                    return draftList[i];
            }
            return null;
        }

        /// <summary>
        /// Поиск фигур в области
        /// </summary>
        /// <param name="frame">Область в которой осуществляется поиск</param>
        /// <param name="draftList">Список фигур, где производится поиск</param>
        /// <returns>Найденные фигуры</returns>
        public static List<IDrawable> LassoSearch(HighlightRect frame, List<IDrawable> draftList)
        {
            List<IDrawable> findList = new List<IDrawable>();
            for (int i = draftList.Count - 1; i > -1; i--)
            {
                if (draftList[i] == null)
                    continue;
                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;

                var fsy = frame.StartPoint.Y;
                var fsx = frame.StartPoint.X;
                var fey = frame.EndPoint.Y;
                var fex = frame.EndPoint.X;

                int minX = fsx > fex ? fex : fsx;
                int maxX = fsx > fex ? fsx : fex;
                int minY = fsy > fey ? fey : fsy;
                int maxY = fsy > fey ? fsy : fey;

                fsx = minX;
                fsy = minY;
                fex = maxX;
                fey = maxY;

                if ((sy > fsy) && (ey < fey) && (sx > fsx) && (ex < fex) )
                    findList.Add(draftList[i]);
            }
            return findList;
        }

        /// <summary>
        /// Определить находится ли точка в заданной области
        /// </summary>
        /// <param name="desiredPoint">Искомая тоска</param>
        /// <param name="rectPoint">Левая верхняя точка области поиска</param>
        /// <param name="regionSize">Ширина области поиска</param>
        /// <returns>Вхождение в область</returns>
        private static bool IsInRect(Point desiredPoint, Point rectPoint, int regionSize)
        {
            if ((desiredPoint.X > rectPoint.X) && (desiredPoint.X < rectPoint.X + regionSize) && 
                (desiredPoint.Y > rectPoint.Y) && (desiredPoint.Y < rectPoint.Y + regionSize))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Найти точку в фигуре по заданным координатам
        /// </summary>
        /// <param name="mousePoint">Заданные координаты</param>
        /// <param name="highlighList">Список, где производится поиск</param>
        /// <returns>Точка в фигуре</returns>
        public static DotInDraft SearchReferenceDot(Point mousePoint, List<IDrawable> highlighList)
        {
            DotInDraft dotInDraft = new DotInDraft();

            foreach(IDrawable draft in highlighList)
            {
                if(draft is Polygon)
                {
                    foreach(Point point in (draft as Polygon).DotList)
                        {
                        if (IsInRect(mousePoint, point, 6))
                            dotInDraft.Set(draft, point);
                    }
                }
                else if(draft is Polyline)
                {

                    foreach (Point point in (draft as Polyline).DotList)
                    {
                        if (IsInRect(mousePoint, point, 6))
                            dotInDraft.Set(draft, point);
                    }
                }
                else
                {
                    if (IsInRect(mousePoint, draft.StartPoint, 6))
                        dotInDraft.Set(draft, draft.StartPoint);
                    if (IsInRect(mousePoint, draft.EndPoint, 6))
                        dotInDraft.Set(draft, draft.EndPoint);
                }
            }

        return dotInDraft;
        }
    }
}