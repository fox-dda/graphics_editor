using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    /// <summary>
    /// Команда удаления нескольких фигур
    /// </summary>
    [Serializable]
    public class RemoveRangeDraftsCommand : ICommand
    {
        /// <summary>
        /// Целевой список
        /// </summary>
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        /// <summary>
        /// Удаляемые фигуры
        /// </summary>
        private List<IDrawable> _removebleList;

        /// <summary>
        /// Выпонить команду
        /// </summary>
        public void Do()
        {
            foreach (IDrawable draft in _removebleList)
            {
                TargetStorage.Remove(draft);
            }
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {
            foreach (IDrawable draft in _removebleList)
            {
                TargetStorage.Add(draft);
            }
        }

        /// <summary>
        /// Конструктор команды удаления несколькиз фигур
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="removebleList"></param>
        public RemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            TargetStorage = storage;
            _removebleList = new List<IDrawable>();
            foreach(IDrawable draft in removebleList)
            {
                _removebleList.Add(draft);
            }
        }
    }
}
