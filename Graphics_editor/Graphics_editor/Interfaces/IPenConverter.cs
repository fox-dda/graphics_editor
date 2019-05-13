using SDK;
using System.Drawing;

namespace GraphicsEditor.Interfaces
{
    public interface IPenConverter
    {
        Pen ConvertToPen(PenSettings settings);
    }
}
