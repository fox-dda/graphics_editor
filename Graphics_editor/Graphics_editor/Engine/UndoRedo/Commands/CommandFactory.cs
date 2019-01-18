using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using System.Drawing;


namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    public static class CommandFactory
    {
        public static AddDraftCommand CreateAddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new AddDraftCommand(storage, draft);
        }

        public static AddRangeDraftCommand CreateAddRangeDraftCommand(List<IDrawable> storage, List<IDrawable> addebleList)
        {
            return new AddRangeDraftCommand(storage, addebleList);
        }

        public static ClearStorageCommand CreateClearStorageCommand(List<IDrawable> storage)
        {
            return new ClearStorageCommand(storage);
        }

        public static EditDraftCommand CreateEditDraftCommand(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            return new EditDraftCommand(draft, pointList, pen, brush);
        }

        public static RemoveDraftCommand CreateRemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new RemoveDraftCommand(storage, draft);
        }

        public static RemoveRangeDraftsCommand CreateRemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            return new RemoveRangeDraftsCommand(storage, removebleList);
        }

        public static EditCanvasColorCommand CreateEditCanvasColorCommand(PaintingParameters paintengParameters, Color newColor)
        {
            return new EditCanvasColorCommand(paintengParameters, newColor);
        }
    }
}
