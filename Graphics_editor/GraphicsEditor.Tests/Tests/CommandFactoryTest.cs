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

        [Test]
        public void CreateAddDraftCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateAddDraftCommand(
                new List<IDrawable>(), new TwoPointStub());

            Assert.IsNotNull(command);
        }

        [Test]
        public void CreateAddRangeDraftCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateAddRangeDraftCommand(
                new List<IDrawable>(), new List<IDrawable>());

            Assert.IsNotNull(command);
        }

        [Test]
        public void CreateClearStorageCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateClearStorageCommand(
                new List<IDrawable>());

            Assert.IsNotNull(command);
        }

        [Test]
        public void CreateEditDraftCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateEditDraftCommand(
                new TwoPointStub(),
                new List<Point>(), 
                new PenSettingsStub(),
                Color.AliceBlue,
                new Mock<IDraftFactory>().Object);

            Assert.IsNotNull(command);
        }

        [Test]
        public void CreateRemoveDraftCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateRemoveDraftCommand(
                new List<IDrawable>(), new TwoPointStub());

            Assert.IsNotNull(command);
        }

        [Test]
        public void CreateRemoveRangeDraftsCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateRemoveRangeDraftsCommand(
                new List<IDrawable>(), new List<IDrawable>());

            Assert.IsNotNull(command);
        }

       [Test]
        public void CreateEditCanvasColorCommandTest()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.CreateEditCanvasColorCommand(
                new Mock<IPaintingParameters>().Object,
                Color.AliceBlue);

            Assert.IsNotNull(command);
        }

    }
}