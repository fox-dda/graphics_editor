using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Состаяние художника
    /// </summary>
    class PainterState
    {
        /// <summary>
        /// Стратегия отрисовки
        /// </summary>
        public Strategy DrawingStrategy
        {
            get
            {
                return DraftFactory.DefineStrategy(Figure);
            }
        }

        /// <summary>
        /// Рисуемая фигура
        /// </summary>
        private Figure _figure = Figure.select;

        /// <summary>
        /// Нерисуемая фигура
        /// </summary>
        public IDrawable UndrawableDraft;

        /// <summary>
        /// Рисуемая фигура
        /// </summary>
        public Figure Figure
        {
            get
            {
                return _figure;
            }
            set
            {
                InPocessPoints.Clear();
                DragDropDraft = null;
                DragDropDot.Draft = null;
                CacheDraft = null;
                CacheLasso = null;

                _figure = value;
            }
        }

        /// <summary>
        /// Список обрабатываемых точек
        /// </summary>
        public List<Point> InPocessPoints = new List<Point>();

        /// <summary>
        /// Двигаемая фигура
        /// </summary>
        public IDrawable DragDropDraft;

        /// <summary>
        /// Двигаемая точка в фигуре
        /// </summary>
        public DotInDraft DragDropDot;

        /// <summary>
        /// Фигура в кэше
        /// </summary>
        public IDrawable CacheDraft;

        /// <summary>
        /// Ласо в кэше
        /// </summary>
        public HighlightRect CacheLasso;
    }
}
