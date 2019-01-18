using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    /// <summary>
    /// Команда изменения цвета канваса
    /// </summary>
    [Serializable]
    public class EditCanvasColorCommand: ICommand
    {
        /// <summary>
        /// Параметры изменяемого канваса
        /// </summary>
        [field: NonSerialized] public PaintingParameters TargetCanvas;
        /// <summary>
        /// Бекап цвета
        /// </summary>
        private Color _backUpCanvasColor;
        /// <summary>
        /// Новый цвет
        /// </summary>
        private Color _newColor;

        /// <summary>
        /// Выполнить команду
        /// </summary>
        public void Do()
        {
            TargetCanvas.CanvasColor = _newColor;
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {
            TargetCanvas.CanvasColor = _backUpCanvasColor;
        }

        /// <summary>
        /// Конструктор команды
        /// </summary>
        /// <param name="editedPaintingPatameters">Параметры изменяемого канваса</param>
        /// <param name="newColor">Новый цвет канваса</param>
        public EditCanvasColorCommand(PaintingParameters editedPaintingPatameters, Color newColor)
        {
            TargetCanvas = editedPaintingPatameters;
            _backUpCanvasColor = editedPaintingPatameters.CanvasColor;
            _newColor = newColor;
        }
    }
}
