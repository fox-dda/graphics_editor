using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Enums;
using System.Drawing;
using System;
using GraphicsEditor.Tests.Stubs;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftPainterTest
    {
        private Mock<IPaintingParameters> _paintingParametersMock;
        private Mock<IStorageManager> _storageManagerMock;
        private Mock<IDraftFactory> _draftFactoryMock;
        private Mock<IDrawerFacade> _drawerFacadeMock;
        private Mock<IPainterState> _painterStateMock;
        private DraftPainter DraftPainter
        {
            get
            {
                _paintingParametersMock = new Mock<IPaintingParameters>();
                _storageManagerMock = new Mock<IStorageManager>();
                _draftFactoryMock = new Mock<IDraftFactory>();
                _drawerFacadeMock = new Mock<IDrawerFacade>();
                _painterStateMock = new Mock<IPainterState>();
                return new DraftPainter(
                    null,
                    _paintingParametersMock.Object,
                    _storageManagerMock.Object,
                    _draftFactoryMock.Object,
                    _drawerFacadeMock.Object)
                {
                    State = _painterStateMock.Object
                };
            }
        }


        [TestCase(TestName = "Динамическое рисование с Graphics=null")]
        public void DynamicDrawing_DrawWithNullGraphicsProperty()
        {
            // Arrage
            var mousePoint = new Point(0,0);

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () => 
            {
                DraftPainter.DynamicDrawing(mousePoint);
            });
        }

        [TestCase(TestName = "Добавить точку в двуточечную фигуру кэша")]
        public void AddPointToCacheDraft_WithDoublePointStub()
        {
            // Arrange
            var painter = DraftPainter;
            var twoPointStub = new TwoPointStub();
            _painterStateMock.SetupSet(content => content.CacheDraft = twoPointStub);
            var point = new Point(0, 0);

            // Act
            painter.AddPointToCacheDraft(point);

            // Assert
            _painterStateMock.VerifySet(content => content.CacheDraft
            = It.IsAny<TwoPointStub>(), Times.Exactly(0));
        }

        [TestCase(TestName = "Добавить точку в многоточечную фигуру кэша")]
        public void AddPointToCacheDraft_WithMultiPointStub()
        {
            // Arrange
            var painter = DraftPainter;
            var twoPointStub = new MultipointStub();
            _painterStateMock.SetupSet(content => content.CacheDraft = twoPointStub);
            var point = new Point(0, 0);

            // Act
            painter.AddPointToCacheDraft(point);

            // Assert
            _painterStateMock.VerifySet(content => content.CacheDraft
                = It.IsAny<TwoPointStub>(), Times.Exactly(0));
        }

        [TestCase(TestName = "Перерисовать канвас с Graphics=null")]
        public void RefreshCanvas_WithNullGraphicsProperty()
        {
            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DraftPainter.RefreshCanvas();
            });
        }

        [TestCase(TestName = "Очистить канвас с Graphics=null")]
        public void ClearCanvas_WithNullGraphicsProperty()
        {
            // Arrange
            var draftPainter = DraftPainter;

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                draftPainter.ClearCanvas(); 
            });
            Assert.IsNull(draftPainter.State.CacheDraft);
            _storageManagerMock.Verify(x => x.ClearStorage());         
        }

        [TestCase(TestName = "Добавить фигуру в хранилище с Graphics=null")]
        public void AddToStorage_WithNullGraphicsProperty()
        {
            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DraftPainter.AddToStorage();
            });

            _storageManagerMock.Verify(x => x.AddDraft(It.IsAny<IDrawable>()),
                Times.Exactly(1));
        }

        [TestCase(TestName = "Рисование соло-фигуры")]
        public void SoloDraw_WithTwopointStub()
        {
            // Arrange
            var draft = new TwoPointStub();

            // Act
            DraftPainter.SoloDraw(draft);

            // Assert
            _drawerFacadeMock.Verify(x => x.DrawShape(
                It.IsAny<IDrawable>(),
                It.IsAny<Graphics>()),
                Times.Exactly(1));
            _drawerFacadeMock.Verify(x => x.DrawHighlight(
                It.IsAny<IDrawable>(),
                It.IsAny<Graphics>()),
                Times.Exactly(1));
        }
    }
}
