using System.Drawing;
using SDK.Interfaces;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IDraftPainter
    {
        /// <summary>
        /// Состаяние художника фигур
        /// </summary>
        IPainterState State { get; set; }


        /// <summary>
        /// Ядро рисования
        /// </summary>
        Graphics Painter { get; set; }

        /// <summary>
        /// Фабрика фигур
        /// </summary>
        IDraftFactory DraftFactory { get; set; }

        /// <summary>
        /// Менеджер хранилища
        /// </summary>
        IStorageManager Corrector { get; set; }

        /// <summary>
        /// Параметры рисования
        /// </summary>
        IPaintingParameters Parameters { get; set; }

        /// <summary>
        /// Динамическая отрисовка
        /// </summary>
        /// <param name="mousePoint">Координаты мыши</param>
        void DynamicDrawing(Point mousePoint);

        /// <summary>
        /// Добавление точки в рисуемую фигуру
        /// </summary>
        /// <param name="clickPoint">Координаты добавляемой точки</param>
        void AddPointToCacheDraft(Point clickPoint);

        /// <summary>
        /// Перерисовка всех объектов
        /// </summary>
        void RefreshCanvas();

        /// <summary>
        /// Очистить канву
        /// </summary>
         void ClearCanvas();

        /// <summary>
        /// Передать фигуру в хранилище
        /// </summary>
        void AddToStorage();

        /// <summary>
        /// Отрисовка одного объекта
        /// </summary>
        /// <param name="draft"></param>
        void SoloDraw(IDrawable draft);
    }
}

