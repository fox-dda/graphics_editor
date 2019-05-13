using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IDraftClipboard
    {
        /// <summary>
        /// Записать в буфер ряд объектов
        /// </summary>
        /// <param name="items">Записываемые объекты</param>
        void SetRange(IList<IDrawable> items);

        /// <summary>
        /// Вернуть из буфера ряд объектов
        /// </summary>
        /// <returns></returns>
        IList<IDrawable> GetAll();
    }
}
