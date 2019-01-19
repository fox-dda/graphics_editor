using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;
using GraphicsEditor.DraftTools;
using System.IO;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Менеджер рисования
    /// </summary>
    class DrawManager
    {
        /// <summary>
        /// Художник фигур
        /// </summary>
        public DraftPainter DraftPainter;
        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        public PainterState State;
        /// <summary>
        /// Менеджер хранилища фигур
        /// </summary>
        public StorageManager DraftStorageManager;

        /// <summary>
        /// Конструктор менеджера рисования
        /// </summary>
        /// <param name="draftPainter">Художник фигур</param>
        /// <param name="storage">Менеджер хранилища</param>
        public DrawManager(DraftPainter draftPainter, DraftStorage storage)
        {
            DraftPainter = draftPainter;
            DraftStorageManager = new StorageManager(storage);
            State = new PainterState();
            DraftPainter.State = State;
            DraftPainter.Corrector = DraftStorageManager;
        }

        /// <summary>
        /// Обработка событий клавиш
        /// </summary>
        /// <param name="e">Событие</param>
        /// <param name="_buffer">Буфер обмена</param>
        public void KeyProcess(KeyPressEventArgs e, DraftClipboard _buffer)
        {
            if (e.KeyChar == (Char)3)//c
            {
                Copy(_buffer);
            }
            else if (e.KeyChar == (Char)22)//v
            {
                Paste(_buffer);
            }
            else if (e.KeyChar == (Char)4)//d
            {
                Remove();
            }
            else if (e.KeyChar == (Char)24)//x
            {
                Cut(_buffer);
            }
            else if (e.KeyChar == (Char)26)//z
            {
                Undo();
            }
            else if (e.KeyChar == (Char)25)//y
            {
                Redo();
            }
        }

        /// <summary>
        /// Обработка событий мыши
        /// </summary>
        /// <param name="e">Событие</param>
        /// <param name="mouseAction">Параметры события</param>
        public void MouseProcess(MouseEventArgs e, MouseAction mouseAction)
        {
            switch (mouseAction)
            {
                case MouseAction.Down:
                    {
                        if (State.DrawingStrategy == Strategy.TwoPoint)
                        {
                            State.InPocessPoints.Add(e.Location);
                        }
                        else if (State.DrawingStrategy == Strategy.Selection)
                        {
                            State.InPocessPoints.Add(e.Location);
                            if (DraftStorageManager.HighlightDraftStorage.Count > 0)
                            {// меняем стратегию если найдена опорная точка
                                var refDot = Selector.SearchReferenceDot(e.Location, DraftStorageManager.HighlightDraftStorage);
                                if (refDot.Draft != null)
                                {
                                    State.Figure = Figure.DragPoint;
                                    State.UndrawableDraft = refDot.Draft;

                                    State.DragDropDot.Draft = DraftFactory.Clone(refDot.Draft);
                                    State.DragDropDot.PointInDraft = Selector.SearchReferenceDot(e.Location, new List<IDrawable>()
                                    { State.DragDropDot.Draft }).PointInDraft;
                                }
                                else
                                {
                                    var shape = Selector.PointSearch(e.Location, DraftStorageManager.HighlightDraftStorage);
                                    if (shape != null)
                                    {
                                        State.Figure = Figure.DragDraft;
                                        State.DragDropDraft = DraftFactory.Clone(shape);
                                        State.UndrawableDraft = shape;
                                        State.InPocessPoints.Add(e.Location);
                                        return;
                                    }
                                }
                            }
                            if (State.DrawingStrategy == Strategy.Selection)
                                DotSelection(e.Location);
                        }
                        break;
                    }
                case MouseAction.Move:
                    {
                        if (State.DrawingStrategy == Strategy.DragAndDrop)
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
                case MouseAction.Up:
                    {
                        if (State.DrawingStrategy == Strategy.TwoPoint)
                        {
                            State.InPocessPoints.Add(e.Location);
                            DraftPainter.AddToStorage();
                        }
                        else if (State.DrawingStrategy == Strategy.Multipoint)
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
                        else if (State.DrawingStrategy == Strategy.Selection)
                        {
                            LassoSelection(e.Location);
                            State.InPocessPoints.Clear();
                            DraftPainter.RefreshCanvas();
                        }
                        else if (State.DrawingStrategy == Strategy.DragAndDrop)
                        {
                            if (State.DragDropDraft != null)
                            {
                                var newPoints = DraftStorageManager.PullPoints(State.DragDropDraft);
                                if (State.UndrawableDraft is IBrushable)
                                    DraftStorageManager.EditDraft(State.UndrawableDraft, newPoints, State.DragDropDraft.Pen, (State.DragDropDraft as IBrushable).BrushColor);
                                else
                                    DraftStorageManager.EditDraft(State.UndrawableDraft, newPoints, State.DragDropDraft.Pen, Color.White);                   
                            }
                            if (State.DragDropDot.Draft != null)
                            {
                                var newPoints = DraftStorageManager.PullPoints(State.DragDropDot.Draft);
                                if (State.UndrawableDraft is IBrushable)
                                    DraftStorageManager.EditDraft(State.UndrawableDraft, newPoints, State.UndrawableDraft.Pen, (State.UndrawableDraft as IBrushable).BrushColor);
                                else
                                    DraftStorageManager.EditDraft(State.UndrawableDraft, newPoints, State.UndrawableDraft.Pen, Color.White);
                            }
                            State.Figure = Figure.Select;
                            State.DragDropDot.Draft = null;
                            State.DragDropDraft = null;
                            State.UndrawableDraft = null;
                            DraftPainter.RefreshCanvas();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Измененить цвет фона
        /// </summary>
        /// <param name="newColor">Новый цвет фона</param>
        public void EditCanvasColor(Color newColor)
        {
            DraftStorageManager.EditCanvasColor(DraftPainter.Parameters, newColor);
            DraftPainter.RefreshCanvas();
        }

        /// <summary>
        /// Точечное выделение объекта
        /// </summary>
        /// <param name="mousePoint"></param>
        private void DotSelection(Point mousePoint)
        {
            DraftStorageManager.DiscardAll();
            var selectedDraft = Selector.PointSearch(mousePoint, DraftStorageManager.GetDrafts());
            if (selectedDraft != null)
            {
                DraftStorageManager.EditHighlightDraft(selectedDraft);
            }
        }

        /// <summary>
        /// Выделение объекта с помощью лассо
        /// </summary>
        /// <param name="mousePoint"></param>
        private void LassoSelection(Point mousePoint)
        {
            if (State.InPocessPoints.Count > 0)
                if (mousePoint != State.InPocessPoints.Last())
                    DraftStorageManager.DiscardAll();

            if (State.CacheLasso != null)
            {
                DraftStorageManager.HighlightingDraftRange(Selector.LassoSearch(State.CacheLasso, DraftStorageManager.GetDrafts()));
                DraftPainter.RefreshCanvas();
            }
            State.CacheLasso = null;
            State.InPocessPoints.Clear();
        }

        /// <summary>
        /// Установление ответственности за перетаскивание
        /// </summary>
        /// <param name="newPoint">Координаты мыши</param>
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

        /// <summary>
        /// Перетащить фигуру
        /// </summary>
        /// <param name="newPoint">Координаты мыши</param>
        private void DragDraft(Point newPoint)
        {
            var bais = new Point(newPoint.X - State.InPocessPoints.Last().X, newPoint.Y - State.InPocessPoints.Last().Y);
            BaisObject(State.DragDropDraft, bais);
            State.InPocessPoints.Add(newPoint);
            DraftPainter.RefreshCanvas();
            DraftPainter.SoloDraw(State.DragDropDraft);
        }

        /// <summary>
        /// Перетащить точку в фигурк
        /// </summary>
        /// <param name="newPoint">Координая мыши</param>
        private void DragDot(Point newPoint)
        {         
            DragDotInDraft(State.DragDropDot, newPoint);
            State.DragDropDot.PointInDraft = newPoint;
            DraftPainter.RefreshCanvas();
            DraftPainter.SoloDraw(State.DragDropDot.Draft);
        }

        /// <summary>
        /// Сдвинуть объект
        /// </summary>
        /// <param name="draft">Сдвигаемый объект</param>
        /// <param name="bais">Величина сдвига по X и Y</param>
        public void BaisObject(IDrawable draft, Point bais)
        {
            if (draft is Polygon)
            {
                for (int i = 0; i < (draft as Polygon).DotList.Count; i++)
                {
                    (draft as Polygon).DotList[i] = new Point((draft as Polygon).DotList[i].X + bais.X,
                        (draft as Polygon).DotList[i].Y + +bais.Y);
                }
            }
            else if (draft is Polyline)
            {
                for (int i = 0; i < (draft as Polyline).DotList.Count; i++)
                {
                    (draft as Polyline).DotList[i] = new Point((draft as Polyline).DotList[i].X + bais.X,
                        (draft as Polyline).DotList[i].Y + +bais.Y);
                }
            }
            else
            {
                draft.StartPoint = new Point(draft.StartPoint.X + bais.X, draft.StartPoint.Y + bais.Y);
                draft.EndPoint = new Point(draft.EndPoint.X + bais.X, draft.EndPoint.Y + bais.Y);
            }
        }

        /// <summary>
        /// Сдвинуть точку в фигурк
        /// </summary>
        /// <param name="dotInDraft">Точка в фигуре</param>
        /// <param name="newPoint">Новые координаты сдвинутой точки</param>
        public void DragDotInDraft(DotInDraft dotInDraft, Point newPoint)
        {
            var item = dotInDraft.Draft;
            var point = dotInDraft.PointInDraft;
            int editedPoint = 0;

            if (item is Polygon)
            {
                foreach (Point pointInDraft in (item as Polygon).DotList)
                {
                    if ((point.X == pointInDraft.X) && ((point.Y == pointInDraft.Y)))
                    {
                        editedPoint = (item as Polygon).DotList.IndexOf(pointInDraft);
                    }
                }
                (item as Polygon).DotList[editedPoint] = newPoint;
            }
            else if (item is Polyline)
            {
                foreach (Point pointInDraft in (item as Polyline).DotList)
                {
                    editedPoint = (item as Polyline).DotList.IndexOf(pointInDraft);
                }
                (item as Polyline).DotList[editedPoint] = newPoint;
            }
            else
            {
                if ((point.X == item.StartPoint.X) && ((point.Y == item.StartPoint.Y)))
                {
                    item.StartPoint = newPoint;
                }
                else if ((point.X == item.EndPoint.X) && ((point.Y == item.EndPoint.Y)))
                {
                    item.EndPoint = newPoint;
                }
            }
        }

        /// <summary>
        /// Сериализовать проект
        /// </summary>
        /// <param name="stream">Поток</param>
        public void Serealize(Stream stream)
        {
            var serealizer = new DraftSerealizer();
            serealizer.Serialize(stream, DraftStorageManager.GetUndoRedoStack);
        }

        /// <summary>
        /// Десериализовать проект
        /// </summary>
        /// <param name="stream">Поток</param>
        public void Deserialize(Stream stream)
        {
            DraftStorageManager.ClearStorage();
            var serializer = new DraftSerealizer();
            var stack = serializer.Deserialize(stream).UndoStack.ToArray();
            RepairCommands(stack);
            foreach (ICommand cmd in stack.ToArray().Reverse())
            {
                DraftStorageManager.DoCommand(cmd);
            }
            DraftPainter.RefreshCanvas();
        }

        /// <summary>
        /// Актуализировать комманды, работающие по ссылкам при десериализации проекта
        /// </summary>
        /// <param name="commands">Массив комманд</param>
        private void RepairCommands(ICommand[] commands)
        {
            foreach (var cmd in commands)
            {
                if (cmd is AddDraftCommand addDraftCommand)
                {
                    addDraftCommand.DraftList = DraftStorageManager.PaintedDraftStorage;
                    continue;
                }
                else if (cmd is AddRangeDraftCommand addRangeDraftCommand)
                {
                    addRangeDraftCommand.TargetStorage = DraftStorageManager.PaintedDraftStorage;
                    continue;
                }
                if (cmd is ClearStorageCommand clearStorageCommand)
                {
                    clearStorageCommand.TargetStorage = DraftStorageManager.PaintedDraftStorage;
                    continue;
                }
                if (cmd is RemoveDraftCommand removeDraftCommand)
                {
                    removeDraftCommand.TargetStorage = DraftStorageManager.PaintedDraftStorage;
                    continue;
                }
                if (cmd is RemoveRangeDraftsCommand removeRangeDraftsCommand)
                {
                    removeRangeDraftsCommand.TargetStorage = DraftStorageManager.PaintedDraftStorage;
                    continue;
                }
                if (cmd is EditCanvasColorCommand editCanvasColorCommand)
                {
                    editCanvasColorCommand.TargetPaintingParameters = DraftPainter.Parameters;
                    continue;
                }
            }
        }

        /// <summary>
        /// Повторить последнее действие
        /// </summary>
        public void Redo()
        {
            DraftStorageManager.DiscardAll();
            DraftStorageManager.RedoCommand();
            DraftPainter.RefreshCanvas();
        }

        /// <summary>
        /// Отменить последнее действие
        /// </summary>
        public void Undo()
        {
            DraftStorageManager.DiscardAll();
            DraftStorageManager.UndoCommand();
            DraftPainter.RefreshCanvas();
        }

        /// <summary>
        /// Вырезать объект
        /// </summary>
        /// <param name="_buffer">Буфер обмена</param>
        public void Cut(DraftClipboard _buffer)
        {
            _buffer.SetRange(DraftStorageManager.HighlightDraftStorage);
            DraftStorageManager.RemoveRangeHighlightDrafts();
            DraftPainter.RefreshCanvas();

        }

        /// <summary>
        /// Копировать в буффер обмена
        /// </summary>
        /// <param name="_buffer">Буфер обмена</param>
        public void Copy(DraftClipboard _buffer)
        {
            _buffer.SetRange(DraftStorageManager.HighlightDraftStorage);
            DraftPainter.RefreshCanvas();

        }

        /// <summary>
        /// Вставить в буффер обмена
        /// </summary>
        /// <param name="_buffer">Буфер обмена</param>
        public void Paste(DraftClipboard _buffer)
        {
            DraftStorageManager.AddRangeDrafts(_buffer.GetAll());
            DraftPainter.RefreshCanvas();

        }

        /// <summary>
        /// Удалить объект
        /// </summary>
        public void Remove()
        {
            DraftStorageManager.RemoveRangeHighlightDrafts();
            DraftPainter.RefreshCanvas();
        }

        /// <summary>
        /// Создать новый проект
        /// </summary>
        public void CreateNewProject()
        {
            DraftStorageManager.ClearHistory();
            DraftPainter.RefreshCanvas();
        }
    }
}
