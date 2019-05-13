using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor
{
    /// <summary>
    /// Сериалайзер проекта
    /// </summary>
    public class DraftSerealizer: IDraftSerealizer
    {
        /// <summary>
        /// Сериализовать стек команд
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <param name="stack">Сериализуемый стек</param>
        public void Serialize(Stream stream, IUndoRedoStack stack)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, stack);
        }

        /// <summary>
        /// Десериализовать стек комманд
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Выполненные комманды</returns>
        public IUndoRedoStack Deserialize(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (IUndoRedoStack)binaryFormatter.Deserialize(stream);
        }
    }
}
        