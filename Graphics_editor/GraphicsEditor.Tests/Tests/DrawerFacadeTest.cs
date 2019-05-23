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
        private DrawerFacade _drawerFacade;
        private Graphics _graphics;

        public void SetUp()
        {
            var contaiterMock = new Mock<IContainer>();
            _drawerFacade = new DrawerFacade(contaiterMock.Object);
            _graphics = null;
        }

        [Test]
        public void DrawShape_WithNullGraphicsProperty()
        {
            SetUp();
            var draft = new TwoPointStub();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _drawerFacade.DrawShape(draft, _graphics);
            });
        }

        [Test]
        public void DrawShape_WithNullDraft()
        {
            SetUp();
            TwoPointStub draft = null;

            Assert.DoesNotThrow(() =>
            {
                _drawerFacade.DrawShape(draft, _graphics);
            });
        }

        [Test]
        public void DrawHighlight_WithNullGraphics()
        {
            SetUp();
            var draft = new TwoPointStub();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _drawerFacade.DrawHighlight(draft, _graphics);
            });
        }

        [Test]
        public void DrawHighlight_WithNullDraft()
        {
            SetUp();
            TwoPointStub draft = null;

            Assert.DoesNotThrow(() =>
            {
                _drawerFacade.DrawHighlight(draft, _graphics);
            });
        }
    }
}
