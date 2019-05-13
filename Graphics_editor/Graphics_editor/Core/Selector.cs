using System.Collections.Generic;
using System.Drawing;
using System;
using GraphicsEditor.Model;
using SDK;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor
{
    /// <summary>
    /// Искатель фигур
    /// </summary>
    public class Selector: ISelector
    {
        /// <summary>
        /// Поиск фигуры по точке
        /// </summary>
        /// <param name="mousePoint">Точка для поиска</param>
        /// <param name="draftList">Список фигур, где производится поиск</param>
        /// <returns>Найденная фигура</returns>
        public IDrawable PointSearch(Point  mousePoint, List<IDrawable> draftList)
        {
            if (draftList == null)
                return null;
            
            for (var i = draftList.Count - 1; i > -1; i--)
            {
                if (draftList[i] == null)
                    continue;
                var sy = Math.Min(draftList[i].StartPoint.Y, draftList[i].EndPoint.Y);
                var sx = Math.Min(draftList[i].StartPoint.X, draftList[i].EndPoint.X);
                var ey = Math.Max(draftList[i].StartPoint.Y, draftList[i].EndPoint.Y);
                var ex = Math.Max(draftList[i].StartPoint.X, draftList[i].EndPoint.X);

                var my = mousePoint.Y;
                var mx = mousePoint.X;

                if (draftList[i] is IMultipoint multipoint)
                {
                    foreach (var point in multipoint.DotList)
                    {
                        sx = Math.Min(sx, point.X);
                        ex = Math.Max(ex, point.X);
                        sy = Math.Min(sy, point.Y);
                        ey = Math.Max(ey, point.Y);
                    }
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
        public List<IDrawable> LassoSearch(IDrawable frame,
            List<IDrawable> draftList)
        {
            var findList = new List<IDrawable>();
            for (var i = draftList.Count - 1; i > -1; i--)
            {
                if (draftList[i] == null)
                    continue;
                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;

                var fsy = Math.Min(frame.StartPoint.Y, frame.EndPoint.Y);
                var fsx = Math.Min(frame.StartPoint.X, frame.EndPoint.X);
                var fey = Math.Max(frame.StartPoint.Y, frame.EndPoint.Y);
                var fex = Math.Max(frame.StartPoint.X, frame.EndPoint.X);

                if ((sy > fsy) && (ey < fey) && (sx > fsx) && (ex < fex))
                {
                    findList.Add(draftList[i]);
                }
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
        private bool IsInRect(Point desiredPoint,
            Point rectPoint, int regionSize)
        {
            if ((desiredPoint.X > rectPoint.X) && 
                (desiredPoint.X < rectPoint.X + regionSize) && 
                (desiredPoint.Y > rectPoint.Y) &&
                (desiredPoint.Y < rectPoint.Y + regionSize))
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
        public DotInDraft SearchReferenceDot(Point mousePoint,
            List<IDrawable> highlighList)
        {
            DotInDraft dotInDraft = new DotInDraft();

            foreach(var draft in highlighList)
            {
                if(draft is IMultipoint multipoint)
                {
                    foreach(Point point in multipoint.DotList)
                        {
                            if (IsInRect(mousePoint, point, 6))
                            {
                                dotInDraft.Set(draft, point);
                            }
                        }
                }
                else
                {
                    if (IsInRect(mousePoint,
                        draft.StartPoint, 6))
                    {
                        dotInDraft.Set(draft, draft.StartPoint);
                    }

                    if (IsInRect(mousePoint,
                        draft.EndPoint, 6))
                    {
                        dotInDraft.Set(draft, draft.EndPoint);
                    }
                }
            }

        return dotInDraft;
        }
    }
}