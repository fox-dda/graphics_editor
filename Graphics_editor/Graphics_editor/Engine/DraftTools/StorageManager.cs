using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using GraphicsEditor.Engine.UndoRedo;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.DraftTools
{
    public class StorageManager
    {
        private DraftStorage _storage;
        private UndoRedoStack _undoRedoStack = new UndoRedoStack();

        public void ClearCommandStack()
        {
            _undoRedoStack.Reset();
        }

        public List<IDrawable> GetStorageForRepairCommands()
        {
            return _storage.DraftList;
        }

        public void DoCommand(ICommand command)
        {
            _undoRedoStack.Do(command);
        }

        public void SetUndoRedoStack(UndoRedoStack stack)
        {
            _undoRedoStack = stack;
        }

        public UndoRedoStack GetUndoRedoStack()
        {
            return _undoRedoStack;
        }

        public void RedoCommand()
        {
            _undoRedoStack.Redo();
        }

        public void UndoCommand()
        {
            _undoRedoStack.Undo();
        }

        public StorageManager(DraftStorage storage)
        {
            _storage = storage;
        }

        public List<IDrawable> GetDrafts()
        {
            return _storage.DraftList;
        }

        public List<IDrawable> GetHighlights()
        {
            return _storage.HighlightDraftsList;
        }

        public void AddDraft(IDrawable draft)
        {
            _undoRedoStack.Do(CommandFactory.CreateAddDraftCommand(_storage.DraftList, draft));
        }

        public void AddRangeDrafts(List<IDrawable> drafts)
        {
            _undoRedoStack.Do(CommandFactory.CreateAddRangeDraftCommand(_storage.DraftList, drafts));
        }

        public void AddHighlightRangeDraft(List<IDrawable> drafts)
        {
            foreach (IDrawable draft in drafts)
            {
                if (GetHighlights().Contains(draft))
                    _storage.HighlightDraftsList.Remove(draft);
                else
                    _storage.HighlightDraftsList.Add(draft);
            }
        }

        public void ClearStorage()
        {
            _undoRedoStack.Do(CommandFactory.CreateClearStorageCommand(_storage.DraftList));
            _storage.HighlightDraftsList.Clear();
        }

        public void AddHighlightDraft(IDrawable draft)
        {
            if (GetHighlights().Contains(draft))
                _storage.HighlightDraftsList.Remove(draft);
            else
                _storage.HighlightDraftsList.Add(draft);
        }

        public void DiscardAll()
        {
            _storage.HighlightDraftsList.Clear();
        }

        public void HighlightingDraftRange(List<IDrawable> highlightRange)
        {
            _storage.HighlightDraftsList.AddRange(highlightRange);
        }
        /*/
        public void EditBrushableDraft(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            _undoRedoStack.Do(CommandFactory.CreateEditBrushableDraftCommand(_storage.DraftList, draft, pointList, pen, brush));
        }
        /*/
        public void EditDraft(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            _undoRedoStack.Do(CommandFactory.CreateEditDraftCommand(_storage.DraftList, draft, pointList, pen, brush));
        }

        public void DragDotInDraft(DotInDraft dotInDraft, Point newPoint)
        {
            var item = dotInDraft.Draft;
            var point = dotInDraft.Point;      

            if (item is Polygon)
            {
                (item as Polygon).DotList[(item as Polygon).DotList.IndexOf(point)] = newPoint;
            }
            else if (item is Polyline)
            {
                (item as Polyline).DotList[(item as Polyline).DotList.IndexOf(point)] = newPoint;
            }
            else
            {
                if (item.StartPoint == point)
                {
                    item.StartPoint = newPoint;
                }
                else if (item.EndPoint == point)
                {
                    item.EndPoint = newPoint;
                }
            }
        }

        public void RemoveDraft(IDrawable draft)
        {
            if (GetHighlights().Contains(draft))
            {
                _storage.HighlightDraftsList.Remove(draft);
            }
            _undoRedoStack.Do(CommandFactory.CreateRemoveDraftCommand(_storage.DraftList, draft));
        }

        public void RemoveRangeDrafts(List<IDrawable> drafts)
        {
            foreach (IDrawable draft in drafts)
            {
                if (_storage.HighlightDraftsList.Contains(draft))
                {
                    _storage.HighlightDraftsList.Remove(draft);
                }
            }
            _undoRedoStack.Do(CommandFactory.CreateRemoveRangeDraftsCommand(_storage.DraftList, drafts));
        }

        public void RemoveRangeHighligtDrafts()
        {
            _undoRedoStack.Do(CommandFactory.CreateRemoveRangeDraftsCommand(_storage.DraftList, _storage.HighlightDraftsList));
            /*/
            foreach (IDrawable draft in GetHighlights())
            {
                if (_storage.DraftList.Contains(draft))
                {
                    _storage.HighlightDraftsList.Remove(draft);
                }               
            }
            _storage.HighlightDraftsList.Clear();
            /*/
            _storage.HighlightDraftsList.Clear();
        }
    }
}
