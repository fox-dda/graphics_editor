using System.Collections.Generic;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IPainterState
    {
        /// <summary>
        /// Стратегия отрисовки
        /// </summary>
        Strategy DrawingStrategy { get; }

        /// <summary>
        /// Нерисуемая фигура
        /// </summary>
        IDrawable UndrawableDraft { get; set; }

        /// <summary>
        /// Рисуемая фигура
        /// </summary>
        string Figure { get; set; }

        /// <summary>
        /// Список обрабатываемых точек
        /// </summary>
        List<Point> InProcessPoints { get; set; }

        /// <summary>
        /// Двигаемая фигура
        /// </summary>
        IDrawable DragDropDraft { get; set; }

        /// <summary>
        /// Точка, которая двигается в фигуре
        /// </summary>
        Point DragDropDotingDot { get; set; }

        /// <summary>
        /// Фигура в которой дивигается точка
        /// </summary>
        IDrawable DragDropDotingDraft { get; set; }

        /// <summary>
        /// Фигура в кэше
        /// </summary>
        IDrawable CacheDraft { get; set; }

        /// <summary>
        /// Ласо в кэше
        /// </summary>
        IDrawable CacheLasso { get; set; }

        DrawAction DrawAction { get; set; }
    }
}
