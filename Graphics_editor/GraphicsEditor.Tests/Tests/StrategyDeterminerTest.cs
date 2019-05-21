using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using System;
using System.Drawing;
using GraphicsEditor.Enums;
using GraphicsEditor.Engine;
using StructureMap;
using GraphicsEditor.Tests.Stubs;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class StrategyDeterminerTest
    {
        private StrategyDeterminer _strategyDeterminer;
        private Mock<IContainer> _containerMock;

        public void SetUp()
        {
            _containerMock = new Mock<IContainer>();
            _strategyDeterminer = new StrategyDeterminer(_containerMock.Object);
        }

        [Test]
        public void DefineStrategy_ExpectSelection()
        {
            SetUp();

            var strategy = _strategyDeterminer.DefineStrategy("HighlightRect");

            Assert.IsTrue(strategy == Strategy.Selection);
        }

        [TestCase("DragPoint")]
        [TestCase("DragDraft")]
        public void DefineStrategy_ExpectDragAndDrop(string str)
        {
            SetUp();

            var strategy = _strategyDeterminer.DefineStrategy(str);

            Assert.IsTrue(strategy == Strategy.DragAndDrop);
        }

        [Test]
        public void DefineStrategy_ExpectMultipoint()
        {
            SetUp();
            _containerMock.Setup(x => x.GetInstance<IDrawable>("SomeFigure"))
                .Returns(new MultipointStub());

            var strategy = _strategyDeterminer.DefineStrategy("SomeFigure");

            Assert.IsTrue(strategy == Strategy.Multipoint);
        }

        [Test]
        public void DefineStrategy_ExpectTwoPoint()
        {
            SetUp();
            _containerMock.Setup(x => x.GetInstance<IDrawable>("SomeFigure"))
                .Returns(new TwoPointStub());

            var strategy = _strategyDeterminer.DefineStrategy("SomeFigure");

            Assert.IsTrue(strategy == Strategy.TwoPoint);
        }

        [TestCase("")]
        [TestCase("     ")]
        [TestCase("Dmitry Domaskin")]
        [TestCase("TRPO2019")]
        public void DefineStrategy_WithAnyString_ExpectTwoPoint(string str)
        {
            SetUp();

            var strategy = _strategyDeterminer.DefineStrategy(str);

            Assert.IsTrue(strategy == Strategy.TwoPoint);
        }
    }
}
