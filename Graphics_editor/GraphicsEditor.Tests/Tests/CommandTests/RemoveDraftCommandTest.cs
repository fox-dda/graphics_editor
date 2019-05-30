using NUnit.Framework;
using SDK;
using System.Collections.Generic;
using GraphicsEditor.Core.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class RemoveDraftCommandTest
    {
        [TestCase(TestName = "Выполнение команды с ненулевыми параметрами")]
        public void DoTest_WithNotNulls()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var removeDraftCommand = new RemoveDraftCommand(draftList, draft);

            // Act
            removeDraftCommand.Do();

            // Assert
            Assert.IsEmpty(draftList);
        }

        [TestCase(TestName = "Отмена команды ненулевыми параметрами")]
        public void UndoTest_WithNotNull()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var removeDraftCommand = new RemoveDraftCommand(draftList, draft);
            removeDraftCommand.Do();

            // Act
            removeDraftCommand.Undo();

            // Assert
            Assert.Contains(draft, draftList);
        }

        [TestCase(TestName = "Выполнение команды с целевым списком = null")]
        public void DoTest_WithNullList()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            var removeDraftCommand = new RemoveDraftCommand(null, draft);

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                removeDraftCommand.Do();
            });
        }

        [TestCase(TestName = "Отмена команды с целевым списком = null")]
        public void UndoTest_WithNullList()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var removeDraftCommand = new RemoveDraftCommand(null, draft);

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                removeDraftCommand.Undo();
            });
        }

        [TestCase(TestName = "Выполнение команды с удаляемой фигурой = null")]
        public void DoTest_WithNullDraft()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            var removeDraftCommand = new RemoveDraftCommand(draftList, null);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                removeDraftCommand.Do();
            });
        }
        [TestCase(TestName = "Отмена команды с удаляемой фигурой = null")]
        public void UndoTest_WithNullDraft()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var removeDraftCommand = new RemoveDraftCommand(draftList, null);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                removeDraftCommand.Undo();
            });
        }
    }
}