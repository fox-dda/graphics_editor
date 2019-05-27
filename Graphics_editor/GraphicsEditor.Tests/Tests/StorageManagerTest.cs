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
        private StorageManager StorageManager
        {
            get
            {
                _undoRedoStackMock = new Mock<IUndoRedoStack>();
                _commandFactoryMock = new Mock<ICommandFactory>();
                _draftStorageMock = new Mock<IDraftStorage>();
                var draftList = new List<IDrawable>();
                _draftStorageMock.Setup(x => x.DraftList)
                    .Returns(draftList);
                _draftStorageMock.Setup(x => x.HighlightDraftsList)
                    .Returns(draftList);
                return new StorageManager(
                    _draftStorageMock.Object,
                    _commandFactoryMock.Object,
                    _undoRedoStackMock.Object);
            }
        }

        [TestCase(TestName = "Выполнение команды")]
        public void DoCommandTest()
        {
            // Act
            StorageManager.DoCommand(new CommandStub());

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
        }

        [TestCase(TestName = "Выполнение команды c параметром null")]
        public void DoCommandTest_WithNullCommand()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                StorageManager.DoCommand(null);
            });       
        }

        [TestCase(TestName = "Выполнение отмененной комманды (Шаг вперед)")]
        public void RedoCommandTest()
        {
            // Act
            StorageManager.RedoCommand();

            // Accert
            _undoRedoStackMock.Verify(x => x.Redo(), Times.Exactly(1));
        }

        [TestCase(TestName = "Отменить комманду (Шаг назад)")]
        public void UndoCommandTest()
        {
            // Act
            StorageManager.UndoCommand();

            // Assert
            _undoRedoStackMock.Verify(x => x.Undo(), Times.Exactly(1));
        }

        [TestCase(TestName = "Добавление двуточечной фигуры в хранилище")]
        public void AddDraftTest_WithStub()
        {
            // Act
            StorageManager.AddDraft(new TwoPointStub());

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateAddDraftCommand(
                It.IsAny<List<IDrawable>>(), It.IsAny<IDrawable>()), Times.Exactly(1));
            _draftStorageMock.VerifyGet(x => x.DraftList);
        }

        [TestCase(TestName = "Добавление в неслкольких фигур в хранилище")]
        public void AddRangeDraftTest_WithStub()
        {
            // Arrange
            var draftList = new List<IDrawable>()
            {
                new TwoPointStub(),
                new TwoPointStub(),
                new TwoPointStub()
            };

            // Act
            StorageManager.AddRangeDrafts(draftList);

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateAddRangeDraftCommand(
                It.IsAny<List<IDrawable>>(), It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _draftStorageMock.VerifyGet(x => x.DraftList);
        }

        [TestCase(TestName = "Очистка хранилища")]
        public void ClearStorageTest()
        {
            // Arrange
            var draftList = new List<IDrawable>() { new TwoPointStub() };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            // Act
            StorageManager.ClearStorage();

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()), Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateClearStorageCommand(
                It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _draftStorageMock.VerifyGet(x => x.DraftList);
        }

        [TestCase(TestName = "Добавление фигуры в список выделенных фигур")]
        public void EditHighlightDraftTest_AddHighlightDraft()
        {
            // Arrange
            var storageManager = StorageManager;
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            // Act
            storageManager.EditHighlightDraft(draft);

            // Assert
            Assert.Contains(draft, draftList);
        }

        [TestCase(TestName = "Удаление фигуры из списка выделенных фигур")]
        public void EditHighlightDraftTest_RemoveHighlightDraft()
        {
            // Arrange
            var storageManager = StorageManager;
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            // Act
            storageManager.EditHighlightDraft(draft);

            // Assert
            Assert.IsEmpty(draftList);
        }

        [TestCase(TestName = "Отмена выделения всех фигур")]
        public void DiscardAllTest()
        {
            // Arrange
            var storageManager = StorageManager;
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(draftList);

            // Act
            storageManager.DiscardAll();

            // Assert
            Assert.IsEmpty(draftList); 
        }


        [TestCase(TestName = "Добавление нескольких фигур в список выделенных")]
        public void HighlightingDraftRangeTest()
        {
            // Arrange
            var storageManager = StorageManager;
            var draft = new TwoPointStub();
            var addebleDraftList = new List<IDrawable>() { draft };
            var highlightDraftList = new List<IDrawable>();
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(highlightDraftList);

            // Act
            storageManager.HighlightingDraftRange(addebleDraftList);

            // Assert
            Assert.Contains(draft, highlightDraftList);
        }

        [TestCase(TestName = "Получение точек из двуточечной фигуры")]
        public void PullPointsTest_WithTwoPointStub()
        {
            // Arrange
            var draft = new TwoPointStub()
            {
                StartPoint = new Point(1, 1),
                EndPoint = new Point(2, 2)
            };

            // Act
            var pointList = StorageManager.PullPoints(draft);

            // Assert
            Assert.IsTrue(pointList[0] == draft.StartPoint 
                && pointList[1] == draft.EndPoint);
        }

        [TestCase(TestName = "Получение точек многоточечной фигуры")]
        public void PullPointsTest_WithMultiPointStub()
        {
            // Arrange
            var draft = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(1, 1),
                }
            };

            // Act
            var pointList = StorageManager.PullPoints(draft);

            // Assert
            Assert.IsTrue(pointList[0] == draft.DotList[0]);
        }

        [TestCase(TestName = "Изменение цвета канвы")]
        public void EditCanvasColorTest()
        {
            // Arrange
            var paitingParametersMock = new Mock<IPaintingParameters>();

            // Act
            StorageManager.EditCanvasColor(paitingParametersMock.Object,
                Color.AliceBlue);

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()),
                Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateEditCanvasColorCommand(
                It.IsAny<IPaintingParameters>(), It.IsAny<Color>()),
                Times.Exactly(1));
        }

        [TestCase(TestName = "Очистка истории")]
        public void ClearHistoryTest()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            _draftStorageMock.Setup(x => x.DraftList)
                .Returns(draftList);
            var highlightDraftList = new List<IDrawable>() { };
            _draftStorageMock.Setup(x => x.HighlightDraftsList)
                .Returns(highlightDraftList);

            // Act
            StorageManager.ClearHistory();

            // Assert
            _undoRedoStackMock.Verify(x => x.Reset(), Times.Exactly(1));
        }

        [TestCase(TestName = "Удаление нескольких фигур из списка выделенных")]
        public void RemoveRangeHighlightDraftsTest()
        {
            // Arrange
            var paitingParametersMock = new Mock<IPaintingParameters>();

            // Act
            StorageManager.RemoveRangeHighlightDrafts();

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()),
                Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateRemoveRangeDraftsCommand(
                It.IsAny<List<IDrawable>>(), It.IsAny<List<IDrawable>>()),
                Times.Exactly(1));
        }

        [TestCase(TestName = "Изменение фигуры")]
        public void EditDraft()
        {
            // Arrange
            var paitingParametersMock = new Mock<IPaintingParameters>();
            var draft = new TwoPointStub();
            var pointList = new List<Point>();
            var paintSettingsMock = new Mock<IPenSettings>();
            var draftFactoryMock = new Mock<IDraftFactory>();

            // Act
            StorageManager.EditDraft(draft, pointList, paintSettingsMock.Object,
                Color.AliceBlue, draftFactoryMock.Object);

            // Assert
            _undoRedoStackMock.Verify(x => x.Do(It.IsAny<ICommand>()),
                Times.Exactly(1));
            _commandFactoryMock.Verify(x => x.CreateEditDraftCommand(
                It.IsAny<IDrawable>(),
                It.IsAny<List<Point>>(),
                It.IsAny<IPenSettings>(),
                It.IsAny<Color>(),
                It.IsAny<IDraftFactory>()),
                Times.Exactly(1));
        }

        [TestCase(TestName = "Чтение из свойства UndoRedoStack")]
        public void UndoRedoStackTest_Get()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var undoRedoStack = StorageManager.UndoRedoStack;
            });           
        }

        [TestCase(TestName = "Запись в свойство UndoRedoStack")]
        public void UndoRedoStackTest_Set()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                StorageManager.UndoRedoStack =
                    new Mock<IUndoRedoStack>().Object;
            });
        }

        [TestCase(TestName = "Чтение из свойства PaintedDraftStorage")]
        public void PaitedDraftStorage_Get()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var draftList = StorageManager.PaintedDraftStorage;
            });
        }
    }
}
