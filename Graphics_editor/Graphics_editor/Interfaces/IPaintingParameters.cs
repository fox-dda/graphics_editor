using System.Drawing;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IPaintingParameters
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        Color BrushColor{get; set;}

        /// <summary>
        /// Паттерн штрихов
        /// </summary>
        float[] DashPattern {get; set;}

        /// <summary>
        /// Настройки пера
        /// </summary>
        PenSettings GPen {get; set;}

        /// <summary>
        /// Цвет фона
        /// </summary>
        Color CanvasColor { get; set; }
    }
}
