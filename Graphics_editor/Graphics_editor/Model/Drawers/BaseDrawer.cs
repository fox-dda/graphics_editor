using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    public abstract class BaseDrawer
    {
        public abstract void DrawShape(IDrawable shape, Graphics graphics);
    }
}
