using NUnit.Framework;
using System.Drawing;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Tests.Stubs;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class HighlightRectDrawerTest
    {
        [TestCase(TestName ="Отрисовка прмямоугольника выделения с Graphics=null")]
        public void DrawShapeTest_WithNullGraphics()
        {
            var drawer = new HighlightRectDrawer();
            var draft = new TwoPointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                drawer.DrawShape(draft, null);
            });          
        }
    }
}