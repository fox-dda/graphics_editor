using System.Drawing;

namespace SDK
{
    public class PenConventer
    {
        /// <summary>
        /// Создать перо
        /// </summary>
        /// <param name="settings">Настройки пера</param>
        /// <returns>Перо</returns>
        public Pen ConvertToPen(PenSettings settings)
        {
            return settings.DashPattern != null ?
                new Pen(settings.Color, settings.Width)
                {
                    DashPattern = settings.DashPattern
                } :
                new Pen(settings.Color, settings.Width);
        }
    }
}
