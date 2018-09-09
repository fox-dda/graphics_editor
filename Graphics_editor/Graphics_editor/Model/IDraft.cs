using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor.Model
{
    interface IDraft
    {
        void Draw(Graphics g);
        Pen Pen { get; set; }
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
    }
}
