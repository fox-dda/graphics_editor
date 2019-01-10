using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;
using System.Windows.Forms;

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
            if(GetDrafts().Contains(draft))
            {
                _storage.DraftList.Remove(draft);
            }
            if (GetHighlights().Contains(draft))
            {
                _storage.HighlightDraftsList.Remove(draft);
            }
        }
    }
}
