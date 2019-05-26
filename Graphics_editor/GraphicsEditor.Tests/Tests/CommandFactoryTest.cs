using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System.Drawing;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class CommandFactoryTest
    {
        private CommandFactory СommandFactory
        {
            get => new CommandFactory();
    }

        [TestCase(TestName = "Создание команды AddDraft")]
        public void CreateAddDraftCommandTest()
        {
            var command = СommandFactory.CreateAddDraftCommand(
                new List<IDrawable>(), new TwoPointStub());

            Assert.IsNotNull(command);
        }

        [TestCase(TestName = "Создание команды AddRangeDraft")]
        public void CreateAddRangeDraftCommandTest()
        {
            var command = СommandFactory.CreateAddRangeDraftCommand(
                new List<IDrawable>(), new List<IDrawable>());

            Assert.IsNotNull(command);
        }

        [TestCase(TestName = "Создание команды ClearStorage")]
        public void CreateClearStorageCommandTest()
        {
            var command = СommandFactory.CreateClearStorageCommand(
                new List<IDrawable>());

            Assert.IsNotNull(command);
        }

        [TestCase(TestName = "Создание команды EditDraft")]
        public void CreateEditDraftCommandTest()
        {
            var command = СommandFactory.CreateEditDraftCommand(
                new TwoPointStub(),
                new List<Point>(), 
                new PenSettingsStub(),
                Color.AliceBlue,
                new Mock<IDraftFactory>().Object);

            Assert.IsNotNull(command);
        }

        [TestCase(TestName = "Создание команды RemoveDraft")]
        public void CreateRemoveDraftCommandTest()
        { 
            var command = СommandFactory.CreateRemoveDraftCommand(
                new List<IDrawable>(), new TwoPointStub());

            Assert.IsNotNull(command);
        }

        [TestCase(TestName = "Создание команды RemoveRangeDrafts")]
        public void CreateRemoveRangeDraftsCommandTest()
        {
            var command = СommandFactory.CreateRemoveRangeDraftsCommand(
                new List<IDrawable>(), new List<IDrawable>());

            Assert.IsNotNull(command);
        }

        [TestCase(TestName = "Создание команды EditCanvasColor")]
        public void CreateEditCanvasColorCommandTest()
        {
            var command = СommandFactory.CreateEditCanvasColorCommand(
                new Mock<IPaintingParameters>().Object,
                Color.AliceBlue);

            Assert.IsNotNull(command);
        }
    }
}