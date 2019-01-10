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
