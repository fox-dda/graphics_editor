using System.Collections.Generic;
using GraphicsEditor.Interfaces;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor
{
    /// <summary>
    /// Буфер обмена
    /// </summary>
    public class DraftClipboard : IDraftClipboard
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="factory">Фабрика фигур</param>
        public DraftClipboard(IDraftFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Хранилище объектов буфера обмена
        /// </summary>
        private List<IDrawable> _clipboard = new List<IDrawable>();

        /// <summary>
        /// Фабрика фигур для клонирования
        /// </summary>
        private IDraftFactory _factory;

        /// <summary>
        /// Записать в буфер ряд объектов
        /// </summary>
        /// <param name="items">Записываемые объекты</param>
        public void SetRange(List<IDrawable> items)
        {
            _clipboard.Clear();
            foreach(var item in items)
            {
                _clipboard.Add(_factory.Clone(item));
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
               returnList.Add(_factory.Clone(item));
            }
            return returnList;
        }
    }
}