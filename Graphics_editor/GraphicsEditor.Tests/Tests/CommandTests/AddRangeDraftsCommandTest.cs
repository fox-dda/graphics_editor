using NUnit.Framework;
using SDK;
using System.Collections.Generic;
using GraphicsEditor.Core.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class AddRangeDraftsCommandTest
    {
        [TestCase(TestName ="Выполнение команды без null значений")]
        public void DoTest_WithNotNulls()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            var addebleList = new List<IDrawable>() { new TwoPointStub() };
            var addDraftCommand = new AddRangeDraftCommand(draftList, addebleList);

            // Act
            addDraftCommand.Do();

            // Assert
            Assert.IsNotEmpty(addDraftCommand.TargetStorage);
        }

        [TestCase(TestName = "Отмена команды без null значений")]
        public void UndoTest_WithNotNull()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addebleList = new List<IDrawable>() { draft };
            var addDraftCommand = new AddRangeDraftCommand(draftList, addebleList);

            // Act
            addDraftCommand.Undo();

            // Assert
            Assert.IsEmpty(addDraftCommand.TargetStorage);
        }

        [TestCase(TestName = "Выполнение команды c целевым списком = null")]
        public void DoTest_WithNullAddList()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            
            // Assert/Act
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                var addDraftCommand = new AddRangeDraftCommand(draftList, null);
                addDraftCommand.Do();
            });
        }

        [TestCase(TestName = "Отмена команды c добавляемым списком = null")]
        public void UndoTest_WithNullAddList()
        {
            // Arrange
            var draftList = new List<IDrawable>();

            // Assert/Act
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                var addDraftCommand = new AddRangeDraftCommand(draftList, null);
                addDraftCommand.Undo();
            });
        }

        [TestCase(TestName = "Выполнение комманды с целевым списком = null")]
        public void DoTest_WithNullDraft()
        {
            // Arrange
            var draft = new TwoPointStub();
            var addebleList = new List<IDrawable>() { draft };
            var addDraftCommand = new AddRangeDraftCommand(null, addebleList);

            // Assert/Act
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                addDraftCommand.Do();
            });
        }

        [TestCase(TestName = "Отмена команды с целевым списком = null")]
        public void UndoTest_WithNullDraft()
        {
            // Arrange
            var draft = new TwoPointStub();
            var addebleList = new List<IDrawable>() { draft };
            var addDraftCommand = new AddRangeDraftCommand(null, addebleList);

            // Assert/Act
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                addDraftCommand.Undo();
            });
        }
    }
}