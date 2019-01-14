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

        public static EditBrushableDraftCommand CreateEditBrushableDraftCommand(IDrawable draft, Point sp, Point ep, PenSettings pen, Color brush)
        {
            return new EditBrushableDraftCommand(draft, sp, ep, pen, brush);
        }

        public static EditDraftCommand CreateEditDraftCommand(IDrawable draft, Point sp, Point ep, PenSettings pen)
        {
            return new EditDraftCommand(draft, sp, ep, pen);
        }

        public static RemoveDraftCommand CreateRemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            return new RemoveDraftCommand(storage, draft);
        }

        public static RemoveRangeDraftsCommand CreateRemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            return new RemoveRangeDraftsCommand(storage, removebleList);
        }
    }
}
