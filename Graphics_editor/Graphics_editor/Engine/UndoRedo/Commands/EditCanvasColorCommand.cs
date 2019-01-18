using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    [Serializable]
    public class EditCanvasColorCommand: ICommand
    {
        [field: NonSerialized] public PaintingParameters TargetCanvas;
        private Color _backUpCanvasColor;
        private Color _newColor;

        public void Do()
        {
            TargetCanvas.CanvasColor = _newColor;
        }

        public void Undo()
        {
            TargetCanvas.CanvasColor = _backUpCanvasColor;
        }

        public EditCanvasColorCommand(PaintingParameters editedPaintingPatameters, Color newColor)
        {
            TargetCanvas = editedPaintingPatameters;
            _backUpCanvasColor = editedPaintingPatameters.CanvasColor;
            _newColor = newColor;
        }
    }
}
