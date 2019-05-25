using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Enums;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PainterStateTest
    {
        private PainterState _painterState;
        private Mock<IStrategyDeterminer> _strategyDeterminerMock;

        public void SetUp()
        {
            _strategyDeterminerMock = new Mock<IStrategyDeterminer>();
            _painterState = new PainterState(_strategyDeterminerMock.Object);
        }

        [TestCase("")]
        [TestCase("Square")]
        [TestCase("^_^")]
        public void FigureProperty_SetAnyString_ExpectNullInCaches(string inputSrting)
        {
            SetUp();
            _painterState.Figure = inputSrting;

            Assert.IsTrue(
                (_painterState.DragDropDraft == null) &&
                (_painterState.DragDropDotingDraft == null) &&
                (_painterState.CacheDraft == null) &&
                (_painterState.CacheLasso == null));
        }


        [TestCase("      ")]
        [TestCase("Square")]
        [TestCase("^_^")]
        public void FigureProperty_SetAnyString_ExpectEmptyDotsInProcessList(
            string inputSrting)
        {
            SetUp();
            _painterState.Figure = inputSrting;

            Assert.IsEmpty(_painterState.InProcessPoints);
        }

        [Test]
        public void DrawingStrategyPropety_Get_ExpectDefineStrategyCall()
        {
            SetUp();
            var someStrategy = _painterState.DrawingStrategy;

            _strategyDeterminerMock.Verify(x => x.DefineStrategy(It.IsAny<string>()),
                Times.Exactly(1));
        }

        [Test]
        public void InProcessPoints_Set()
        {
            SetUp();
            
            Assert.DoesNotThrow(() =>
            {
                _painterState.InProcessPoints = new List<System.Drawing.Point>();
            });
        }

        [Test]
        public void InProcessPoints_SetNull()
        {
            SetUp();

            Assert.DoesNotThrow(() =>
            {
                _painterState.InProcessPoints = null;
            });
        }

        [Test]
        public void UndrawableDraft_SetNull()
        {
            SetUp();

            Assert.DoesNotThrow(() =>
            {
                _painterState.UndrawableDraft = null;
            });
        }


        [Test]
        public void UndrawableDraft_Get()
        {
            SetUp();

            Assert.DoesNotThrow(() =>
            {
                var draft = _painterState.UndrawableDraft;
            });
        }

        [Test]
        public void DragDropDotingDot_Set()
        {
            SetUp();

            Assert.DoesNotThrow(() =>
            {
                _painterState.DragDropDotingDot = new System.Drawing.Point(1, 1);
            });
        }


        [Test]
        public void DragDropDotingDot_Get()
        {
            SetUp();

            Assert.DoesNotThrow(() =>
            {
                var point = _painterState.DragDropDotingDot;
            });
        }
    }
}
