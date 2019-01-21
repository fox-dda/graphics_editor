using System.Drawing;
using GraphicsEditor.Model.Shapes;
using GraphicsEditor.Engine;

namespace GraphicsEditor.Model.Drawers
{
    /// <summary>
    /// Базовый отрисовщик фигур
    /// </summary>
    public abstract class BaseDrawer
    {
        /// <summary>
        /// Отрисовать фигуру
        /// </summary>
        /// <param name="shape">Русуемая фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public abstract void DrawShape(IDrawable shape, Graphics graphics);

        /// <summary>
        /// Конвертирование из настроке пера в перо
        /// </summary>
        /// <param name="penSettings"></param>
        /// <returns></returns>
        public Pen ConvertPen(PenSettings penSettings)
        {
            var converter = new PenConventer();
            return converter.ConvertToPen(penSettings);
        }
    }

}
