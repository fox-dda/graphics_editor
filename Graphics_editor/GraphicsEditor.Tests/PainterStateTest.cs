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
        Mock<IStrategyDeterminer> _strategyDeterminerMock;

        [SetUp]
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
            _painterState.Figure = inputSrting;

            Assert.IsEmpty(_painterState.InProcessPoints);
        }

        [Test]
        public void DrawingStrategyPropety_Get_ExpectDefineStrategyCall()
        {
            var someStrategy = _painterState.DrawingStrategy;

            _strategyDeterminerMock.Verify(x => x.DefineStrategy(It.IsAny<string>()),
                Times.Exactly(1));
        }
    }
}
