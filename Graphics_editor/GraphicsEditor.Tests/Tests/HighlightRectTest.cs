using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Enums;
using System;
using GraphicsEditor.Model;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class HighlightRectTest
    {
        [Test]
        public void StartPointGetTest()
        {
            var rect = new HighlightRect();

            Assert.DoesNotThrow(() =>
            {
                var point = rect.StartPoint;
            });           
        }

        [Test]
        public void EndPointGetTest()
        {
            var rect = new HighlightRect();

            Assert.DoesNotThrow(() =>
            {
                var point = rect.EndPoint;
            });
        }

        [Test]
        public void StartPointSetTest()
        {
            var rect = new HighlightRect();
            var point = new Point(0, 0);

            Assert.DoesNotThrow(() =>
            {
                rect.StartPoint = point;
            });
        }

        [Test]
        public void EndPointSetTest()
        {
            var rect = new HighlightRect();
            var point = new Point(0, 0);

            Assert.DoesNotThrow(() =>
            {
                rect.EndPoint = point;
            });
        }

        [Test]
        public void PenSetTest()
        {
            var rect = new HighlightRect();
            var pen = new PenSettings(Color.Green, 1);

            Assert.DoesNotThrow(() =>
            {
                rect.Pen = pen;
            });
        }

        [Test]
        public void PenGetTest()
        {
            var rect = new HighlightRect();

            Assert.DoesNotThrow(() =>
            {
                var pen = rect.Pen;
            });
        }

        [Test]
        public void GetNameTest()
        {
            var rect = new HighlightRect();

            var name = rect.GetName();

            Assert.IsTrue(name == "HighlightRect");
        }
    }
}