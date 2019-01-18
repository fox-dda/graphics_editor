using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using System.Drawing;


namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    /// <summary>
    /// Фабрика команд
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Создать команду добавления фигуры в список
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Добавляемая фигура</param>
        /// <returns>Команда добавления фигуры</returns>
        public static AddDraftCommand CreateAddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new AddDraftCommand(storage, draft);
        }

        /// <summary>
        /// Создать команду добавления нескольких фигур в список
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Добавляемые фигуры</param>
        /// <returns>Команда добавления нескольких фигур</returns>
        public static AddRangeDraftCommand CreateAddRangeDraftCommand(List<IDrawable> storage, List<IDrawable> addebleList)
        {
            return new AddRangeDraftCommand(storage, addebleList);
        }

        /// <summary>
        /// Создать команду очистки хранилища фигур
        /// </summary>
        /// <param name="storage">Очищаемое хранилище</param>
        /// <returns>Команда очиски хранилища</returns>
        public static ClearStorageCommand CreateClearStorageCommand(List<IDrawable> storage)
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
        public static EditDraftCommand CreateEditDraftCommand(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            return new EditDraftCommand(draft, pointList, pen, brush);
        }

        /// <summary>
        /// Создать команду удаления фигуры из списка
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемая фигура</param>
        /// <returns>Команда удаления фигуры</returns>
        public static RemoveDraftCommand CreateRemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new RemoveDraftCommand(storage, draft);
        }

        /// <summary>
        /// Создать команду удаления нескольких фигур из списка
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемые фигуры</param>
        /// <returns>Команда удаления нескольких фигур</returns>
        public static RemoveRangeDraftsCommand CreateRemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            return new RemoveRangeDraftsCommand(storage, removebleList);
        }

        /// <summary>
        /// Создать команду изменения цвета канвы
        /// </summary>
        /// <param name="paintengParameters">Параметры рисования</param>
        /// <param name="newColor">Новый цвет канвы</param>
        /// <returns>Команда изменения цвета канвы</returns>
        public static EditCanvasColorCommand CreateEditCanvasColorCommand(PaintingParameters paintengParameters, Color newColor)
        {
            return new EditCanvasColorCommand(paintengParameters, newColor);
        }
    }
}
