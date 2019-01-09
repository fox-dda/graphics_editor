using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;

namespace GraphicsEditor.DraftTools
{
    public class StorageManager
    {
        private DraftStorage _storage;

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
            _storage.DraftList.Add(draft);
        }

        public void ClearStorage()
        {
            _storage.DraftList.Clear();
            _storage.HighlightDraftsList.Clear();
        }

        public void AddHighlightDraft(IDrawable draft)
        {
            foreach (HighlightRect frame in _storage.HighlightDraftsList)
            {
                if (draft == frame.LightItem)
                {
                    _storage.HighlightDraftsList.Remove(frame);
                    return;
                }
            }

            _storage.HighlightDraftsList.Add(DraftFactory.CreateDraft(Enums.Figure.select, draft));
        }

        public void DiscardAll()
        {
            _storage.HighlightDraftsList.Clear();
        }

        public void HighlightingDraftRange(List<IDrawable> highlightRange)
        {
            foreach(IDrawable frame in highlightRange)
                _storage.HighlightDraftsList.Add(DraftFactory.CreateDraft(Enums.Figure.select, frame));
        }

        public void EditHighlightDraft(IDrawable draft, Point sp, Point ep, Pen pen, Color brush)
        {
            EditHighlightDraft(draft, sp, ep, pen);
            (draft as IBrushable).BrushColor = brush;
        }

        public void EditHighlightDraft(IDrawable draft, Point sp, Point ep, Pen pen)
        {
            draft.StartPoint = sp;
            draft.EndPoint = ep;
            draft.Pen = pen;
        }

        public void EditRangeHighlightDrafts(Point sp, Point ep, Pen pen, Color color)
        {

        }
    }
}
