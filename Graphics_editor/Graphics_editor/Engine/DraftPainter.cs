using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Enums;
using GraphicsEditor.DraftTools;

namespace GraphicsEditor.Engine
{
    class DraftPainter
    {
        private DrawerFacade _drawer = new DrawerFacade();

        public PainterState State;

        public Graphics Painter;

        public StorageManager Corrector;

        public PaintingParameters Parameters = new PaintingParameters();
        
        public DraftPainter(Graphics paintCore)
        {
            Painter = paintCore;
        }

        //Динамическое рисование
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

        //Логика динамичечкой отрисовки ласо, и захвата объектов в ласо
        private void LassoDynamicDrawing(Point mousePoint)
        {
            State.CacheLasso = DraftFactory.CreateDraft(State.Figure, State.InPocessPoints[0], mousePoint);
            _drawer.DrawShape(State.CacheLasso, Painter);
        }

        //Логика динамического рисования по двум точкам
        private void DoublePointDynamicDrawing(Point mousePoint)
        {
            State.CacheDraft = DraftFactory.CreateDraft(State.Figure, State.InPocessPoints[0], mousePoint, Parameters.GPen, Parameters.BrushColor);
            _drawer.DrawShape(State.CacheDraft, Painter);
        }

        //Логика добавления точки в фигру
        public void AddPointToCacheDraft(Point clickPoint)
        {
            if ((State.CacheDraft is Polygon) && (State.Figure == Figure.polygon))
                (State.CacheDraft as Polygon).DotList.Add(clickPoint);
            if ((State.CacheDraft is Polyline) && (State.Figure == Figure.polyline))
                (State.CacheDraft as Polyline).DotList.Add(clickPoint);
        }

        //Логика мультиточечного динамического рисования
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

        //Обновить канву
        public void RefreshCanvas()
        {
            Painter.Clear(Parameters.CanvasColor);

            var drawList = Corrector.GetDrafts();

            foreach (IDrawable draft in drawList)
            {
                if (draft != null)
                {
                    _drawer.DrawShape(draft, Painter);
                }
            }

            var highlightList = Corrector.GetHighlights();

            foreach (IDrawable draft in highlightList)
            {
                if (draft != null)
                {
                    _drawer.DrawHighlight(draft, Painter);
                }
            }       
        }

        //Задать цвет канвы
        public void SetCanvasColor(Color color)
        {
            Parameters.CanvasColor = color;
            Painter.Clear(color);
            RefreshCanvas();
        }

        public void ClearCanvas()
        {
            Corrector.ClearStorage();
            State.CacheDraft = null;
            Painter.Clear(Parameters.CanvasColor);
            State.InPocessPoints.Clear();
            Parameters.CanvasColor = Color.White;
        }

        public void AddToStorage()
        {
            Corrector.AddDraft(State.CacheDraft);
            State.InPocessPoints.Clear();
            RefreshCanvas();
        }
    }
}
