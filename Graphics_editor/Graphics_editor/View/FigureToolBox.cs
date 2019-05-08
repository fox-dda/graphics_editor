using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;
using GraphicsEditor.Engine;
using SDK;
using StructureMap;

namespace GraphicsEditor.View
{
    public partial class FigureToolBox : UserControl
    {       
        public FigureToolBox(PainterState painterState)
        {
            InitializeComponent();
            _painterState = painterState;

            var container = new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<IDrawable>().NameBy(x => x.Name);
                });
            });

            var instances = container.GetAllInstances<IDrawable>();

            foreach (var drawerInstance in instances)
            {               
                var name = drawerInstance.GetType().Name.ToString();
                _modelNames.Add(name);
            }
            //PluginLoader pluginloader = new PluginLoader();
            //foreach (var name in pluginloader.LoadModels().Keys.ToList())
            //{
            //    _modelNames.Add(name);
            //}
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
