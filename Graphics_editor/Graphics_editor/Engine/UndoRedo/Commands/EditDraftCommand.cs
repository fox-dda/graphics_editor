﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using System.Windows.Forms;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{/*/
    [Serializable]
    public class EditDraftCommand : ICommand
    {
        private IDrawable _editedDraft;
        private IDrawable _backUpDraft;
        private Point _sp;
        private Point _ep;
        private PenSettings _pen;

        public void Do()
        {
            _editedDraft.StartPoint = _sp;
            _editedDraft.EndPoint = _ep;
            _editedDraft.Pen = _pen;
        }

        public void Undo()
        {
            MessageBox.Show("Undoo");
            _editedDraft = _backUpDraft;
        }

        public EditDraftCommand(IDrawable draft, Point sp, Point ep, PenSettings pen)
        {
            _backUpDraft = DraftFactory.Clone(draft);
            _editedDraft = draft;
            _sp = sp;
            _ep = ep;
            _pen = pen;
        }
    }/*/
}