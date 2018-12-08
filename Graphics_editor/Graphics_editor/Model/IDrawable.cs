using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    public interface IDrawable
    {
        void Draw(Graphics g);
        Pen Pen { get; set; }
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
    }
}
