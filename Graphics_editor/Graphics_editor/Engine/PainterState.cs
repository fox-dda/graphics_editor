using System.Collections.Generic;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;
using SDK;

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
                var factory = new DraftFactory();
                return factory.DefineStrategy(Figure);
            }
        }

        /// <summary>
        /// Рисуемая фигура
        /// </summary>
        private string _figure = "HighlightRect";

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
        public string Figure
        {
            get => _figure;
            set
            {
                InProcessPoints.Clear();
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

        /// <summary>
        /// Двигаемая фигура
        /// </summary>
        private IDrawable _dragDropDraft;

        /// <summary>
        /// Двигаемая точка в фигуре
        /// </summary>
        /// Возможна ситуация, где мы не нашли фигуру по точке клика,
        /// Тогда данное поле должно быть null
        /// Потому используем публичное поле, а не свойство
        public DotInDraft DragDropDot;

        /// <summary>
        /// Фигура в кэше
        /// </summary>
        public IDrawable CacheDraft
        {
            get => _cacheDraft;
            set => _cacheDraft = value;
        }

        /// <summary>
        /// Фигура в кеше
        /// </summary>
        private IDrawable _cacheDraft;

        /// <summary>
        /// Ласо в кэше
        /// </summary>
        public HighlightRect CacheLasso
        {
            get => _cacheLasso;
            set => _cacheLasso = value;
        }

        /// <summary>
        /// Кеш ласо
        /// </summary>
        private HighlightRect _cacheLasso;
    }
}
