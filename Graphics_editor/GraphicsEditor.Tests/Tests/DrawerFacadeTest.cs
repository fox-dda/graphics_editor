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
            // Arrange
            var draft = new TwoPointStub();

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DrawerFacade.DrawShape(draft, null);
            });
        }

        [TestCase(TestName = "Вызов отрисовки null фигуры")]
        public void DrawShape_WithNullDraft()
        {
            // Arrange
            TwoPointStub draft = null;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                DrawerFacade.DrawShape(draft, null);
            });
        }

        [TestCase(TestName = "Вызов отрисовки выделения с Graphics=null")]
        public void DrawHighlight_WithNullGraphics()
        {
            // Arrange
            var draft = new TwoPointStub();

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DrawerFacade.DrawHighlight(draft, null);
            });
        }

        [TestCase(TestName = "Вызов отрисовки выделения null фигуры")]
        public void DrawHighlight_WithNullDraft()
        {
            // Arrange
            TwoPointStub draft = null;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                DrawerFacade.DrawHighlight(draft, null);
            });
        }
    }
}
