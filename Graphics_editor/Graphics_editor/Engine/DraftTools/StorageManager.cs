using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using GraphicsEditor.Engine.UndoRedo;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.DraftTools
{
    /// <summary>
    /// Менеджер хранилища
    /// </summary>
    public class StorageManager
    {
        /// <summary>
        /// Хранилище объектов
        /// </summary>
        private DraftStorage _storage;

        private CommandFactory _commandFactory = new CommandFactory();

        /// <summary>
        /// Стек команд
        /// </summary>
        private UndoRedoStack _undoRedoStack = new UndoRedoStack();

        /// <summary>
        /// Список отрисованных фигур
        /// </summary>
        /// <returns>Хранилище фигур</returns>
        public List<IDrawable> PaintedDraftStorage
        {
            get => _storage.DraftList;
            set => _storage.DraftList = value;
        }

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        public List<IDrawable> HighlightDraftStorage
        {
            get => _storage.HighlightDraftsList; 
        }

        /// <summary>
        /// Выполнить комманду
        /// </summary>
        /// <param name="command">Команда, которую нужно выполнить</param>
        public void DoCommand(ICommand command)
        {
            _undoRedoStack.Do(command);
        }

        /// <summary>
        /// Вернуть стек выполненых команд
        /// </summary>
        /// <returns>Выполненные команды</returns>
        public UndoRedoStack UndoRedoStack
        {
            get => _undoRedoStack;
            set => _undoRedoStack = value;
        }

        /// <summary>
        /// Повторить комманду (Шаг вперед)
        /// </summary>
        public void RedoCommand()
        {
            _undoRedoStack.Redo();
        }

        /// <summary>
        /// Отменить комманду (Шаг назад)
        /// </summary>
        public void UndoCommand()
        {
            _undoRedoStack.Undo();
        }
        
        /// <summary>
        /// Конструктор класса StorageManager
        /// </summary>
        /// <param name="storage">Хранилище фигур</param>
        public StorageManager(DraftStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Добавить фигуру в хранилище
        /// </summary>
        /// <param name="draft">Добавляемая фигура</param>
        public void AddDraft(IDrawable draft)
        {
            _undoRedoStack.Do(_commandFactory.CreateAddDraftCommand(_storage.DraftList, draft));
        }

        /// <summary>
        /// Добавить несколько фигур в хранилище
        /// </summary>
        /// <param name="drafts">Добавляемые фигуры</param>
        public void AddRangeDrafts(List<IDrawable> drafts)
        {
            _undoRedoStack.Do(_commandFactory.CreateAddRangeDraftCommand(_storage.DraftList, drafts));
        }

        /// <summary>
        /// Очистить хранилище фигур
        /// </summary>
        public void ClearStorage()
        {
            _undoRedoStack.Do(_commandFactory.CreateClearStorageCommand(_storage.DraftList));
            DiscardAll();
        }

        /// <summary>
        /// Изменить выдиление фигуры
        /// </summary>
        /// <param name="draft"></param>
        public void EditHighlightDraft(IDrawable draft)
        {
            if (HighlightDraftStorage.Contains(draft))
            {
                _storage.HighlightDraftsList.Remove(draft);
            }
            else
            {
                _storage.HighlightDraftsList.Add(draft);
            }
        }

        /// <summary>
        /// Очистить список выделенных фигур
        /// </summary>
        public void DiscardAll()
        {
            _storage.HighlightDraftsList.Clear();
        }
        
        /// <summary>
        /// Добавить несколько фигур в список выделенных
        /// </summary>
        /// <param name="highlightRange"></param>
        public void HighlightingDraftRange(List<IDrawable> highlightRange)
        {
            _storage.HighlightDraftsList.AddRange(highlightRange);
        }

        /// <summary>
        /// Изменить фигуру
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Новые точки</param>
        /// <param name="pen">Новое перо</param>
        /// <param name="brush">Новый цвет заливки</param>
        public void EditDraft(IDrawable draft, List<Point> pointList,
            PenSettings pen, Color brush)
        {
            _undoRedoStack.Do(_commandFactory.CreateEditDraftCommand(
                draft, pointList, pen, brush));
        }

        /// <summary>
        /// Удалить выделенные фигуры из хранилища
        /// </summary>
        public void RemoveRangeHighlightDrafts()
        {
            _undoRedoStack.Do(_commandFactory.CreateRemoveRangeDraftsCommand(_storage.DraftList, _storage.HighlightDraftsList));
            DiscardAll();
        }

        /// <summary>
        /// Получить точки из фигуры
        /// </summary>
        /// <param name="item">Фигура, из которой нужно вытащить точки</param>
        /// <returns>Точки фигуры</returns>
        public List<Point> PullPoints(IDrawable item)
        {
            var pullPointList = new List<Point>();
            if (item is IMultipoint multipoint)
            {
                foreach (var pointInDraft in multipoint.DotList)
                {
                    pullPointList.Add(pointInDraft);
                }
            }
            else
            {
                pullPointList.Add(item.StartPoint);
                pullPointList.Add(item.EndPoint);
            }

            return pullPointList;
        }

        /// <summary>
        /// Изменить цвет канвы
        /// </summary>
        /// <param name="paintingParameters">Настройки канвы, которые необходимо изменить</param>
        /// <param name="newColor">Новый цвет</param>
        public void EditCanvasColor(PaintingParameters paintingParameters, Color newColor)
        {
            _undoRedoStack.Do(_commandFactory.CreateEditCanvasColorCommand(paintingParameters, newColor));
        }

        /// <summary>
        /// Очистить историю команд и хранилище фигур для создания нового проекта
        /// </summary>
        public void ClearHistory()
        {
            _storage.DraftList.Clear();
            DiscardAll();
            _undoRedoStack.Reset();
        }
    }
}
