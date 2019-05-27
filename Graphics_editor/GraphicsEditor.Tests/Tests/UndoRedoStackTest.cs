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
        private UndoRedoStack UndoRedoStack
        {
            get =>  new UndoRedoStack();
        }

        [TestCase(TestName = "Пересоздание стека")]
        public void ResetTest()
        {
            // Arrange
            var undoRedoStack = new UndoRedoStack();
            var undoStackOld = undoRedoStack.UndoStack;

            // Act
            undoRedoStack.Reset();

            // Assert
            Assert.AreNotSame(undoRedoStack.UndoStack, undoStackOld);
        }

        [TestCase(TestName = "Выполнение команды")]
        public void DoTest()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();

            // Act
            UndoRedoStack.Do(commandMock.Object);

            // Assert
            commandMock.Verify(x => x.Do(), Times.Exactly(1));
        }

        [TestCase(TestName = "Откат команды при непустом стеке")]
        public void UndoTest_ExpectUndoCommandCall()
        {
            // Arrange
            var stack = UndoRedoStack;
            var commandMock = new Mock<ICommand>();
            stack.Do(commandMock.Object);

            // Act
            stack.Undo();

            // Assert
            commandMock.Verify(x => x.Undo(), Times.Exactly(1));
        }

        [TestCase(TestName = "Откат команды при пустом стеке")]
        public void UndoTest_NotExpectUndoCommandCall()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();

            // Act
            UndoRedoStack.Undo();

            // Assert
            commandMock.Verify(x => x.Undo(), Times.Exactly(0));
        }

        [TestCase(TestName = "Выполнение отмененной команды, когда есть отмененные команды")]
        public void RedoTest_ExpectDoCommandCall()
        {
            // Arrange
            var stack = UndoRedoStack;
            var commandMock = new Mock<ICommand>();
            stack.Do(commandMock.Object);
            stack.Undo();

            // Act
            stack.Redo();

            // Assert
            commandMock.Verify(x => x.Do(), Times.Exactly(2));
        }

        [TestCase(TestName = "Выполнение отменной комманды, когда нет отмененных команд")]
        public void RedoTest_NotExpectDoCommandCall()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();

            // Act
            UndoRedoStack.Redo();

            // Assert
            commandMock.Verify(x => x.Do(), Times.Exactly(0));
        }
    }
}