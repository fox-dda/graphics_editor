using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;
using GraphicsEditor.DraftTools;
using System.IO;
using GraphicsEditor.Engine.UndoRedo;
using GraphicsEditor.Engine.UndoRedo.Commands;
using SDK;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Менеджер рисования
    /// </summary>
    public class DrawManager
    {
        /// <summary>
        /// Художник фигур
        /// </summary>
        public DraftPainter DraftPainter { get; set; }

        /// <summary>
        /// Стек комманд
        /// </summary>
        public UndoRedoStack CommandStack => DraftStorageManager.UndoRedoStack;

        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        public PainterState State
        {
            get => _state;
            set => _state = value;
        }

        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        private PainterState _state;

        /// <summary>
        /// Менеджер хранилища фигур
        /// </summary>
        public StorageManager DraftStorageManager
        {
            get => _draftStorageManager;
            set => _draftStorageManager = value;
        }

        /// <summary>
        /// Менеджер хранилища
        /// </summary>
        private StorageManager _draftStorageManager;

        /// <summary>
        /// Поисковик фигур на канве
        /// </summary>
        private Selector _selector;

        /// <summary>
        /// Конструктор менеджера рисования
        /// </summary>
        /// <param name="draftPainter">Художник фигур</param>
        /// <param name="storage">Менеджер хранилища</param>
        public DrawManager(Graphics _paintCore)
        {
            DraftPainter = new DraftPainter(_paintCore);
            DraftStorageManager = new StorageManager(new DraftStorage());
            State = new PainterState();
            DraftPainter.State = State;
            DraftPainter.Corrector = DraftStorageManager;
            _selector = new Selector();
        }

        /// <summary>
        /// Обработка событий клавиш
        /// </summary>
        /// <param name="e">Событие</param>
        /// <param name="_buffer">Буфер обмена</param>
        public void KeyProcess(KeyPressEventArgs e, DraftClipboard _buffer)
        {
            switch (e.KeyChar)
            {
                //c
                case (char)3:
                    Copy(_buffer);
                    break;
                //v
                case (char)22:
                    Paste(_buffer);
                    break;
                //d
                case (char)4:
                    Remove();
                    break;
                //x
                case (char)24:
                    Cut(_buffer);
                    break;
                //z
                case (char)26:
                    Undo();
                    break;
                //y
                case (char)25:
                    Redo();
                    break;
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
                    DownMouseProcess(e);
                    break;
                }
                case MouseAction.Move:
                {
                    MoveMouseProcess(e);
                    break;
                }
                case MouseAction.Up:
                {
                    UpMouseProcess(e);
                    break;
                }
            }
        }

        private void UpMouseProcess(MouseEventArgs e)
        {
            switch (State.DrawingStrategy)
            {
                case Strategy.TwoPoint:
                    State.InProcessPoints.Add(e.Location);
                    DraftPainter.AddToStorage();
                    break;
                case Strategy.Multipoint:
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            State.InProcessPoints.Add(e.Location);
                            DraftPainter.AddPointToCacheDraft(e.Location);
                            break;
                        case MouseButtons.Right:
                            DraftPainter.AddToStorage();
                            State.Figure = State.Figure;
                            break;
                    }
                    DraftPainter.RefreshCanvas();
                    break;
                }
                case Strategy.Selection:
                    LassoSelection(e.Location);
                    State.InProcessPoints.Clear();
                    DraftPainter.RefreshCanvas();
                    break;
                case Strategy.DragAndDrop:
                {
                    if (State.DragDropDraft != null)
                    {
                        var newPoints = DraftStorageManager.PullPoints(State.DragDropDraft);
                        DraftStorageManager.EditDraft(
                            State.UndrawableDraft,
                            newPoints,
                            State.DragDropDraft.Pen,
                            State.UndrawableDraft is IBrushable
                                ? ((IBrushable) State.DragDropDraft).BrushColor
                                : Color.White);
                    }
                    if (State.DragDropDot.Draft != null)
                    {
                        var newPoints = DraftStorageManager.PullPoints(State.DragDropDot.Draft);
                        var undrawable = State.UndrawableDraft;
                        DraftStorageManager.EditDraft(
                            undrawable, newPoints, undrawable.Pen,
                            undrawable is IBrushable brushable
                                ? brushable.BrushColor
                                : Color.White);
                    }
                    State.Figure = Figure.Select;
                 //   State.DragDropDot.Draft = null;
                    State.DragDropDraft = null;
                    State.UndrawableDraft = null;
                    DraftPainter.RefreshCanvas();
                    break;
                }
            }
        }

        private void MoveMouseProcess(MouseEventArgs e)
        {
            if (State.DrawingStrategy == Strategy.DragAndDrop)
            {
                DragAndDrop(e.Location);
            }
            else
            {
                if (State.InProcessPoints.Count > 0)
                {
                    DraftPainter.DynamicDrawing(e.Location);
                }
            }
        }

        private void DownMouseProcess(MouseEventArgs e)
        {
            switch (State.DrawingStrategy)
            {
                case Strategy.TwoPoint:
                    State.InProcessPoints.Add(e.Location);
                    break;
                case Strategy.Selection:
                {
                    State.InProcessPoints.Add(e.Location);
                    if (DraftStorageManager.HighlightDraftStorage.Count > 0)
                    {// меняем стратегию если найдена опорная точка
                        var refDot = _selector.SearchReferenceDot(
                            e.Location, 
                            DraftStorageManager.HighlightDraftStorage);
                        if (refDot.Draft != null)
                        {
                            State.Figure = Figure.DragPoint;
                            State.UndrawableDraft = refDot.Draft;

                            State.DragDropDot.Draft = DraftPainter.DraftFactory.Clone(refDot.Draft);
                            State.DragDropDot.PointInDraft = _selector.SearchReferenceDot(
                                e.Location,
                                new List<IDrawable>{ State.DragDropDot.Draft }).PointInDraft;
                        }
                        else
                        {
                            var shape = _selector.PointSearch(
                                e.Location,
                                DraftStorageManager.HighlightDraftStorage);
                            if (shape != null)
                            {
                                State.Figure = Figure.DragDraft;
                                State.DragDropDraft = DraftPainter.DraftFactory.Clone(shape);
                                State.UndrawableDraft = shape;
                                State.InProcessPoints.Add(e.Location);
                                return;
                            }
                        }
                    }

                    if (State.DrawingStrategy == Strategy.Selection)
                    {
                        DotSelection(e.Location);
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
            var selectedDraft = _selector.PointSearch(
                mousePoint,
                DraftStorageManager.PaintedDraftStorage);

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
            if (State.InProcessPoints.Count > 0)
            {
                if (mousePoint != State.InProcessPoints.Last())
                {
                    DraftStorageManager.DiscardAll();
                }
            }

            if (State.CacheLasso != null)
            {
                DraftStorageManager.HighlightingDraftRange(
                    _selector.LassoSearch(
                        State.CacheLasso,
                        DraftStorageManager.PaintedDraftStorage));
                DraftPainter.RefreshCanvas();
            }
            State.CacheLasso = null;
            State.InProcessPoints.Clear();
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
            var bais = new Point(
                newPoint.X - State.InProcessPoints.Last().X,
                newPoint.Y - State.InProcessPoints.Last().Y);
            BiasObject(State.DragDropDraft, bais);
            State.InProcessPoints.Add(newPoint);
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
        /// <param name="bias">Величина сдвига по X и Y</param>
        public void BiasObject(IDrawable draft, Point bias)
        {
            if (draft is IMultipoint multipoint)
            {
                for (var i = 0; i < multipoint.DotList.Count; i++)
                {
                    multipoint.DotList[i] = new Point(
                        multipoint.DotList[i].X + bias.X,
                        multipoint.DotList[i].Y + bias.Y);
                }
            }
            else
            {
                draft.StartPoint = new Point(
                    draft.StartPoint.X + bias.X,
                    draft.StartPoint.Y + bias.Y);
                draft.EndPoint = new Point(
                    draft.EndPoint.X + bias.X,
                    draft.EndPoint.Y + bias.Y);
            }
        }

        /// <summary>
        /// Сдвинуть точку в фигуре
        /// </summary>
        /// <param name="dotInDraft">Точка в фигуре</param>
        /// <param name="newPoint">Новые координаты сдвинутой точки</param>
        public void DragDotInDraft(DotInDraft dotInDraft, Point newPoint)
        {
            var item = dotInDraft.Draft;
            var point = dotInDraft.PointInDraft;
            var editedPoint = 0;

            if (item is IMultipoint multipoint)
            {
                foreach (var pointInDraft in multipoint.DotList)
                {
                    if (point.X == pointInDraft.X && point.Y == pointInDraft.Y)
                    {
                        editedPoint = multipoint.DotList.IndexOf(pointInDraft);
                    }
                }
                multipoint.DotList[editedPoint] = newPoint;
            }
            else
            {
                if (point.X == item.StartPoint.X && point.Y == item.StartPoint.Y)
                {
                    item.StartPoint = newPoint;
                }
                else if (point.X == item.EndPoint.X && point.Y == item.EndPoint.Y)
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
            serealizer.Serialize(stream, DraftStorageManager.UndoRedoStack);
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
                switch (cmd)
                {
                    case AddDraftCommand addDraftCommand:
                        addDraftCommand.DraftList =
                            DraftStorageManager.PaintedDraftStorage;
                        continue;
                    case AddRangeDraftCommand addRangeDraftCommand:
                        addRangeDraftCommand.TargetStorage =
                            DraftStorageManager.PaintedDraftStorage;
                        continue;
                    case ClearStorageCommand clearStorageCommand:
                        clearStorageCommand.TargetStorage = 
                            DraftStorageManager.PaintedDraftStorage;
                        continue;
                    case RemoveDraftCommand removeDraftCommand:
                        removeDraftCommand.TargetStorage = 
                            DraftStorageManager.PaintedDraftStorage;
                        continue;
                    case RemoveRangeDraftsCommand removeRangeDraftsCommand:
                        removeRangeDraftsCommand.TargetStorage =
                            DraftStorageManager.PaintedDraftStorage;
                        continue;
                    case EditCanvasColorCommand editCanvasColorCommand:
                        editCanvasColorCommand.TargetPaintingParameters = 
                            DraftPainter.Parameters;
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
        /// <param name="buffer">Буфер обмена</param>
        public void Cut(DraftClipboard buffer)
        {
            buffer.SetRange(DraftStorageManager.HighlightDraftStorage);
            DraftStorageManager.RemoveRangeHighlightDrafts();
            DraftPainter.RefreshCanvas();
        }

        /// <summary>
        /// Копировать в буффер обмена
        /// </summary>
        /// <param name="buffer">Буфер обмена</param>
        public void Copy(DraftClipboard buffer)
        {
            buffer.SetRange(DraftStorageManager.HighlightDraftStorage);
            DraftPainter.RefreshCanvas();

        }

        /// <summary>
        /// Вставить в буффер обмена
        /// </summary>
        /// <param name="buffer">Буфер обмена</param>
        public void Paste(DraftClipboard buffer)
        {
            DraftStorageManager.AddRangeDrafts(buffer.GetAll());
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
