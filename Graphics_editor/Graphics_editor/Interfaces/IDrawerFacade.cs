using SDK;
using System.Drawing;

namespace GraphicsEditor.Interfaces
{
    public interface IDrawerFacade
    {
        /// <summary>
        /// Отрисовать фигуру
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        void DrawShape(IDrawable shape, Graphics graphics);

        /// <summary>
        /// Отрисовать выделение
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        void DrawHighlight(IDrawable shape, Graphics graphics);
    }
}
