using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Core;
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
        private HighlightRect HighlightRect
        {
            get => new HighlightRect();
        }

        [TestCase(TestName = "Считывание свойства StartPoint")]
        public void StartPointGetTest()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var point = HighlightRect.StartPoint;
            });           
        }

        [TestCase(TestName = "Считывание свойства EndPoint")]
        public void EndPointGetTest()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var point = HighlightRect.EndPoint;
            });
        }

        [TestCase(TestName = "Запись в свойство StartPoint")]
        public void StartPointSetTest()
        {
            // Arrange
            var point = new Point(0, 0);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                HighlightRect.StartPoint = point;
            });
        }

        [TestCase(TestName = "Запись в свойство EndPoint")]
        public void EndPointSetTest()
        {
            // Arrange
            var point = new Point(0, 0);
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                HighlightRect.EndPoint = point;
            });
        }

        [TestCase(TestName = "Запись в свойство Pen")]
        public void PenSetTest()
        {
            // Arrange
            var pen = new PenSettings(Color.Green, 1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                HighlightRect.Pen = pen;
            });
        }

        [TestCase(TestName = "Считываение свойства Pen")]
        public void PenGetTest()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var pen = HighlightRect.Pen;
            });
        }

        [TestCase(TestName = "Метод возврата имени")]
        public void GetNameTest()
        {
            // Act
            var name = HighlightRect.GetName();

            // Assert
            Assert.IsTrue(name == "HighlightRect");
        }
    }
}