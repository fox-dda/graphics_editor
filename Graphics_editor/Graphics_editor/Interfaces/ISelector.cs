using System;
using System.Collections.Generic;
using SDK;
using GraphicsEditor.Model;
using System.Drawing;

namespace GraphicsEditor.Interfaces
{
    public interface ISelector
    {
        /// <summary>
        /// Поиск фигуры по точке
        /// </summary>
        /// <param name="mousePoint">Точка для поиска</param>
        /// <param name="draftList">Список фигур, где производится поиск</param>
        /// <returns>Найденная фигура</returns>
        IDrawable PointSearch(Point mousePoint, IList<IDrawable> draftList);


        /// <summary>
        /// Поиск фигур в области
        /// </summary>
        /// <param name="frame">Область в которой осуществляется поиск</param>
        /// <param name="draftList">Список фигур, где производится поиск</param>
        /// <returns>Найденные фигуры</returns>
        IList<IDrawable> LassoSearch(IDrawable frame, IList<IDrawable> draftList);

        /// <summary>
        /// Найти точку в фигуре по заданным координатам
        /// </summary>
        /// <param name="mousePoint">Заданные координаты</param>
        /// <param name="highlighList">Список, где производится поиск</param>
        /// <returns>Точка в фигуре</returns>
        DotInDraft SearchReferenceDot(Point mousePoint, IList<IDrawable> highlighList);
          
    }
}
