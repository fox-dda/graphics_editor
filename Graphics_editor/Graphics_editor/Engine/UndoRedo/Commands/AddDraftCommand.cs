using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using System.Windows.Forms;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    /// <summary>
    /// Команда добавления фигуры в хранилище
    /// </summary>
    [Serializable]
    public class AddDraftCommand: ICommand
    {
        /// <summary>
        /// Список, в который нужно добавить фигуру
        /// </summary>
        public List<IDrawable> DraftList
        {
            get => _draftList;
            set => _draftList = value;
        }

        /// <summary>
        /// Целевой список
        /// </summary>
        [field: NonSerialized]
        private List<IDrawable> _draftList;

        /// <summary>
        /// Добавляемая фигура
        /// </summary>
        private IDrawable _draft;

        /// <summary>
        /// Выполнить команду
        /// </summary>
        public void Do()
        {
            DraftList.Add(_draft);
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {
            DraftList.Remove(_draft);
        }
        /// <summary>
        /// Конструктор команды
        /// </summary>
        /// <param name="storage">Список, в который нужно добавить фигуру</param>
        /// <param name="draft">Добавляемая фигура</param>
        public AddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            DraftList = storage;
            _draft = draft;
        }
    }
}
