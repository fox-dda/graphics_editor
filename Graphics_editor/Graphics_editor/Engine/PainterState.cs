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
    public class PainterState
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
        private Figure _figure = Figure.Select;

        /// <summary>
        /// Нерисуемая фигура
        /// </summary>
        public IDrawable UndrawableDraft
        {
            get => _undrawable;
            set => _undrawable = value;
        }

        /// <summary>
        /// Нерисуемая фигура
        /// </summary>
        private IDrawable _undrawable;

        /// <summary>
        /// Рисуемая фигура
        /// </summary>
        public Figure Figure
        {
            get => _figure;
            set
            {
                InProcessPoints.Clear();
                DragDropDraft = null;
                _dragDropDot.Draft = null;
                CacheDraft = null;
                CacheLasso = null;

                _figure = value;
            }
        }

        /// <summary>
        /// Список обрабатываемых точек
        /// </summary>
        public List<Point> InProcessPoints
        {
            get => _inProcessPoints;
            set => _inProcessPoints = value;
        }
        
        /// <summary>
        /// Список обрабатываемых точек
        /// </summary>
        private List<Point> _inProcessPoints = new List<Point>();

        /// <summary>
        /// Двигаемая фигура
        /// </summary>
        public IDrawable DragDropDraft
        {
            get => _dragDropDraft;
            set => _dragDropDraft = value;
        }

        private IDrawable _dragDropDraft;

        /// <summary>
        /// Двигаемая точка в фигуре
        /// </summary>
        public DotInDraft DragDropDot
        {
            get => _dragDropDot;
            set
            {
                _dragDropDot.Draft = value.Draft;
                _dragDropDot.PointInDraft = value.PointInDraft;
            }
        }

        private DotInDraft _dragDropDot;

        /// <summary>
        /// Фигура в кэше
        /// </summary>
        public IDrawable CacheDraft
        {
            get => _cacheDraft;
            set => _cacheDraft = value;
        }

        private IDrawable _cacheDraft;

        /// <summary>
        /// Ласо в кэше
        /// </summary>
        public HighlightRect CacheLasso
        {
            get => _cacheLasso;
            set => _cacheLasso = value;
        }

        private HighlightRect _cacheLasso;
    }
}
