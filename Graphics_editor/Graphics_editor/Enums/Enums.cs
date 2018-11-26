using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Enums
{
    enum Strategy
    {
        twoPoint,
        multipoint
    };

    enum MouseAction
    {
        up,
        down,
        move
    }

    enum Figure
    {
        circle,
        ellipse,
        line,
        polyline,
        triangle
    }
}
