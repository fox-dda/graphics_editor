using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Interfaces;
using System.IO;
using System;
using GraphicsEditor.DraftTools;
using GraphicsEditor.Tests.Stubs;
using GraphicsEditor.Engine.UndoRedo.Commands;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class StorageManagerTest
    {
        private Mock<IUndoRedoStack> _undoRedoStackMock;
        private Mock<ICommandFactory> _commandFactoryMock;
        private Mock<IDraftStorage> _draftStorageMock;
        private StorageManager _storageManager;

        public void SetUp()
        {
            _undoRedoStackMock = new Mock<IUndoRedoStack>();
            _commandFactoryMock = new Mock<ICommandFactory>();
            _draftStorageMock = new Mock<IDraftStorage>();
            _storageManager = new StorageManager(
                _draftStorageMock.Object,
                _commandFactoryMock.Object,
                _undoRedoStackMock.Object);
        }

        [Test]
        public void DoCommandTest()
        {
            SetUp();

            _storageManager.DoCommand(new CommandStub());

            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
        }

        [Test]
        public void DoCommandTest_WithNullCommand()
        {
            SetUp();

            try
            {
                _storageManager.DoCommand(null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [Test]
        public void RedoCommandTest()
        {
            SetUp();

            _storageManager.RedoCommand();

            _undoRedoStackMock.Verify(x => x.Redo(), Times.Exactly(1));
        }

        [Test]
        public void UndoCommandTest()
        {
            SetUp();

            _storageManager.UndoCommand();

            _undoRedoStackMock.Verify(x => x.Undo(), Times.Exactly(1));
        }

        [Test]
        public void AddDraftTest_WithStub()
        {
            SetUp();

            _storageManager.AddDraft(new TwoPointStub());

            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateAddDraftCommand(
                It.IsAny<List<IDrawable>>(), It.IsAny<IDrawable>()), Times.Exactly(1));
            _draftStorageMock.VerifyGet(x => x.DraftList);
        }

        [Test]
        public void AddRangeDraftTest_WithStub()
        {
            SetUp();
            var draftList = new List<IDrawable>()
            {
                new TwoPointStub(),
                new TwoPointStub(),
                new TwoPointStub()
            };

            _storageManager.AddRangeDrafts(draftList);

            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateAddRangeDraftCommand(
                It.IsAny<List<IDrawable>>(), It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _draftStorageMock.VerifyGet(x => x.DraftList);
        }

        [Test]
        public void ClearStorageTest()
        {
            SetUp();
            var draftList = new List<IDrawable>() { new TwoPointStub() };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            _storageManager.ClearStorage();

            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateClearStorageCommand(
                It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _draftStorageMock.VerifyGet(x => x.DraftList);
        }

        [Test]
        public void EditHighlightDraftTest_AddHighlightDraft()
        {
            SetUp();
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            _storageManager.EditHighlightDraft(draft);

            Assert.Contains(draft, draftList);
        }

        [Test]
        public void EditHighlightDraftTest_RemoveHighlightDraft()
        {
            SetUp();
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            _storageManager.EditHighlightDraft(draft);

            Assert.IsEmpty(draftList);
        }

        [Test]
        public void DiscardAllTest()
        {
            SetUp();
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            _storageManager.DiscardAll();

            Assert.IsEmpty(draftList); ;
        }


        [Test]
        public void HighlightingDraftRangeTest()
        {
            SetUp();
            var draft = new TwoPointStub();
            var addebleDraftList = new List<IDrawable>() { draft };
            var highlightDraftList = new List<IDrawable>();
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(highlightDraftList);

            _storageManager.HighlightingDraftRange(addebleDraftList);

            Assert.Contains(draft, highlightDraftList);
        }

        [Test]
        public void PullPointsTest_WithTwoPointStub()
        {
            SetUp();
            var draft = new TwoPointStub()
            {
                StartPoint = new Point(1, 1),
                EndPoint = new Point(2, 2)
            };
            var pointList = _storageManager.PullPoints(draft);

            Assert.IsTrue(pointList[0] == draft.StartPoint 
                && pointList[1] == draft.EndPoint);
        }

        [Test]
        public void PullPointsTest_WithMultiPointStub()
        {
            var draft = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(1, 1),
                }
            };
            var pointList = _storageManager.PullPoints(draft);

            Assert.IsTrue(pointList[0] == draft.DotList[0]);
        }

        [Test]
        public void EditCanvasColorTest()
        {
            SetUp();
            var paitingParametersMock = new Mock<IPaintingParameters>();

            _storageManager.EditCanvasColor(paitingParametersMock.Object,
                Color.AliceBlue);

            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()),
                Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateEditCanvasColorCommand(
                It.IsAny<IPaintingParameters>(), It.IsAny<Color>()),
                Times.Exactly(1));
        }

        //public void ClearHistory()
        //{
        //    _storage.DraftList.Clear();
        //    DiscardAll();
        //    _undoRedoStack.Reset();
        //}
        [Test]
        public void ClearHistoryTest()
        {
            SetUp();
            var draftList = new List<IDrawable>();
            _draftStorageMock.Setup(x => x.DraftList)
                .Returns(draftList);
            var highlightDraftList = new List<IDrawable>() { };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(highlightDraftList);

            _storageManager.ClearHistory();

            _undoRedoStackMock.Verify(x => x.Reset(), Times.Exactly(1));
        }
    }
}
