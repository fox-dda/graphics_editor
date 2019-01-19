using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Enums;
using GraphicsEditor.DraftTools;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Художник фигур
    /// </summary>
    class DraftPainter
    {
        /// <summary>
        /// Фасад отрисовщиков
        /// </summary>
        private DrawerFacade _drawer = new DrawerFacade();
        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        public PainterState State;
        /// <summary>
        /// Ядро рисования
        /// </summary>
        public Graphics Painter;
        /// <summary>
        /// Менеджер хранилища
        /// </summary>
        public StorageManager Corrector;
        /// <summary>
        /// Параметры рисования
        /// </summary>
        public PaintingParameters Parameters = new PaintingParameters();
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

            if (State.DrawingStrategy == Strategy.twoPoint)
                DoublePointDynamicDrawing(mousePoint);

            else if (State.DrawingStrategy == Strategy.multipoint)
            {
                MultiPointDynamicDrawing(mousePoint);
            }
            else if (State.DrawingStrategy == Strategy.selection)
            {
                LassoDynamicDrawing(mousePoint);
            }
        }

        /// <summary>
        /// Динамическая отрисовка лассо
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        private void LassoDynamicDrawing(Point mousePoint)
        {
            State.CacheLasso = DraftFactory.CreateDraft(State.Figure, State.InPocessPoints[0], mousePoint);
            _drawer.DrawShape(State.CacheLasso, Painter);
        }

        /// <summary>
        /// Динамическая отрисовка двуточечных фигур
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        private void DoublePointDynamicDrawing(Point mousePoint)
        {
            State.CacheDraft = DraftFactory.CreateDraft(State.Figure, State.InPocessPoints[0], mousePoint, Parameters.GPen, Parameters.BrushColor);
            _drawer.DrawShape(State.CacheDraft, Painter);
        }

        /// <summary>
        /// Добавление точки в рисуемую фигуру
        /// </summary>
        /// <param name="clickPoint">Координаты добавляемой точки</param>
        public void AddPointToCacheDraft(Point clickPoint)
        {
            if ((State.CacheDraft is Polygon) && (State.Figure == Figure.polygon))
                (State.CacheDraft as Polygon).DotList.Add(clickPoint);
            if ((State.CacheDraft is Polyline) && (State.Figure == Figure.polyline))
                (State.CacheDraft as Polyline).DotList.Add(clickPoint);
        }

        /// <summary>
        /// Динамическое рисование мультиточечной фигуры
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        private void MultiPointDynamicDrawing(Point mousePoint)
        {
            if (State.CacheDraft == null)
            {
                State.CacheDraft = DraftFactory.CreateDraft(State.Figure, new List<Point> {State.InPocessPoints.Last(), mousePoint, mousePoint }, Parameters.GPen, Parameters.BrushColor);
            }
            else
            {

                if ((State.CacheDraft is Polygon) && (State.Figure == Figure.polygon))
                {
                    (State.CacheDraft as Polygon).DotList[(State.CacheDraft as Polygon).DotList.Count - 1] = mousePoint;
                }
                if ((State.CacheDraft is Polyline) && (State.Figure == Figure.polyline))
                {
                    (State.CacheDraft as Polyline).DotList[(State.CacheDraft as Polyline).DotList.Count - 1] = mousePoint;
                     
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

            var drawList = Corrector.GetDrafts();

            foreach (IDrawable draft in drawList)
            {
                if (State.UndrawableDraft == draft)
                    continue;

                if (draft != null)
                {
                    _drawer.DrawShape(draft, Painter);
                }
            }

            var highlightList = Corrector.HighlightDraftStorage;

            foreach (IDrawable draft in highlightList)
            {
                if (State.UndrawableDraft == draft)
                    continue;

                if (draft != null)
                {
                    _drawer.DrawHighlight(draft, Painter);
                }
            }       
        }

        /// <summary>
        /// Сменить цвет фона
        /// </summary>
        /// <param name="color">Новый цвет</param>
        public void SetCanvasColor(Color color)
        {
            Parameters.CanvasColor = color;
            Painter.Clear(color);
            RefreshCanvas();
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
