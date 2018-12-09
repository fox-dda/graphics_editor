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
        multipoint,
        selection,
        dragAndDrop
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
        triangle,
        polygon,
        select,     
        drag
    }
}
