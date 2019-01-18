using System.Collections.Generic;
using System.IO;
using GraphicsEditor.Model;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using GraphicsEditor.Engine.UndoRedo;


namespace GraphicsEditor
{
    /// <summary>
    /// Сериалайзер проекта
    /// </summary>
    class DraftSerealizer
    {
        /// <summary>
        /// Сериализовать стек команд
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <param name="stack">Сериализуемый стек</param>
        public void Serialize(Stream stream, UndoRedoStack stack)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, stack);
        }

        /// <summary>
        /// Десериализовать стек комманд
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Выполненные комманды</returns>
        public UndoRedoStack Deserialize(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (UndoRedoStack)binaryFormatter.Deserialize(stream);
        }
    }
}
        