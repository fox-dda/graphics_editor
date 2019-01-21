using System.Collections.Generic;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    /// <summary>
    /// Буфер обмена
    /// </summary>
    public class DraftClipboard
    {
        /// <summary>
        /// Хранилище объектов буфера обена
        /// </summary>
        private List<IDrawable> _clipboard = new List<IDrawable>();

        /// <summary>
        /// Фабрика фигур для клонирования
        /// </summary>
        private DraftFactory factory = new DraftFactory();

        /// <summary>
        /// Записать в буфер ряд объектов
        /// </summary>
        /// <param name="items">Записываемые объекты</param>
        public void SetRange(List<IDrawable> items)
        {
            _clipboard.Clear();
            foreach(var item in items)
            {
                _clipboard.Add(factory.Clone(item));
            }
        }

        /// <summary>
        /// Вернуть из буфера ряд объектов
        /// </summary>
        /// <returns></returns>
        public List<IDrawable> GetAll()
        {
            var returnList = new List<IDrawable>();

            foreach (var item in _clipboard)
            {
               returnList.Add(factory.Clone(item));
            }
            return returnList;
        }
    }
}