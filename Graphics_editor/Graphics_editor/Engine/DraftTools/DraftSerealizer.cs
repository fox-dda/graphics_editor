using System.Collections.Generic;
using System.IO;
using GraphicsEditor.Model;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using GraphicsEditor.Engine.UndoRedo;


namespace GraphicsEditor
{
    class DraftSerealizer
    {
        public void Serialize(Stream stream, UndoRedoStack stack)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, stack);
        }

        public void Deserialize(Stream stream, UndoRedoStack targetStack)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            targetStack = (UndoRedoStack)binaryFormatter.Deserialize(stream);
        }
    }
}
        