using SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
using System.Drawing;

namespace GraphicsEditor.Tests.Stubs
{
    public class DraftFactoryStub : IDraftFactory
    {
        public Type CheckUniformity(List<IDrawable> draftList)
        {
            throw new NotImplementedException();
        }

        public IDrawable Clone(IDrawable draft)
        {
            return (IDrawable)(draft as ICloneable).Clone();
        }

        public IDrawable CreateDraft(string figure, List<Point> pointList, IPenSettings gPen, Color brushColor)
        {
            throw new NotImplementedException();
        }
    }
}
