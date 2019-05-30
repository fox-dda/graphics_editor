using System.Drawing;
using System.Collections.Generic;
using SDK;
using GraphicsEditor.Core.UndoRedo.Commands;
using SDK.Interfaces;

namespace GraphicsEditor.Interfaces
{
    public interface ICommandFactory
    {
        /// <summary>
        /// Создать команду добавления фигуры в список
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Добавляемая фигура</param>
        /// <returns>Команда добавления фигуры</returns>
        AddDraftCommand CreateAddDraftCommand(List<IDrawable> storage, IDrawable draft);

        /// <summary>
        /// Создать команду добавления нескольких фигур в список
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Добавляемые фигуры</param>
        /// <returns>Команда добавления нескольких фигур</returns>
        AddRangeDraftCommand CreateAddRangeDraftCommand(List<IDrawable> storage,
            List<IDrawable> addebleList);

        /// <summary>
        /// Создать команду очистки хранилища фигур
        /// </summary>
        /// <param name="storage">Очищаемое хранилище</param>
        /// <returns>Команда очиски хранилища</returns>
        ClearStorageCommand CreateClearStorageCommand(List<IDrawable> storage);

        /// <summary>
        /// Создать команду изменения фигуры
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Новые точки</param>
        /// <param name="pen">Новое перо</param>
        /// <param name="brush">Новый цвет заливки</param>
        /// <returns>Команда изменения фигуры</returns>
        EditDraftCommand CreateEditDraftCommand(IDrawable draft,
            List<Point> pointList,
            IPenSettings pen,
            Color brush,
            IDraftFactory draftFactory);

        /// <summary>
        /// Создать команду удаления фигуры из списка
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемая фигура</param>
        /// <returns>Команда удаления фигуры</returns>
        RemoveDraftCommand CreateRemoveDraftCommand(List<IDrawable> storage, IDrawable draft);

        /// <summary>
        /// Создать команду удаления нескольких фигур из списка
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемые фигуры</param>
        /// <returns>Команда удаления нескольких фигур</returns>
        RemoveRangeDraftsCommand CreateRemoveRangeDraftsCommand(
            List<IDrawable> storage, List<IDrawable> removebleList);


        /// <summary>
        /// Создать команду изменения цвета канвы
        /// </summary>
        /// <param name="paintengParameters">Параметры рисования</param>
        /// <param name="newColor">Новый цвет канвы</param>
        /// <returns>Команда изменения цвета канвы</returns>
        EditCanvasColorCommand CreateEditCanvasColorCommand(
            IPaintingParameters paintengParameters, Color newColor);
    }
}
