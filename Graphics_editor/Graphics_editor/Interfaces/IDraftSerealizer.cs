using System.IO;

namespace GraphicsEditor.Interfaces
{
    public interface IDraftSerealizer
    {
        /// <summary>
        /// Сериализовать стек команд
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <param name="stack">Сериализуемый стек</param>
        void Serialize(Stream stream, IUndoRedoStack stack);

        /// <summary>
        /// Десериализовать стек комманд
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Выполненные комманды</returns>
        IUndoRedoStack Deserialize(Stream stream);
    }
}
