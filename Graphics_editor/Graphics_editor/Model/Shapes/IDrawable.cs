using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    public interface IDrawable
    {
        PenSettings Pen { get; set; }
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
    }
}
