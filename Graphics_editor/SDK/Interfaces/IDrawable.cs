using SDK.Interfaces;
using System.Drawing;


namespace SDK
{
    /// <summary>
    /// Интерфейс рисуемых фигур
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Настройки пера
        /// </summary>
        IPenSettings Pen { get; set; }

        /// <summary>
        /// Точка старта
        /// </summary>
        Point StartPoint { get; set; }

        /// <summary>
        /// Точка конца
        /// </summary>
        Point EndPoint { get; set; }
    }
}
