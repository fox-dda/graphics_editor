using SDK.Interfaces;
using System.Drawing;

namespace GraphicsEditor.Interfaces
{
    public interface IPenConverter
    {
        Pen ConvertToPen(IPenSettings settings);
    }
}
