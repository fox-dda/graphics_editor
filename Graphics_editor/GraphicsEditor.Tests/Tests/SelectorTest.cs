using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Enums;
using System;
using System.Drawing;
using GraphicsEditor.Tests.Stubs;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class SelectorTest
    {
        private Selector _selector;
        private List<Mock<IDrawable>> _draftMockList;
        private List<IDrawable> _draftList;

        public void SetUp()
        {
            Random randomGenerator = new Random();
            _selector = new Selector();
            _draftList = new List<IDrawable>();
            _draftMockList = new List<Mock<IDrawable>>();

            for(int i = 0; i != 20; i++)
            {
                var draftMock = new Mock<IDrawable>();
                draftMock.Setup(x => x.StartPoint).Returns(
                    new Point(randomGenerator.Next(0, 500),
                        (randomGenerator.Next(0, 500))));
                draftMock.Setup(x => x.EndPoint).Returns(
                     new Point(randomGenerator.Next(0, 500),
                        (randomGenerator.Next(0, 500))));
                _draftMockList.Add(draftMock);
                _draftList.Add(draftMock.Object);
            }

        }

        [TestCase(0, 0)]
        [TestCase(0, 500)]
        [TestCase(500, 0)]
        [TestCase(500, 500)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(499, 0)]
        [TestCase(0, 499)]
        public void PointSearch_TestWithDoublePointDrafts_ExpectNullReturn(
            int xDot, int yDot)
        {
            SetUp();
            var draftMock = new Mock<IDrawable>();
            draftMock.Setup(x => x.StartPoint).Returns(
                new Point(0, 500));
            draftMock.Setup(x => x.EndPoint).Returns(
                 new Point(500, 00));
            _draftList.Add(draftMock.Object);

            var rezultDraft =_selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            Assert.IsNull(rezultDraft);
        }


        [TestCase(1, 1)]
        [TestCase(499, 499)]
        [TestCase(499, 1)]
        [TestCase(1, 499)]
        public void PointSearch_TestWithDoublePointDrafts_ExpectNotNullReturn(
            int xDot, int yDot)
        {
            SetUp();
            var draftMock = new Mock<IDrawable>();
            draftMock.Setup(x => x.StartPoint).Returns(
                new Point(0, 500));
            draftMock.Setup(x => x.EndPoint).Returns(
                 new Point(500, 0));
            _draftList.Add(draftMock.Object);

            var rezultDraft = _selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            Assert.IsNotNull(rezultDraft);
        }

        [TestCase(1, 1)]
        [TestCase(499, 499)]
        [TestCase(499, 1)]
        [TestCase(1, 499)]
        public void PointSearch_TestWithMultipointDrafts_ExpectNotNullReturn(
           int xDot, int yDot)
        {
            SetUp();
            _draftList.Clear();
            var multipiontStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 500),
                    new Point(150, 250),
                    new Point(500, 0)
                }
            };

            _draftList.Add(multipiontStub);

            var rezultDraft = _selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            Assert.IsNotNull(rezultDraft);
        }

        [TestCase(0, 0)]
        [TestCase(0, 500)]
        [TestCase(500, 0)]
        [TestCase(500, 500)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(499, 0)]
        [TestCase(0, 499)]
        public void PointSearch_TestWithMultipointDrafts_ExpectNullReturn(
          int xDot, int yDot)
        {
            SetUp();
            var multipiontStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 500),
                    new Point(150, 250),
                    new Point(500, 0)
                }
            };

            _draftList.Add(multipiontStub);

            var rezultDraft = _selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            Assert.IsNull(rezultDraft);
        }

        [Test]
        public void LassoSearch_TestWithMultipointDrafts_ExpectEmptyReturn(
            [Range(0, 3)] int startXDot,
            [Range(0, 3)] int startYDot,
            [Range(0, 3)] int endXDot,
            [Range(0, 3)] int endYDot)
        {
            SetUp();
            _draftList.Clear();
            var lasso = new TwoPointStub()
            {
                StartPoint = new Point(startXDot, startYDot),
                EndPoint = new Point(endXDot, endYDot)
            };
            var multipiontStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 3),
                    new Point(2, 3),
                    new Point(3, 0)
                }
            };

            _draftList.Add(multipiontStub);

            var rezultDraft = _selector.LassoSearch(
                lasso, _draftList);

            Assert.IsEmpty(rezultDraft);
        }

        [TestCase(-1, -1, 501, 501)]
        public void LassoSearch_TestWithMultipointDrafts_ExpectNotImptyListReturn(
           int startXDot, int startYDot, int endXDot, int endYDot)
        {
            SetUp();
            _draftList.Clear();
            var lasso = new TwoPointStub()
            {
                StartPoint = new Point(startXDot, startYDot),
                EndPoint = new Point(endXDot, endYDot)
            };
            var multipiontStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 500),
                    new Point(150, 250),
                    new Point(500, 0)
                }
            };

            _draftList.Add(multipiontStub);

            var rezultDraft = _selector.LassoSearch(
                lasso, _draftList);

            Assert.IsNotEmpty(rezultDraft);
        }

        [Test]
        public void SearchReferenceDotTest_RefDotOwnedMultipoint()
        {
            SetUp();
            var refDot = new Point(500, 0);
            _draftList.Clear();
            var twoPointStub = new TwoPointStub()
            {
                StartPoint = new Point(5, 6),
                EndPoint = new Point(7, 8)
            };
            var multipiontStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 500),
                    new Point(150, 250),
                    refDot
                }
            };
            var draftList = new List<IDrawable>() { twoPointStub, multipiontStub };

            var point = _selector.SearchReferenceDot(refDot, draftList);

            Assert.AreNotSame(refDot, point);
        }

        [Test]
        public void SearchReferenceDotTest_RefDotOwnedTwoPoint()
        {
            SetUp();
            var refDot = new Point(7, 8);
            _draftList.Clear();
            var twoPointStub = new TwoPointStub()
            {
                StartPoint = new Point(5, 6),
                EndPoint = refDot
            };
            var multipiontStub = new MultipointStub()
            {
                DotList = new List<Point>()
                {
                    new Point(0, 500),
                    new Point(150, 250),
                    new Point(500, 0)
                }
            };
            var draftList = new List<IDrawable>() { twoPointStub, multipiontStub };

            var point = _selector.SearchReferenceDot(refDot, draftList);

            Assert.AreNotSame(refDot, point);
        }
    }
}
