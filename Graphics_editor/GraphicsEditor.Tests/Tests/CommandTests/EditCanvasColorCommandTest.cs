using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System;
using GraphicsEditor.Interfaces;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class EditCanvasColorCommandTest
    {
        private EditCanvasColorCommand _editCanvasColorCommand;
        private Mock<IPaintingParameters> _paintingParametersMock;

        [Test]
        public void DoTest_WithNotNulls()
        {
            _paintingParametersMock = new Mock<IPaintingParameters>();
            _paintingParametersMock.Setup(x => x.CanvasColor)
                .Returns(Color.Green);
            _editCanvasColorCommand = new EditCanvasColorCommand(
                _paintingParametersMock.Object,
                Color.Red);

            _editCanvasColorCommand.Do();

            _paintingParametersMock.VerifySet(x => x.CanvasColor = Color.Red);
        }

        [Test]
        public void UndoTest_WithNotNulls()
        {
            _paintingParametersMock = new Mock<IPaintingParameters>();
            _paintingParametersMock.Setup(x => x.CanvasColor)
                .Returns(Color.Green);
            _editCanvasColorCommand = new EditCanvasColorCommand(
                _paintingParametersMock.Object,
                Color.Red);
            _editCanvasColorCommand.Do();

            _editCanvasColorCommand.Undo();

            _paintingParametersMock.VerifySet(x => x.CanvasColor = Color.Green);
        }

        [Test]
        public void CreateCommandTest_WithNullParameters()
        {
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _editCanvasColorCommand = new EditCanvasColorCommand(
                    null, Color.Green);
            });
        }
    }
}
