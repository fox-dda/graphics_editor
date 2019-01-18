using System.Drawing;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Точка, которой соответствует содержащая её фигура
    /// </summary>
    public struct DotInDraft
    {
        /// <summary>
        /// Фигура
        /// </summary>
        public IDrawable Draft;
        /// <summary>
        /// Точка в фигуре
        /// </summary>
        public Point PointInDraft;

        /// <summary>
        /// Изменить параметы
        /// </summary>
        /// <param name="draft">Фигура</param>
        /// <param name="point">Точка</param>
        public void Set(IDrawable draft, Point point)
        {
            Draft = draft;
            PointInDraft = point;
        }
    }
}
