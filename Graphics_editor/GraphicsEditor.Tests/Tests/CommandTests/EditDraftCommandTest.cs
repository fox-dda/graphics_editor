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
        [TestCase(TestName ="Выполнение команды с двуточечной закрашиваемой фигурой")]
        public void DoTest_WithBrushableTwoPointStub()
        {
            // Arrange
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

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                editDraftCommand.Do();
            });
        }

        [TestCase(TestName = "Выполнение команды с многоточечной фигурой")]
        public void DoTest_WithMultipointStub()
        {
            // Arrange
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

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                editDraftCommand.Do();
            });
        }

        [TestCase(TestName = "Отмена команды с двуточечной закрашиваемой фигурой")]
        public void UndoTest_WithBrushableTwoPointStub()
        {
            // Arrange
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

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {              
                editDraftCommand.Undo();
            });
        }

        [TestCase(TestName = "Отмена команды с многоточечной фигурой")]
        public void UndoTest_WithMultipointStub()
        {
            // Arrange
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

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                editDraftCommand.Undo();
            });
        }
    }
}