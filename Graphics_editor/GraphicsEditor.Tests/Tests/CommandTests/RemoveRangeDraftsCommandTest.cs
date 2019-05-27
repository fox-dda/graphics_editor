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
    public class RemoveRangeDraftsCommandTest
    {
        [TestCase(TestName ="Выполнение команды с ненулевыми параметрами")]
        public void DoTest_WithNotNulls()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addebleList = new List<IDrawable>() { draft };
            var removeRangeDraftsCommand = new RemoveRangeDraftsCommand(
                draftList, addebleList);

            // Act
            removeRangeDraftsCommand.Do();

            // Assert
            Assert.IsEmpty(removeRangeDraftsCommand.TargetStorage);
        }

        [TestCase(TestName = "Отмена команды с ненулевыми параметрами")]
        public void UndoTest_WithNotNull()
        {
            // Arrange
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addebleList = new List<IDrawable>() { draft };
            var removeRangeDraftsCommand = new RemoveRangeDraftsCommand(
                draftList, addebleList);
            removeRangeDraftsCommand.Do();

            // Act
            removeRangeDraftsCommand.Undo();

            // Assert
            Assert.Contains(draft,
                removeRangeDraftsCommand.TargetStorage);
        }

        [TestCase(TestName = "Создание команды судаляемым списком = null")]
        public void Create_WithNullRemoveList()
        {
            // Arrange
            var draftList = new List<IDrawable>();

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                var removeRangeDraftsCommand = 
                    new RemoveRangeDraftsCommand(draftList, null);
            });
        }

        [TestCase(TestName = "Создание команды с целевым списком = null")]
        public void Create_WithNullTargetList()
        {
            // Arrange
            var draftList = new List<IDrawable>();

            // Act/Assert
            Assert.DoesNotThrow( () =>
            {
                var removeRangeDraftsCommand =
                    new RemoveRangeDraftsCommand(null, draftList);
            });
        }
    }
}