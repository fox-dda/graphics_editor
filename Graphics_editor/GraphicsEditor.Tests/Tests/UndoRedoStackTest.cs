using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine.UndoRedo;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class UndoRedoStackTest
    {
        private UndoRedoStack _undoRedoStack;

        [Test]
        public void ResetTest()
        {
            _undoRedoStack = new UndoRedoStack();
            var undoStackOld = _undoRedoStack.UndoStack;

            _undoRedoStack.Reset();

            Assert.AreNotSame(_undoRedoStack.UndoStack, undoStackOld);
        }

        [Test]
        public void DoTest()
        {
            _undoRedoStack = new UndoRedoStack();
            var commandMock = new Mock<ICommand>();

            _undoRedoStack.Do(commandMock.Object);

            commandMock.Verify(x => x.Do(), Times.Exactly(1));
        }

        [Test]
        public void UndoTest_ExpectUndoCommandCall()
        {
            _undoRedoStack = new UndoRedoStack();
            var commandMock = new Mock<ICommand>();
            _undoRedoStack.Do(commandMock.Object);

            _undoRedoStack.Undo();

            commandMock.Verify(x => x.Undo(), Times.Exactly(1));
        }

        public void UndoTest_NotExpectUndoCommandCall()
        {
            _undoRedoStack = new UndoRedoStack();
            var commandMock = new Mock<ICommand>();

            _undoRedoStack.Undo();

            commandMock.Verify(x => x.Undo(), Times.Exactly(0));
        }

        [Test]
        public void RedoTest_ExpectDoCommandCall()
        {
            _undoRedoStack = new UndoRedoStack();
            var commandMock = new Mock<ICommand>();
            _undoRedoStack.Do(commandMock.Object);
            _undoRedoStack.Undo();

            _undoRedoStack.Redo();

            commandMock.Verify(x => x.Do(), Times.Exactly(2));
        }

        [Test]
        public void RedoTest_NotExpectDoCommandCall()
        {
            _undoRedoStack = new UndoRedoStack();
            var commandMock = new Mock<ICommand>();

            _undoRedoStack.Redo();

            commandMock.Verify(x => x.Do(), Times.Exactly(0));
        }
    }
}