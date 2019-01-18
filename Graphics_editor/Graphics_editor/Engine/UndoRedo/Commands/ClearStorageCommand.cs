using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    /// <summary>
    /// Команда очистки хранилища объектов
    /// </summary>
    [Serializable]
    public class ClearStorageCommand : ICommand
    {
        /// <summary>
        /// Очищаемое хранилище
        /// </summary>
        [field: NonSerialized] public List<IDrawable> TargetStorage;
        /// <summary>
        /// Бэкап хранилища
        /// </summary>
        private List<IDrawable> _backUp;

        /// <summary>
        /// Выполнить команду
        /// </summary>
        public void Do()
        {
            TargetStorage.Clear();
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {
            foreach (IDrawable draft in _backUp)
            {
                TargetStorage.Add(draft);
            }
        }

        /// <summary>
        /// Конструктор команды очистки
        /// </summary>
        /// <param name="storage">Очищаемый список</param>
        public ClearStorageCommand(List<IDrawable> storage)
        {
            TargetStorage = storage;
            _backUp = new List<IDrawable>();
            foreach(IDrawable draft in storage)
            {
                _backUp.Add(draft);
            }
        }
    }
}
