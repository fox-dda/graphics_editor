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
    public class AddDraftCommandTest
    {
        [TestCase(TestName ="Выполнение команды без null значений")]
        public void DoTest_WithNotNulls()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            var addDraftCommand = new AddDraftCommand(draftList, draft);

            //Act
            addDraftCommand.Do();

            //Assert
            Assert.Contains(draft, draftList);
        }

        [TestCase(TestName = "Отмена команды без null значений")]
        public void UndoTest_WithNotNull()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addDraftCommand = new AddDraftCommand(draftList, draft);

            //Act
            addDraftCommand.Undo();

            //Assert
            Assert.IsFalse( draftList.Contains(draft));
        }

        [TestCase(TestName = "Выполнение комманды с целевым списком = null")]
        public void DoTest_WithNullList()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            var addDraftCommand = new AddDraftCommand(null, draft);

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                addDraftCommand.Do();
            });          
        }

        [TestCase(TestName = "Отмена комманды с целевым списком = null")]
        public void UndoTest_WithNullList()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addDraftCommand = new AddDraftCommand(null, draft);

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                addDraftCommand.Undo();
            });
        }

        [TestCase(TestName = "Выполнение комманды фигурой = null")]
        public void DoTest_WithNullDraft()
        {
            // Arrange
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            var addDraftCommand = new AddDraftCommand(draftList, null);

            // Act/Assert
            Assert.DoesNotThrow( () =>
            {
                addDraftCommand.Do();
            });
        }

        [TestCase(TestName = "Отмена комманды фигурой = null")]
        public void UndoTest_WithNullDraft()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addDraftCommand = new AddDraftCommand(draftList, null);

            // Act/Assert
            Assert.DoesNotThrow( () =>
            {
                addDraftCommand.Undo();
            });
        }
    }
}