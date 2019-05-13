using System.Drawing;


namespace SDK
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
        /// <param name="penSettings">Настройки пера</param>
        /// <returns>Перо</returns>
        public Pen ConvertPen(PenSettings penSettings)
        {
            var converter = new PenConventer();
            return converter.ConvertToPen(penSettings);
        }
    }

}
