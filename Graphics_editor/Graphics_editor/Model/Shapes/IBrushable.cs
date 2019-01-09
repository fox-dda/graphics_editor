using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    interface IBrushable
    {
        Color BrushColor { get; set; }
    }
}
