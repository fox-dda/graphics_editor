using System.Drawing;

namespace SDK
{
    /// <summary>
    /// Интерфейс для закрашиваемых фигур
    /// </summary>
    public interface IBrushable
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        Color BrushColor { get; set; }
    }
}
