using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class EditCommandDraftTest
    {
        [Test]
        public void DoTest_WithBrushableTwoPointStub()
        {
            var returnCloneStub = new BrushableTwoPointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                BrushColor = Color.Aqua
            };
            var draftFactoryMock = new Mock<IDraftFactory>();
            draftFactoryMock.Setup(x => x.Clone(It.IsAny<IDrawable>()))
                .Returns(returnCloneStub);
            
            var pointList = new List<Point>()
            {
                new Point(5, 0),
                new Point(0, 5)
            };
            var draft = new BrushableTwoPointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                BrushColor = Color.Green
            };
            var editDraftCommand = new EditDraftCommand(
                draft,
                pointList,
                new PenSettingsStub(),
                Color.AliceBlue,
                draftFactoryMock.Object);

            Assert.DoesNotThrow(() =>
            {
                editDraftCommand.Do();
            });
        }

        [Test]
        public void DoTest_WithMultipointStub()
        {
            var returnCloneStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 0),
                    new Point(1, 1)
                }               
            };
            var draftFactoryMock = new Mock<IDraftFactory>();
            draftFactoryMock.Setup(x => x.Clone(It.IsAny<IDrawable>()))
                .Returns(returnCloneStub);

            var pointList = new List<Point>()
            {
                new Point(5, 0),
                new Point(0, 5)
            };
            var draft = new TwoPointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            var editDraftCommand = new EditDraftCommand(
                draft,
                pointList,
                new PenSettingsStub(),
                Color.AliceBlue,
                draftFactoryMock.Object);

            Assert.DoesNotThrow(() =>
            {
                editDraftCommand.Do();
            });
        }

        [Test]
        public void UndoTest_WithBrushableTwoPointStub()
        {
            var returnCloneStub = new BrushableTwoPointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                BrushColor = Color.Aqua,
            };
            var draftFactoryMock = new Mock<IDraftFactory>();
            draftFactoryMock.Setup(x => x.Clone(It.IsAny<IDrawable>()))
                .Returns(returnCloneStub);

            var pointList = new List<Point>()
            {
                new Point(5, 0),
                new Point(0, 5)
            };
            var draft = new BrushableTwoPointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                BrushColor = Color.Green
            };
            var editDraftCommand = new EditDraftCommand(
                draft,
                pointList,
                new PenSettingsStub(),
                Color.AliceBlue,
                draftFactoryMock.Object);
            editDraftCommand.Do();

            Assert.DoesNotThrow(() =>
            {              
                editDraftCommand.Undo();
            });
        }

        [Test]
        public void UndoTest_WithMultipointStub()
        {
            var returnCloneStub = new MultipointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
            };
            var draftFactoryMock = new Mock<IDraftFactory>();
            draftFactoryMock.Setup(x => x.Clone(It.IsAny<IDrawable>()))
                .Returns(returnCloneStub);

            var pointList = new List<Point>()
            {
                new Point(5, 0),
                new Point(0, 5)
            };
            var draft = new MultipointStub()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
            };
            var editDraftCommand = new EditDraftCommand(
                draft,
                pointList,
                new PenSettingsStub(),
                Color.AliceBlue,
                draftFactoryMock.Object);
            editDraftCommand.Do();

            Assert.DoesNotThrow(() =>
            {
                editDraftCommand.Undo();
            });
        }
    }
}