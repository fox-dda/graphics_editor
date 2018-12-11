using System.Collections.Generic;
using System.IO;
using GraphicsEditor.Model;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GraphicsEditor
{
    class DraftSerealizer
    {
        public static void Serialize(List<IDrawable> serList)
        {
            var serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,

            };

            var saveFileDialog = new SaveFileDialog();
            var fileName = saveFileDialog.FileName;
            saveFileDialog.Filter = "Draw | *.draw";
            saveFileDialog.OverwritePrompt = true;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string outputString = JsonConvert.SerializeObject(serList);
            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
                using (JsonWriter jWriter = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(jWriter, serList);
                }
            }

            MessageBox.Show("File is saved");
        }

        public static List<IDrawable> DeSerialize()
        {
            var deSerList = new List<IDrawable>();
            var serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Draw | *.draw";

            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    using (JsonReader jReader = new JsonTextReader(streamReader))
                    {
                        deSerList = serializer.Deserialize<List<IDrawable>>(jReader);
                    }
                }
                MessageBox.Show("File is loading");
            }
            return deSerList;
        }
    }
}
        