using System.Collections.Generic;
using GraphicsEditor.Enums;
using System.Drawing;
using SDK;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Core
{
    /// <summary>
    /// Состаяние художника
    /// </summary>
    public class PainterState: IPainterState
    {
        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="deteminer">Определитель стратегии</param>
        public PainterState(IStrategyDeterminer deteminer)
        {
            _stategyDeterminer = deteminer;
            DrawAction = DrawAction.Highlight;
        }

        /// <summary>
        /// Режим рисовальщика
        /// </summary>
        private DrawAction _drawAction;

        /// <summary>
        /// Режим рисовальщика
        /// </summary>
        public DrawAction DrawAction
        {
            get
            {
                return _drawAction;
            }
            set
            {
                if (value != DrawAction.Draw)
                {
                    Figure = null;
                }
                _drawAction = value;
            }
        }

        /// <summary>
        /// Стратегия отрисовки
        /// </summary>
        public Strategy DrawingStrategy
        {
            get
            {
                if(DrawAction != DrawAction.Draw)
                {
                    return _stategyDeterminer.DefineStrategy(DrawAction);
                }
                else
                {
                    return _stategyDeterminer.DefineStrategy(Figure);
                }              
            }
        }

        /// <summary>
        /// Определитель стратегии
        /// </summary>
        private IStrategyDeterminer _stategyDeterminer;

        /// <summary>
        /// Рисуемая фигура
        /// </summary>
        private string _figure;

        /// <summary>
        /// Нерисуемая фигура
        /// </summary>
        public IDrawable UndrawableDraft { get; set; }


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
                DragDropDotingDraft = null;
                CacheDraft = null;
                CacheLasso = null;
                DrawAction = DrawAction.Draw;

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
        public IDrawable DragDropDraft { get; set; }

        /// <summary>
        /// Точка, которая двигается в фигуре
        /// </summary>
        public Point DragDropDotingDot { get; set; }

        /// <summary>
        /// Фигура в которой дивигается точка
        /// </summary>
        public IDrawable DragDropDotingDraft { get; set; }

        /// <summary>
        /// Фигура в кэше
        /// </summary>
        public IDrawable CacheDraft { get; set; }

        /// <summary>
        /// Ласо в кэше
        /// </summary>
        public IDrawable CacheLasso { get; set; }
    }
}
