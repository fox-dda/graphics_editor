using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEditor.Interfaces;
using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    /// Фабрика команд
    /// </summary>
    public class CommandFactory: ICommandFactory
    {
        /// <summary>
        /// Создать команду добавления фигуры в список
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Добавляемая фигура</param>
        /// <returns>Команда добавления фигуры</returns>
        public AddDraftCommand CreateAddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new AddDraftCommand(storage, draft);
        }

        /// <summary>
        /// Создать команду добавления нескольких фигур в список
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Добавляемые фигуры</param>
        /// <returns>Команда добавления нескольких фигур</returns>
        public AddRangeDraftCommand CreateAddRangeDraftCommand(List<IDrawable> storage, List<IDrawable> addebleList)
        {
            return new AddRangeDraftCommand(storage, addebleList);
        }

        /// <summary>
        /// Создать команду очистки хранилища фигур
        /// </summary>
        /// <param name="storage">Очищаемое хранилище</param>
        /// <returns>Команда очиски хранилища</returns>
        public ClearStorageCommand CreateClearStorageCommand(List<IDrawable> storage)
        {
            return new ClearStorageCommand(storage);
        }

        /// <summary>
        /// Создать команду изменения фигуры
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Новые точки</param>
        /// <param name="pen">Новое перо</param>
        /// <param name="brush">Новый цвет заливки</param>
        /// <returns>Команда изменения фигуры</returns>
        public EditDraftCommand CreateEditDraftCommand(
            IDrawable draft,
            List<Point> pointList,
            IPenSettings pen,
            Color brush,
            IDraftFactory draftFactory)
        {
            return new EditDraftCommand(draft, pointList, pen, brush, draftFactory);
        }

        /// <summary>
        /// Создать команду удаления фигуры из списка
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемая фигура</param>
        /// <returns>Команда удаления фигуры</returns>
        public RemoveDraftCommand CreateRemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new RemoveDraftCommand(storage, draft);
        }

        /// <summary>
        /// Создать команду удаления нескольких фигур из списка
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемые фигуры</param>
        /// <returns>Команда удаления нескольких фигур</returns>
        public RemoveRangeDraftsCommand CreateRemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            return new RemoveRangeDraftsCommand(storage, removebleList);
        }

        /// <summary>
        /// Создать команду изменения цвета канвы
        /// </summary>
        /// <param name="paintengParameters">Параметры рисования</param>
        /// <param name="newColor">Новый цвет канвы</param>
        /// <returns>Команда изменения цвета канвы</returns>
        public EditCanvasColorCommand CreateEditCanvasColorCommand(IPaintingParameters paintengParameters, Color newColor)
        {
            return new EditCanvasColorCommand(paintengParameters, newColor);
        }
    }
}
