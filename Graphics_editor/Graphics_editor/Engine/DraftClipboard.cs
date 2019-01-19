using System.Collections.Generic;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    /// <summary>
    /// Буфер обмена
    /// </summary>
    class DraftClipboard
    {
        /// <summary>
        /// Хранилище объектов буфера обена
        /// </summary>
        private List<IDrawable> _clipboard = new List<IDrawable>();

        /// <summary>
        /// Записать в буфер ряд объектов
        /// </summary>
        /// <param name="items">Записываемые объекты</param>
        public void SetRange(List<IDrawable> items)
        {
            _clipboard.Clear();
            foreach(var item in items)
            {
                _clipboard.Add(DraftFactory.Clone(item));
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
               returnList.Add(DraftFactory.Clone(item));
            }
            return returnList;
        }
    }
}