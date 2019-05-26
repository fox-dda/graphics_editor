using NUnit.Framework;
using SDK.Interfaces;
using StructureMap;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Model.Drawers;
using System.Drawing;
using GraphicsEditor.Tests.Stubs;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DrawerFacadeTest
    {
        private DrawerFacade DrawerFacade
        {
            get
            {
                var contaiterMock = new Mock<IContainer>();
                return new DrawerFacade(contaiterMock.Object);
            }
        }

        [TestCase(TestName = "Вызов отрисовки фигуры с Graphics=null")]
        public void DrawShape_WithNullGraphicsProperty()
        {
            var draft = new TwoPointStub();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DrawerFacade.DrawShape(draft, null);
            });
        }

        [TestCase(TestName = "Вызов отрисовки null фигуры")]
        public void DrawShape_WithNullDraft()
        {
            TwoPointStub draft = null;

            Assert.DoesNotThrow(() =>
            {
                DrawerFacade.DrawShape(draft, null);
            });
        }

        [TestCase(TestName = "Вызов отрисовки выделения с Graphics=null")]
        public void DrawHighlight_WithNullGraphics()
        {
            var draft = new TwoPointStub();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DrawerFacade.DrawHighlight(draft, null);
            });
        }

        [TestCase(TestName = "Вызов отрисовки выделения null фигуры")]
        public void DrawHighlight_WithNullDraft()
        {
            TwoPointStub draft = null;

            Assert.DoesNotThrow(() =>
            {
                DrawerFacade.DrawHighlight(draft, null);
            });
        }
    }
}
