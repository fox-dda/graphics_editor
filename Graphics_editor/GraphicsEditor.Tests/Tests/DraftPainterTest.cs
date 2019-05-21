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
        private DraftPainter _draftPainter;
        private Mock<IPaintingParameters> _paintingParametersMock;
        private Mock<IStorageManager> _storageManagerMock;
        private Mock<IDraftFactory> _draftFactoryMock;
        private Mock<IDrawerFacade> _drawerFacadeMock;
        private Mock<IPainterState> _painterStateMock;

        /// <summary>
        /// Пересоздать переменные теста
        /// </summary>
        public void SetUp()
        {

            _paintingParametersMock = new Mock<IPaintingParameters>();
            _storageManagerMock = new Mock<IStorageManager>();
            _draftFactoryMock = new Mock<IDraftFactory>();
            _drawerFacadeMock = new Mock<IDrawerFacade>();
            _painterStateMock = new Mock<IPainterState>();
            _draftPainter = new DraftPainter(
                null,
                _paintingParametersMock.Object,
                _storageManagerMock.Object,
                _draftFactoryMock.Object,
                _drawerFacadeMock.Object);
            _draftPainter.State = _painterStateMock.Object;
        }

        [Test]
        public void DynamicDrawing_DrawWithNullGraphicsProperty()
        {
            SetUp();
            var mousePoint = new Point(0,0);

            Assert.Throws(typeof(NullReferenceException), () => 
            {
                _draftPainter.DynamicDrawing(mousePoint);
            });
        }

        [Test]
        public void AddPointToCacheDraft_WithDoublePointStub()
        {
            SetUp();
            var twoPointStub = new TwoPointStub();
            _painterStateMock.SetupSet(content => content.CacheDraft = twoPointStub);
            var point = new Point(0, 0);

            _draftPainter.AddPointToCacheDraft(point);

            _painterStateMock.VerifySet(content => content.CacheDraft
            = It.IsAny<TwoPointStub>(), Times.Exactly(0));
        }

       [Test]
       public void RefreshCanvas_WithNullGraphicsProperty()
        {
            SetUp();
            

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _draftPainter.RefreshCanvas();
            });
        }

        [Test]
        public void ClearCanvas_WithNullGraphicsProperty()
        {
            SetUp();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _draftPainter.ClearCanvas(); 
            });

            Assert.IsNull(_draftPainter.State.CacheDraft);
            _storageManagerMock.Verify(x => x.ClearStorage());
            
        }

        [Test]
        public void AddToStorage_WithNullGraphicsProperty()
        {
            SetUp();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _draftPainter.AddToStorage();
            });

            _storageManagerMock.Verify(x => x.AddDraft(It.IsAny<IDrawable>()),
                Times.Exactly(1));
        }

        [Test]
        public void SoloDraw_WithTwopointStub()
        {
            SetUp();

            _draftPainter.SoloDraw(new TwoPointStub());

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
