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
        public void Process(MouseEventArgs e, MouseAction mouseAction, List<IDrawable> draftList)
        {
            switch (mouseAction)
            {
                case MouseAction.down:
                    {
                        break;
                    }
                case MouseAction.move:
                    {
                        break;
                    }
                case MouseAction.up:
                    {
                        var mouseLocation = e.Location;
                        IDrawable selectedDraft;
                        for (int i = draftList.Count - 1; i > - 1; i--)
                        {
                            if ((draftList[i].StartPoint.X < mouseLocation.X) && (draftList[i].EndPoint.X > mouseLocation.X))
                                if((draftList[i].StartPoint.Y < mouseLocation.Y) && (draftList[i].EndPoint.Y > mouseLocation.Y))
                                {
                                    MessageBox.Show("Найдено: " + draftList[i].GetType().ToString());
                                    selectedDraft = draftList[i];
                                    break;
                                }
                                    
                        }

                        break;
                    }
            }
        }
    }
}