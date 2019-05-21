using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Enums;
using GraphicsEditor.DraftTools;
using SDK.Interfaces;
using SDK;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Художник фигур
    /// </summary>
    public class DraftPainter : IDraftPainter
    {
        /// <summary>
        /// Фасад отрисовщиков
        /// </summary>
        private IDrawerFacade _drawer;

        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        public IPainterState State { get; set; }

        /// <summary>
        /// Ядро рисования
        /// </summary>
        public Graphics Painter { get; set; }

        /// <summary>
        /// Фабрика фигур
        /// </summary>
        public IDraftFactory DraftFactory { get; set; }

        /// <summary>
        /// Менеджер хранилища
        /// </summary>
        public IStorageManager Corrector { get; set; }

        /// <summary>
        /// Параметры рисования
        /// </summary>
        public IPaintingParameters Parameters { get; set; }

        /// <summary>
        /// Ядро рисования
        /// </summary>
        /// <param name="paintCore">Ядро рисования</param>
        public DraftPainter(Graphics paintCore,
            IPaintingParameters paintinParameters, 
            IStorageManager storageManager,
            IDraftFactory draftFactory,
            IDrawerFacade drawer)
        {
            Painter = paintCore;
            Parameters = paintinParameters;
            Corrector = storageManager;
            DraftFactory = draftFactory;
            _drawer = drawer;
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
                    State.InProcessPoints[0],
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
                new List<Point>{State.InProcessPoints[0],
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
                        State.InProcessPoints.Last(),
                        mousePoint,
                        mousePoint
                    }, 
                    Parameters.GPen,
                    Parameters.BrushColor);
            }
            else
            {
                IMultipoint multipoint = State.CacheDraft as IMultipoint;
                multipoint.DotList[multipoint.DotList.Count - 1] = mousePoint;
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
            Parameters.CanvasColor = Color.White;
            Painter.Clear(Color.White);
            State.InProcessPoints.Clear();
            
        }

        /// <summary>
        /// Передать фигуру в хранилище
        /// </summary>
        public void AddToStorage()
        {
            Corrector.AddDraft(State.CacheDraft);
            State.InProcessPoints.Clear();
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
