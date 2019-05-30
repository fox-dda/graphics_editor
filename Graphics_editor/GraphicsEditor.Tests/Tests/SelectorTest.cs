using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using System;
using System.Drawing;
using GraphicsEditor.Tests.Stubs;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class SelectorTest
    {
        private List<Mock<IDrawable>> _draftMockList;
        private List<IDrawable> _draftList;
        private Selector Selector
        {
            get
            {
                Random randomGenerator = new Random();
                _draftList = new List<IDrawable>();
                _draftMockList = new List<Mock<IDrawable>>();

                for (int i = 0; i != 20; i++)
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
                return new Selector();
            }
        }

        [TestCase(0, 0,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(0, 500,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(500, 0,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(500, 500,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(0, 1,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(1, 0,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(499, 0,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        [TestCase(0, 499,
            TestName = "Поиск по точке двуточечной фигуры, ожидая результат null")]
        public void PointSearch_TestWithDoublePointDrafts_ExpectNullReturn(
            int xDot, int yDot)
        {
            // Arrange
            var selector = Selector;
            var draftMock = new Mock<IDrawable>();
            draftMock.Setup(x => x.StartPoint).Returns(
                new Point(0, 500));
            draftMock.Setup(x => x.EndPoint).Returns(
                 new Point(500, 00));
            _draftList.Add(draftMock.Object);

            // Act
            var rezultDraft = selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            // Assert
            Assert.IsNull(rezultDraft);
        }


        [TestCase(1, 1,
            TestName = "Поиск по точке двуточечной фигуры, ожидая ненулевой результат")]
        [TestCase(499, 499,
            TestName = "Поиск по точке двуточечной фигуры, ожидая ненулевой результат")]
        [TestCase(499, 1,
            TestName = "Поиск по точке двуточечной фигуры, ожидая ненулевой результат")]
        [TestCase(1, 499,
            TestName = "Поиск по точке двуточечной фигуры, ожидая ненулевой результат")]
        public void PointSearch_TestWithDoublePointDrafts_ExpectNotNullReturn(
            int xDot, int yDot)
        {
            // Arrange
            var selector = Selector;
            var draftMock = new Mock<IDrawable>();
            draftMock.Setup(x => x.StartPoint).Returns(
                new Point(0, 500));
            draftMock.Setup(x => x.EndPoint).Returns(
                 new Point(500, 0));
            _draftList.Add(draftMock.Object);

            // Act
            var rezultDraft = selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            // Assert
            Assert.IsNotNull(rezultDraft);
        }

        [TestCase(1, 1,
            TestName = "Поиск по точке многоточечной фигуры, ожидая ненулевой результат")]
        [TestCase(499, 499,
            TestName = "Поиск по точке многоточечной фигуры, ожидая ненулевой результат")]
        [TestCase(499, 1,
            TestName = "Поиск по точке многоточечной фигуры, ожидая ненулевой результат")]
        [TestCase(1, 499,
            TestName = "Поиск по точке многоточечной фигуры, ожидая ненулевой результат")]
        public void PointSearch_TestWithMultipointDrafts_ExpectNotNullReturn(
           int xDot, int yDot)
        {
            // Arrange
            var selector = Selector;
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

            // Act
            var rezultDraft = selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            // Assert
            Assert.IsNotNull(rezultDraft);
        }

        [TestCase(0, 0,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(0, 500,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(500, 0,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(500, 500,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(0, 1,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(1, 0,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(499, 0,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        [TestCase(0, 499,
            TestName = "Поиск по точке многоточечной фигуры, ожидая результат null")]
        public void PointSearch_TestWithMultipointDrafts_ExpectNullReturn(
          int xDot, int yDot)
        {
            // Arrange
            var selector = Selector;
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

            // Act
            var rezultDraft = selector.PointSearch(
                new Point(xDot, yDot), _draftList);

            // Assert
            Assert.IsNull(rezultDraft);
        }

        /// <summary>
        /// Тест поиска в лассо, ожидая результатом пустой список
        /// NUnit не позволяет давать атрибут TestName тестам, использующим Range
        /// </summary>
        /// <param name="startXDot"></param>
        /// <param name="startYDot"></param>
        /// <param name="endXDot"></param>
        /// <param name="endYDot"></param>
        [Test]
        public void LassoSearch_TestWithMultipointDrafts_ExpectEmptyReturn(
            [Range(0, 3)] int startXDot,
            [Range(0, 3)] int startYDot,
            [Range(0, 3)] int endXDot,
            [Range(0, 3)] int endYDot)
        {
            // Arrange
            var selector = Selector;
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

            // Act
            var rezultDraft = selector.LassoSearch(
                lasso, _draftList);

            // Assert
            Assert.IsEmpty(rezultDraft);
        }

        [TestCase(-1, -1, 501, 501, TestName ="Поиск в ласо, ожидая непустой список")]
        public void LassoSearch_TestWithMultipointDrafts_ExpectNotImptyListReturn(
           int startXDot, int startYDot, int endXDot, int endYDot)
        {
            // Arrange
            var selector = Selector;
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

            // Act
            var rezultDraft = selector.LassoSearch(
                lasso, _draftList);

            // Assert
            Assert.IsNotEmpty(rezultDraft);
        }

        [TestCase(TestName ="Поиск опорной точки многоточечной фигуры")]
        public void SearchReferenceDotTest_RefDotOwnedMultipoint()
        {
            // Arrange
            var selector = Selector;
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

            // Act
            var point = selector.SearchReferenceDot(refDot, draftList);

            // Assert
            Assert.AreNotSame(refDot, point);
        }

        [TestCase(TestName = "Поиск опорной точки двуточечной фигуры")]
        public void SearchReferenceDotTest_RefDotOwnedTwoPoint()
        {
            // Arrange
            var selector = Selector;
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

            // Act
            var point = selector.SearchReferenceDot(refDot, draftList);

            // Assert
            Assert.AreNotSame(refDot, point);
        }
    }
}
