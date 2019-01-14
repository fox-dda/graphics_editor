using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;
using GraphicsEditor.DraftTools;
using System.IO;

namespace GraphicsEditor.Engine
{
    class DrawManager
    {
        public DraftPainter DraftPainter;
        public PainterState State;
        public StorageManager Corrector;

        public DrawManager(DraftPainter draftPainter, DraftStorage storage)
        {
            DraftPainter = draftPainter;
            Corrector = new StorageManager(storage);
            State = new PainterState();
            DraftPainter.State = State;
            DraftPainter.Corrector = Corrector;
        }

        public void KeyProcess(KeyPressEventArgs e, DraftClipboard _buffer)
        {
            if (e.KeyChar == (Char)3)//c
            {
                _buffer.SetRange(Corrector.GetHighlights());
            }
            else if (e.KeyChar == (Char)22)//v
            {
                Corrector.AddRangeDrafts(_buffer.GetAll());
            }
            else if (e.KeyChar == (Char)4)//d
            {
                Corrector.RemoveRangeHighligtDrafts();
            }
            else if (e.KeyChar == (Char)24)//x
            {
                _buffer.SetRange(Corrector.GetHighlights());
                Corrector.RemoveRangeHighligtDrafts();
            }
            else if (e.KeyChar == (Char)26)//z
            {
                Corrector.DiscardAll();
                Corrector.UndoCommand();
                DraftPainter.RefreshCanvas();
            }
            else if (e.KeyChar == (Char)25)//y
            {
                Corrector.DiscardAll();
                Corrector.RedoCommand();
                DraftPainter.RefreshCanvas();
            }
        }

        public void MouseProcess(MouseEventArgs e, MouseAction mouseAction)
        {
            switch (mouseAction)
            {
                case MouseAction.down:
                    {
                        if (State.DrawingStrategy == Strategy.twoPoint)
                        {
                            State.InPocessPoints.Add(e.Location);
                        }
                        else if (State.DrawingStrategy == Strategy.selection)
                        {
                            State.InPocessPoints.Add(e.Location);
                            if (Corrector.GetHighlights().Count > 0)
                            {// меняем стратегию если найдена опорная точка или точка опоры
                                var refDot = Selector.SearchReferenceDot(e.Location, Corrector.GetHighlights());
                                if (refDot.Draft != null)
                                {
                                    State.Figure = Figure.dragPoint;
                                    State.DragDropDot = refDot;
                                }
                                else
                                {
                                    //var gravitySector = Selector.PointSearch(e.Location, Corrector.GetHighlights());
                                    var shape = Selector.PointSearch(e.Location, Corrector.GetHighlights());
                                    if (shape != null)
                                    {
                                        State.Figure = Figure.dragDraft;
                                        State.DragDropDraft = shape;
                                        State.InPocessPoints.Add(e.Location);
                                        return;
                                    }
                                }
                            }
                            if (State.DrawingStrategy == Strategy.selection)
                                DotSelection(e.Location);
                        }
                        break;
                    }
                case MouseAction.move:
                    {
                     //   DraftPainter.RefreshCanvas();

                        if (State.DrawingStrategy == Strategy.dragAndDrop)
                        {
                            DragAndDrop(e.Location);
                        }
                        else
                        {
                            if (State.InPocessPoints.Count > 0)
                            {
                                DraftPainter.DynamicDrawing(e.Location);
                            }
                        }
                        break;
                    }
                case MouseAction.up:
                    {
                        if (State.DrawingStrategy == Strategy.twoPoint)
                        {
                            State.InPocessPoints.Add(e.Location);
                            DraftPainter.AddToStorage();
                        }
                        else if (State.DrawingStrategy == Strategy.multipoint)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                State.InPocessPoints.Add(e.Location);
                                DraftPainter.AddPointToCacheDraft(e.Location);
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                DraftPainter.AddToStorage();
                                State.Figure = State.Figure;
                            }
                            DraftPainter.RefreshCanvas();
                        }
                        else if (State.DrawingStrategy == Strategy.selection)
                        {
                            LassoSelection(e.Location);
                            State.InPocessPoints.Clear();
                            DraftPainter.RefreshCanvas();
                        }
                        else if (State.DrawingStrategy == Strategy.dragAndDrop)
                        {
                            if (State.DragDropDraft != null)
                            {
                                Corrector.AddDraft(State.DragDropDraft);
                                Corrector.AddHighlightDraft(State.DragDropDraft);                   
                            }
                            State.Figure = Figure.select;
                            State.DragDropDot.Draft = null;
                            State.DragDropDraft = null;
                            DraftPainter.RefreshCanvas();
                        }
                        break;
                    }
            }
        }

        private void DotSelection(Point mousePoint)
        {
            Corrector.DiscardAll();
            var selectedDraft = Selector.PointSearch(mousePoint, Corrector.GetDrafts());
            if (selectedDraft != null)
            {
                Corrector.AddHighlightDraft(selectedDraft);
            }
        }

        private void LassoSelection(Point mousePoint)
        {
            if (mousePoint != State.InPocessPoints.Last())
                Corrector.DiscardAll();

            if (State.CacheLasso != null)
            {
                Corrector.HighlightingDraftRange(Selector.LassoSearch(State.CacheLasso, Corrector.GetDrafts()));
                DraftPainter.RefreshCanvas();
            }
            State.CacheLasso = null;
            State.InPocessPoints.Clear();
        }

        //Логика распределеня ответственности перетаскивания
        private void DragAndDrop(Point newPoint)
        {
            if (State.DragDropDot.Draft != null)
            {
                DragDot(newPoint);
            }

            if (State.DragDropDraft != null)
            {
                DragDraft(newPoint);
            }
        }

        private void DragDraft(Point newPoint)
        {
            var bais = new Point(newPoint.X - State.InPocessPoints.Last().X, newPoint.Y - State.InPocessPoints.Last().Y);
            Corrector.RemoveDraft(State.DragDropDraft);
            DraftFactory.BaisObject(State.DragDropDraft, bais);
            State.InPocessPoints.Add(newPoint);
            DraftPainter.RefreshCanvas();
            DraftPainter.SoloDraw(State.DragDropDraft);
        }

        //Перетащить точку в рисунке
        private void DragDot(Point newPoint)
        {
            Corrector.DragDotInDraft(State.DragDropDot, newPoint);
            State.DragDropDot.Point = newPoint;

            DraftPainter.RefreshCanvas();
        }

        public void Serealize(Stream stream)
        {
            var serealizer = new DraftSerealizer();
            serealizer.Serialize(stream, Corrector.GetUndoRedoStack());
        }

        public void Deserialize(Stream stream)
        {
            Corrector.ClearStorage();
            var serealizer = new DraftSerealizer();
            serealizer.Deserialize(stream, Corrector.GetUndoRedoStack());
            DraftPainter.RefreshCanvas();
        }
    }
}
