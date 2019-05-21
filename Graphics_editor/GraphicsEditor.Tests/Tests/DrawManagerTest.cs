using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using System;
using System.Drawing;
using GraphicsEditor.Enums;
using GraphicsEditor.Engine;
using StructureMap;
using GraphicsEditor.Tests.Stubs;
using GraphicsEditor.Interfaces;
using System.IO;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DrawManagerTest
    {
        private DrawManager _drawManager;
        private Graphics _graphics;
        private Mock<IDraftPainter> _draftPainterMock;
        private Mock<IStorageManager> _storageManagerMock;
        private Mock<IPainterState> _painterStateMock;
        private Mock<ISelector> _selectorMock;
        private Mock<IUndoRedoStack> _undoRedoStackMock;
        private Mock<IDraftSerealizer> _draftSerealizerMock;


        public void SetUp()
        {
            _draftPainterMock = new Mock<IDraftPainter>();
            _storageManagerMock = new Mock<IStorageManager>();
            _painterStateMock = new Mock<IPainterState>();
            _selectorMock = new Mock<ISelector>();
            _undoRedoStackMock = new Mock<IUndoRedoStack>();
            _draftSerealizerMock = new Mock<IDraftSerealizer>();

            _drawManager = new DrawManager(
                null,
                _draftPainterMock.Object,
                _storageManagerMock.Object,
                _painterStateMock.Object,
                _selectorMock.Object,
                _undoRedoStackMock.Object,
                _draftSerealizerMock.Object);
        }

        [Test]
        public void EditCanvas_WithSomeColor()
        {
            SetUp();
            Color color = Color.AliceBlue;

            _drawManager.EditCanvasColor(color);

            _storageManagerMock.Verify(x => x.EditCanvasColor(
                It.IsAny<IPaintingParameters>(),
                It.IsAny<Color>()), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [Test]
        public void BiasObject_WithTwoPointInput()
        {
            SetUp();
            var draftMock = new Mock<IDrawable>();
            var bais = new Point(2, 3);

            _drawManager.BiasObject(draftMock.Object, bais);
            draftMock.VerifySet(x => x.StartPoint = It.IsAny<Point>(), Times.Exactly(1));
            draftMock.VerifySet(x => x.EndPoint = It.IsAny<Point>(), Times.Exactly(1));
        }

        [Test]
        public void BiasObject_WithMultiPointInput()
        {
            SetUp();
            var multipointStub = new MultipointStub()
            {
                DotList = new List<Point>() {new Point(0, 0),
                    new Point(1, 1)}
            };
            var bais = new Point(2, 3);

            _drawManager.BiasObject(multipointStub, bais);

            Assert.IsFalse(multipointStub.DotList[0].X == 0 &&
                multipointStub.DotList[0].Y == 0);
        }

        [Test]
        public void DragDotInDraft_TwopointStub()
        {
            SetUp();
            var dragDropingDot = new Point(1, 1);
            var newPoint = new Point(2, 2);
            var draftStub = new TwoPointStub() {StartPoint = dragDropingDot };
            
            _drawManager.DragDotInDraft(draftStub, dragDropingDot, newPoint);

            Assert.IsTrue(draftStub.StartPoint.X == 2 
                && draftStub.StartPoint.Y == 2);
        }

        [Test]
        public void DragDotInDraft_WithMultipointInput()
        {
            SetUp();
            var dragDropingDot = new Point(1, 1);
            var newPoint = new Point(2, 2);
            var multipointStub = new MultipointStub()
            {
                DotList = new List<Point>() {
                    dragDropingDot,
                    new Point(3, 3)}
            };
            var bais = new Point(2, 3);

            _drawManager.BiasObject(multipointStub, bais);

            Assert.IsFalse(multipointStub.DotList[0].X == 2 &&
                multipointStub.DotList[0].Y == 2);
        }

        [Test]
        public void Sereailize_TestWithNullStream()
        {
            SetUp();

            _drawManager.Serealize(null);

            _draftSerealizerMock.Verify(x => x.Serialize(It.IsAny<Stream>(),
                It.IsAny<IUndoRedoStack>()), Times.Exactly(1));
        }

        [Test]
        public void Desereailize_TestWithNullStream()
        {
            SetUp();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _drawManager.Deserialize(null);
            });
            

            _draftSerealizerMock.Verify(x => x.Deserialize(It.IsAny<Stream>()),
                Times.Exactly(1));
        }

        [Test]
        public void Redo_Test()
        {
            SetUp();

            _drawManager.Redo();

            _storageManagerMock.Verify(x => x.DiscardAll(), Times.Exactly(1));
            _storageManagerMock.Verify(x => x.RedoCommand(), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [Test]
        public void Undo_Test()
        {
            SetUp();

            _drawManager.Undo();

            _storageManagerMock.Verify(x => x.DiscardAll(), Times.Exactly(1));
            _storageManagerMock.Verify(x => x.UndoCommand(), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [Test]
        public void Cut_Test()
        {
            SetUp();
            var bufferMock = new Mock<IDraftClipboard>();

            _drawManager.Cut(bufferMock.Object);

            bufferMock.Verify(x => x.SetRange(It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _storageManagerMock.Verify(x => x.RemoveRangeHighlightDrafts(), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [Test]
        public void Copy_Test()
        {
            SetUp();
            var bufferMock = new Mock<IDraftClipboard>();

            _drawManager.Copy(bufferMock.Object);

            bufferMock.Verify(x => x.SetRange(It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [Test]
        public void Paste_Test()
        {
            SetUp();
            var bufferMock = new Mock<IDraftClipboard>();

            _drawManager.Paste(bufferMock.Object);

            _storageManagerMock.Verify(x => x.AddRangeDrafts(It.IsAny<List<IDrawable>>()),
                Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
            bufferMock.Verify(x => x.GetAll(), Times.Exactly(1));
        }

        [Test]
        public void Remove_Test()
        {
            SetUp();

            _drawManager.Remove();

            _storageManagerMock.Verify(x => x.RemoveRangeHighlightDrafts(),
                Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [Test]
        public void CreateNewProject_Test()
        {
            SetUp();

            _drawManager.CreateNewProject();

            _storageManagerMock.Verify(x => x.ClearHistory(),
                Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }
    }
}
