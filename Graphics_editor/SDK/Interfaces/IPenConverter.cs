using System.Drawing;

namespace SDK.Interfaces
{
    interface IPenConverter
    {
        Pen ConvertToPen(IPenSettings settings);
    }
}
