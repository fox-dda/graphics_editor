using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Core;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PainterStateTest
    {
        private Mock<IStrategyDeterminer> _strategyDeterminerMock;
        private PainterState PainterState
        {
            get
            {
                _strategyDeterminerMock = new Mock<IStrategyDeterminer>();
                return new PainterState(_strategyDeterminerMock.Object);
            }
        }

        [TestCase("", TestName ="Запись в свойство Figure пустой строки")]
        [TestCase("Square", TestName = "Запись в свойство Figure буквенной строки")]
        [TestCase("^_^", TestName = "Запись в свойство Figure знаковой строки")]
        public void FigureProperty_SetAnyString_ExpectNullInCaches(string inputSrting)
        {
            // Act
            PainterState.Figure = inputSrting;

            // Assert
            Assert.IsTrue(
                (PainterState.DragDropDraft == null) &&
                (PainterState.DragDropDotingDraft == null) &&
                (PainterState.CacheDraft == null) &&
                (PainterState.CacheLasso == null));
        }


        [TestCase("      ", TestName ="Запись в свойство Figure строки пробелов")]
        [TestCase("Square", TestName = "Запись в свойство Figure буквенной строки")]
        [TestCase("^_^", TestName = "Запись в свойство Figure знаковой строки")]
        public void FigureProperty_SetAnyString_ExpectEmptyDotsInProcessList(
            string inputSrting)
        {
            // Act
            PainterState.Figure = inputSrting;

            // Assert
            Assert.IsEmpty(PainterState.InProcessPoints);
        }

        [TestCase(TestName = "Считыванине свойства DrawingStrategy")]
        public void DrawingStrategyPropety_Get_ExpectDefineStrategyCall()
        {
            // Act
            var someStrategy = PainterState.DrawingStrategy;

            // Assert
            _strategyDeterminerMock.Verify(x => x.DefineStrategy(It.IsAny<string>()),
                Times.Exactly(1));
        }


        [TestCase(TestName = "Запись в свойство InProcessPoints")]
        public void InProcessPoints_Set()
        {    
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                PainterState.InProcessPoints = new List<System.Drawing.Point>();
            });
        }

        [TestCase(TestName = "Запись в свойство InProcessPoints значения null")]
        public void InProcessPoints_SetNull()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                PainterState.InProcessPoints = null;
            });
        }

        [TestCase(TestName = "Запись в свойство UndrawableDraft значения null")]
        public void UndrawableDraft_SetNull()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                PainterState.UndrawableDraft = null;
            });
        }


        [TestCase(TestName = "Чтение свойства UndrawableDraft")]
        public void UndrawableDraft_Get()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var draft = PainterState.UndrawableDraft;
            });
        }

        [TestCase(TestName = "Запись свойства DragDropDotingDot")]
        public void DragDropDotingDot_Set()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                PainterState.DragDropDotingDot = new System.Drawing.Point(1, 1);
            });
        }


        [TestCase(TestName = "Чтение свойства DragDropDotingDot")]
        public void DragDropDotingDot_Get()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var point = PainterState.DragDropDotingDot;
            });
        }
    }
}
