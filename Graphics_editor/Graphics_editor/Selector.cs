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
        public IDrawable Process(MouseEventArgs e, List<IDrawable> draftList)
        {
            var mouseLocation = e.Location;
            for (int i = draftList.Count - 1; i > -1; i--)
            {
                if ((draftList[i].StartPoint.X < mouseLocation.X) && (draftList[i].EndPoint.X > mouseLocation.X))
                    if ((draftList[i].StartPoint.Y < mouseLocation.Y) && (draftList[i].EndPoint.Y > mouseLocation.Y))
                    {
                        return draftList[i];
                    }
            }
            return null;
        }
    }
}