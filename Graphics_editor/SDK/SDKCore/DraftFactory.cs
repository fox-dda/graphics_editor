﻿using System;
using System.Collections.Generic;
using SDK;
using System.Drawing;
using System.Linq;
using StructureMap;

namespace GraphicsEditor
{
    /// <summary>
    /// Фабрика фигур
    /// </summary>
    public class DraftFactory
    {
        /// <summary>
        /// DI контейнер
        /// </summary>
        private Container _container;

        public DraftFactory()
        {
            _container = new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<IDrawable>().NameBy(x => x.Name);
                });
            });
        }

        /// <summary>
        /// Создать фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="pointList">Список точек</param>
        /// <param name="gPen">Перо</param>
        /// <param name="brushColor">Цвет заливки</param>
        /// <returns>Созданная фигура</returns>
        public IDrawable CreateDraft(string figure, List<Point> pointList,
            PenSettings gPen, Color brushColor)
        {
            var draft = _container.GetInstance<IDrawable>(figure);

            draft.Pen = gPen;
            if (draft is IBrushable brushableDraft)
            {
                brushableDraft.BrushColor = brushColor;
            }

            if (draft is IMultipoint multipointDraft)
            {
                multipointDraft.DotList = pointList;
            }
            else
            {
                draft.StartPoint = pointList[0];
                draft.EndPoint = pointList.Last();
            }

            return draft;
        }

        /// <summary>
        /// Создать клон фигуры
        /// </summary>
        /// <param name="draft">Клонируемая фигура</param>
        /// <returns>Клон фигуры</returns>
        public IDrawable Clone(IDrawable draft)
        {
            return (IDrawable)(draft as ICloneable).Clone();
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