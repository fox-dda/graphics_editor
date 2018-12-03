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
    static class Selector
    {
        public static IDrawable PointSearch(MouseEventArgs e, List<IDrawable> draftList)
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

        public static List<IDrawable> LassoSearch(HighlightRect frame, List<IDrawable> draftList)
        {
            List<IDrawable> findList = new List<IDrawable>();
            for (int i = draftList.Count - 1; i > -1; i--)
            {
                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;
                var fsy = frame.StartPoint.Y;
                var fsx = frame.StartPoint.X;
                var fey = frame.EndPoint.Y;
                var fex = frame.EndPoint.X;

                if ((sy > fsy) && (ey < fey) && (sx > fsx) && (ex < fex))
                    findList.Add(draftList[i]);
            }
            return findList;
        }

    }
}