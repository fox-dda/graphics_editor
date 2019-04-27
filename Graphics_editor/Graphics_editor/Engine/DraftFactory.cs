using System;
using System.Collections.Generic;
using GraphicsEditor.Model;
using SDK;
using GraphicsEditor.Enums;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using GraphicsEditor.Engine;

namespace GraphicsEditor
{
    /// <summary>
    /// Фабрика фигур
    /// </summary>
    public class DraftFactory
    {
        /// <summary>
        /// Известные типы фигур
        /// </summary>
        private Dictionary<string, Type> _knownTypes;

        public DraftFactory()
        {
            var pluginLoder = new PluginLoader();
            _knownTypes = pluginLoder.LoadModels();
            HighlightRect a = new HighlightRect();
            _knownTypes.Add("HighlightRect", a.GetType()); //Type.GetType("HighlightRect"));
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
            var draft = (IDrawable)Activator.CreateInstance(_knownTypes[figure]);
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
        /// Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(string figure)
        {
            if (figure == "HighlightRect")
            {
                return Strategy.Selection;
            }
            else if (figure == "DragPoint" || figure == "DragDraft")
            {
                return Strategy.DragAndDrop;
            }

            var draft = (IDrawable)Activator.CreateInstance(_knownTypes[figure]);
            if (draft is IMultipoint multipointDraft)
            {
                return Strategy.Multipoint;
            }
            else
            {
                return Strategy.TwoPoint;
            }
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
