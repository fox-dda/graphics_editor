using System;
using System.Collections.Generic;
using System.Drawing;
using SDK;
using GraphicsEditor.Interfaces;

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
        public IPaintingParameters TargetPaintingParameters { get; set; }

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
            TargetPaintingParameters.CanvasColor = _newColor;
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {
            TargetPaintingParameters.CanvasColor = _backUpCanvasColor;
        }

        /// <summary>
        /// Конструктор команды
        /// </summary>
        /// <param name="editedPaintingParameters">Параметры изменяемого канваса</param>
        /// <param name="newColor">Новый цвет канваса</param>
        public EditCanvasColorCommand(IPaintingParameters editedPaintingParameters, Color newColor)
        {
            TargetPaintingParameters = editedPaintingParameters;
            _backUpCanvasColor = editedPaintingParameters.CanvasColor;
            _newColor = newColor;
        }
    }
}
