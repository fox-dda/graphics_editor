using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Enums;
using GraphicsEditor.DraftTools;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Художник фигур
    /// </summary>
    public class DraftPainter
    {
        /// <summary>
        /// Фасад отрисовщиков
        /// </summary>
        private DrawerFacade _drawer = new DrawerFacade();

        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        public PainterState State
        {
            get => _state;
            set => _state = value;
        }

        private PainterState _state;

        /// <summary>
        /// Ядро рисования
        /// </summary>
        public Graphics Painter
        {
            get => _painter;
            set => _painter = value;
        }

        private Graphics _painter;

        /// <summary>
        /// Менеджер хранилища
        /// </summary>
        public StorageManager Corrector
        {
            get => _corrector;
            set => _corrector = value;
        }

        private StorageManager _corrector;

        /// <summary>
        /// Параметры рисования
        /// </summary>
        public PaintingParameters Parameters
        {
            get => _paintingParameters;
            set => _paintingParameters = value;
        }

        private PaintingParameters _paintingParameters = new PaintingParameters();

        /// <summary>
        /// Ядро рисования
        /// </summary>
        /// <param name="paintCore">Ядро рисования</param>
        public DraftPainter(Graphics paintCore)
        {
            Painter = paintCore;
        }

        /// <summary>
        /// Динамическая отрисовка
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        public void DynamicDrawing(Point mousePoint)
        {
            RefreshCanvas();

            switch (State.DrawingStrategy)
            {
                case Strategy.TwoPoint:
                    DoublePointDynamicDrawing(mousePoint);
                    break;
                case Strategy.Multipoint:
                    MultiPointDynamicDrawing(mousePoint);
                    break;
                case Strategy.Selection:
                    LassoDynamicDrawing(mousePoint);
                    break;
            }
        }

        /// <summary>
        /// Динамическая отрисовка лассо
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        private void LassoDynamicDrawing(Point mousePoint)
        {
            State.CacheLasso = (HighlightRect)DraftFactory.CreateDraft(
                State.Figure,
                new List<Point>
                {
                    State.InPocessPoints[0],
                    mousePoint
                }, 
                Parameters.GPen,
                Parameters.BrushColor);
            _drawer.DrawShape(State.CacheLasso, Painter);
        }

        /// <summary>
        /// Динамическая отрисовка двуточечных фигур
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        private void DoublePointDynamicDrawing(Point mousePoint)
        {
            State.CacheDraft = DraftFactory.CreateDraft(
                State.Figure,
                new List<Point>{State.InPocessPoints[0],
                mousePoint},
                Parameters.GPen,
                Parameters.BrushColor);
            _drawer.DrawShape(State.CacheDraft, Painter);
        }

        /// <summary>
        /// Добавление точки в рисуемую фигуру
        /// </summary>
        /// <param name="clickPoint">Координаты добавляемой точки</param>
        public void AddPointToCacheDraft(Point clickPoint)
        {
            if (State.CacheDraft is IMultipoint multipoint)
            {
                multipoint.DotList.Add(clickPoint);
            }
        }

        /// <summary>
        /// Динамическое рисование мультиточечной фигуры
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        private void MultiPointDynamicDrawing(Point mousePoint)
        {
            if (State.CacheDraft == null)
            {
                State.CacheDraft = DraftFactory.CreateDraft(
                    State.Figure, 
                    new List<Point>
                    {
                        State.InPocessPoints.Last(),
                        mousePoint,
                        mousePoint
                    }, 
                    Parameters.GPen,
                    Parameters.BrushColor);
            }
            else
            {
                var cache = State.CacheDraft;
                switch (cache)
                {
                    case Polygon polygon when (State.Figure == Figure.Polygon):
                        polygon.DotList[polygon.DotList.Count - 1] = mousePoint;
                        break;
                    case Polyline polyline when (State.Figure == Figure.Polyline):
                        polyline.DotList[polyline.DotList.Count - 1] = mousePoint;
                        break;
                }
            }
            _drawer.DrawShape(State.CacheDraft, Painter);
        }

        /// <summary>
        /// Перерисовка всех объектов
        /// </summary>
        public void RefreshCanvas()
        {
            Painter.Clear(Parameters.CanvasColor);
            var drawList = Corrector.PaintedDraftStorage;

            foreach (var draft in drawList)
            {
                if (State.UndrawableDraft == draft)
                    continue;

                _drawer.DrawShape(draft, Painter);

                if (Corrector.HighlightDraftStorage.Contains(draft))
                {
                    _drawer.DrawHighlight(draft, Painter);
                }              
            }     
        }

        /// <summary>
        /// Очистить канву
        /// </summary>
        public void ClearCanvas()
        {
            Corrector.ClearStorage();
            State.CacheDraft = null;
            Painter.Clear(Color.White);
            State.InPocessPoints.Clear();
            Parameters.CanvasColor = Color.White;
        }

        /// <summary>
        /// Передать фигуру в хранилище
        /// </summary>
        public void AddToStorage()
        {
            Corrector.AddDraft(State.CacheDraft);
            State.InPocessPoints.Clear();
            RefreshCanvas();
        }

        /// <summary>
        /// Отрисовка одного объекта
        /// </summary>
        /// <param name="draft"></param>
        public void SoloDraw(IDrawable draft)
        {
            _drawer.DrawShape(draft, Painter);
            _drawer.DrawHighlight(draft, Painter);
        }
    }
}
