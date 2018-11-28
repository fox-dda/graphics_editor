using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    class Selector
    {
        public IDrawable PointSearch(MouseEventArgs e, List<IDrawable> draftList)
        {
            var mouseLocation = e.Location;
            for (int i = draftList.Count - 1; i > -1; i--)
            {
                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;
                var my = mouseLocation.Y;
                var mx = mouseLocation.X;

                if ((sy < my) && (sx < mx) && (ey > my) && (ex > mx))
                    return draftList[i];
                else if ((sy > my) && (sx > mx) && (ey < my) && (ex < mx))
                    return draftList[i];
                else if ((sy < my) && (sx > mx) && (ey > my) && (ex < mx))
                    return draftList[i];
                else if ((sy > my) && (sx < mx) && (ey < my) && (ex > mx))
                    return draftList[i];
            }
            return null;
        }

        public List<IDrawable> LassoSearch(MouseEventArgs e, List<IDrawable> draftList)
        {
            return null;
        }

    }
}