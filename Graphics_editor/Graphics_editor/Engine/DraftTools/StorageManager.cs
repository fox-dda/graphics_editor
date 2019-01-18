using System.Collections.Generic;
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

        public void EditDraft(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            _undoRedoStack.Do(CommandFactory.CreateEditDraftCommand(draft, pointList, pen, brush));
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
            _storage.HighlightDraftsList.Clear();
        }

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

        public List<Point> PullPoints(IDrawable item)
        {
            List<Point> pullPointList = new List<Point>();
            if (item is Polygon)
            {
                foreach (Point pointInDraft in (item as Polygon).DotList)
                {
                    pullPointList.Add(pointInDraft);
                }
            }
            else if (item is Polyline)
            {
                foreach (Point pointInDraft in (item as Polyline).DotList)
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

        public void EditCanvasColor(PaintingParameters paintingParameters, Color newColor)
        {
            _undoRedoStack.Do(CommandFactory.CreateEditCanvasColorCommand(paintingParameters, newColor));
        }

        public void ClearHistory()
        {
            _storage.DraftList.Clear();
            _storage.HighlightDraftsList.Clear();
            _undoRedoStack.Reset();
        }
    }
}
