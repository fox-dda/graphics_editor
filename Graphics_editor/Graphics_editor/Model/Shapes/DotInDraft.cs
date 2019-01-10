using System.Drawing;

namespace GraphicsEditor.Model
{
    public struct DotInDraft
    {
        public IDrawable Draft;
        public Point Point;

        public void Set(IDrawable draft, Point point)
        {
            Draft = draft;
            Point = point;
        }
    }
}
