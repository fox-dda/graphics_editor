using System;
using System.Collections.Generic;
using System.Drawing;

namespace SDK.Interfaces
{
    public interface IDraftFactory
    {
        /// <summary>
        /// Создать фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="pointList">Список точек</param>
        /// <param name="gPen">Перо</param>
        /// <param name="brushColor">Цвет заливки</param>
        /// <returns>Созданная фигура</returns>
        IDrawable CreateDraft(string figure, IList<Point> pointList,
            IPenSettings gPen, Color brushColor);

        /// <summary>
        /// Создать клон фигуры
        /// </summary>
        /// <param name="draft">Клонируемая фигура</param>
        /// <returns>Клон фигуры</returns>
        IDrawable Clone(IDrawable draft);

        /// <summary>
        /// Определить однородность фигур, в случае неоднородности вернуть null
        /// </summary>
        /// <param name="draftList">Список фигур</param>
        /// <returns>Тип однородных фигур</returns>
        Type CheckUniformity(IList<IDrawable> draftList);
    }
}

