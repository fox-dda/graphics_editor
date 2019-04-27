using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GraphicsEditor.Engine;

namespace GraphicsEditor.View
{
    public partial class FigureToolBox : UserControl
    {       
        public FigureToolBox(PainterState painterState)
        {
            InitializeComponent();
            _painterState = painterState;
            PluginLoader pluginloader = new PluginLoader();
            foreach (var name in pluginloader.LoadModels().Keys.ToList())
            {
                _modelNames.Add(name);
            }
            int verticalSpace = 12;
            
            foreach (var model in _modelNames)
            {            
                Button figureButton = new Button { Text = model };
                figureButton.Click += new EventHandler(EditState);
                figureButton.Location = new Point(10, verticalSpace);
                toolGroupBox.Controls.Add(figureButton);
                verticalSpace += figureButton.Height + 10;
            }
        }

        public void EditState(object sender, EventArgs e)
        {
            _painterState.Figure = (sender as Button).Text;
        }

        private PainterState _painterState;

        private List<string> _modelNames = new List<string>();

        public List<string> ModelNames
        {
            get => _modelNames;
        }
    }


}
