using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Enums
{
    public enum Strategy
    {
        TwoPoint,
        Multipoint,
        Selection,
        DragAndDrop
    };

    public enum MouseAction
    {
        Up,
        Down,
        Move
    }

    public enum Figure
    {
        Circle,
        Ellipse,
        Line,
        Polyline,
        Polygon,
        Select,     
        DragPoint,
        DragDraft
    }
}
