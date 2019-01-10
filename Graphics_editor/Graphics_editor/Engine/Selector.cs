using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Model;
using System.Windows.Forms;

namespace GraphicsEditor
{
    static class Selector
    {
        public static IDrawable PointSearch(Point  mousePoint, List<IDrawable> draftList)
        {
            if (draftList == null)
                return null;

            for (int i = draftList.Count - 1; i > -1; i--)
            {
                if (draftList[i] == null)
                    continue;
                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;
                var my = mousePoint.Y;
                var mx = mousePoint.X;

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
                if (draftList[i] == null)
                    continue;
                var sy = draftList[i].StartPoint.Y;
                var sx = draftList[i].StartPoint.X;
                var ex = draftList[i].EndPoint.X;
                var ey = draftList[i].EndPoint.Y;
                var fsy = frame.StartPoint.Y;
                var fsx = frame.StartPoint.X;
                var fey = frame.EndPoint.Y;
                var fex = frame.EndPoint.X;
                //////////////////////////////////////////////////////////
                if ((sy > fsy) && (ey < fey) && (sx > fsx) && (ex < fex) )//&& (ey > fsy) && (sy < fey) && (sx > fsx))
                    findList.Add(draftList[i]);
            }
            return findList;
        }

        private static bool IsInRect(Point desiredPoint, Point rectPoint, int regionSize)
        {
            if ((desiredPoint.X > rectPoint.X) && (desiredPoint.X < rectPoint.X + regionSize) && 
                (desiredPoint.Y > rectPoint.Y) && (desiredPoint.Y < rectPoint.Y + regionSize))
                return true;
            else
                return false;
        }

        public static DotInDraft SearchReferenceDot(Point mousePoint, List<IDrawable> highlighList)
        {
            DotInDraft dotInDraft = new DotInDraft();

            foreach(IDrawable draft in highlighList)
            {
                if(draft is Polygon)
                {
                    foreach(Point point in (draft as Polygon).DotList)
                        {
                        if (IsInRect(mousePoint, point, 6))
                            dotInDraft.Set(draft, point);
                    }
                }
                else if(draft is Polyline)
                {

                    foreach (Point point in (draft as Polyline).DotList)
                    {
                        if (IsInRect(mousePoint, point, 6))
                            dotInDraft.Set(draft, point);
                    }
                }
                else
                {
                    if (IsInRect(mousePoint, draft.StartPoint, 6))
                        dotInDraft.Set(draft, draft.StartPoint);
                    if (IsInRect(mousePoint, draft.EndPoint, 6))
                        dotInDraft.Set(draft, draft.EndPoint);
                }
            }

        return dotInDraft;
        }

        public static IDrawable SearchGravityCentre(Point mousePoint, List<IDrawable> highlighList)
        {
            IDrawable gravityInDraft = null;
           /*/ foreach (IDrawable draft in highlighList)
            {
                HighlightRect rect = new HighlightRect(draft);
                if (IsInRect(mousePoint, new Point(rect.DragDropMarkerPoint.X +10, rect.DragDropMarkerPoint.Y - 10), 10))
                    gravityInDraft = draft;
            }/*/
            return gravityInDraft;
        }
    }
}