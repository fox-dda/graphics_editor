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

        public Pen ConvertPen(PenSettings penSettings)
        {
            var penFactory = new PenFactory();
            return penFactory.CreatePen(penSettings);
        }
    }

}
