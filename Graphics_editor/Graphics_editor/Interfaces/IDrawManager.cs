using System.Drawing;
using SDK;
using GraphicsEditor.Core;
using GraphicsEditor.Core.UndoRedo;
using GraphicsEditor.DraftTools;
using GraphicsEditor.Enums;
using System.IO;
using System.Windows.Forms;

namespace GraphicsEditor.Interfaces
{
    public interface IDrawManager
    {
        /// <summary>
        /// Художник фигур
        /// </summary>
        IDraftPainter DraftPainter { get; set; }

        /// <summary>
        /// Стек комманд
        /// </summary>
        IUndoRedoStack CommandStack { get; }

        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        IPainterState State { get; set; }

        /// <summary>
        /// Менеджер хранилища фигур
        /// </summary>
        IStorageManager DraftStorageManager { get; set; }

        /// <summary>
        /// Обработка событий клавиш
        /// </summary>
        /// <param name="e">Событие</param>
        /// <param name="_buffer">Буфер обмена</param>
        void KeyProcess(KeyPressEventArgs e, IDraftClipboard _buffer);


        /// <summary>
        /// Обработка событий мыши
        /// </summary>
        /// <param name="e">Событие</param>
        /// <param name="mouseAction">Параметры события</param>
        void MouseProcess(MouseEventArgs e, MouseAction mouseAction);

        /// <summary>
        /// Измененить цвет фона
        /// </summary>
        /// <param name="newColor">Новый цвет фона</param>
        void EditCanvasColor(Color newColor);

        /// <summary>
        /// Сдвинуть объект
        /// </summary>
        /// <param name="draft">Сдвигаемый объект</param>
        /// <param name="bias">Величина сдвига по X и Y</param>
        void BiasObject(IDrawable draft, Point bias);

        /// <summary>
        /// Сдвинуть точку в фигуре
        /// </summary>
        /// <param name="dotInDraft">Точка в фигуре</param>
        /// <param name="newPoint">Новые координаты сдвинутой точки</param>
        void DragDotInDraft(IDrawable dragDropingDraft, Point dragDropingDot, Point newPoint);

        /// <summary>
        /// Сериализовать проект
        /// </summary>
        /// <param name="stream">Поток</param>
        void Serealize(Stream stream);

        /// <summary>
        /// Десериализовать проект
        /// </summary>
        /// <param name="stream">Поток</param>
        void Deserialize(Stream stream);

        /// <summary>
        /// Повторить последнее действие
        /// </summary>
        void Redo();

        /// <summary>
        /// Отменить последнее действие
        /// </summary>
        void Undo();

        /// <summary>
        /// Вырезать объект
        /// </summary>
        /// <param name="buffer">Буфер обмена</param>
        void Cut(IDraftClipboard buffer);

        /// <summary>
        /// Копировать в буффер обмена
        /// </summary>
        /// <param name="buffer">Буфер обмена</param>
        void Copy(IDraftClipboard buffer);

        /// <summary>
        /// Вставить в буффер обмена
        /// </summary>
        /// <param name="buffer">Буфер обмена</param>
        void Paste(IDraftClipboard buffer);

        /// <summary>
        /// Удалить объект
        /// </summary>
        void Remove();

        /// <summary>
        /// Создать новый проект
        /// </summary>
        void CreateNewProject();
    }
}
