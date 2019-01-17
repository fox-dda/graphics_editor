using System.Drawing;

namespace GraphicsEditor.Model
{
    public struct DotInDraft
    {
        public IDrawable Draft;
        public Point PointInDraft;

        public void Set(IDrawable draft, Point point)
        {
            Draft = draft;
            PointInDraft = point;
        }
    }
}
