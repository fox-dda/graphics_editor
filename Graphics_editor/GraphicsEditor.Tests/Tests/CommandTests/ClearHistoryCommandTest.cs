using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class ClearHistoryCommandTest
    {
        [TestCase(TestName ="Выполнение команды с ненулевыми параметрами")]
        public void DoTest_WithNotNulls()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var clearHistoryCommand = new ClearStorageCommand(draftList);

            // Act
            clearHistoryCommand.Do();

            // Assert
            Assert.IsEmpty(clearHistoryCommand.TargetStorage);
        }

        [TestCase(TestName = "Отмена команды с ненулевыми параметрами")]
        public void UndoTest_WithNotNulls()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var clearHistoryCommand = new ClearStorageCommand(draftList);
            clearHistoryCommand.Do();

            // Act
            clearHistoryCommand.Undo();

            // Assert
            Assert.Contains(draft, clearHistoryCommand.TargetStorage);
        }

        [TestCase(TestName = "Создание команды")]
        public void CreateCommandTest_WithNullStorage()
        {
            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                var clearHistoryCommand = new ClearStorageCommand(null);
            });
        }

    }
}
