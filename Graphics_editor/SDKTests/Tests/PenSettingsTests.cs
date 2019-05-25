using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using System;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PenSettingsTest
    {
        private PenSettings _penSettings;

        [TestCase(float.MaxValue, float.MaxValue)]
        [TestCase(float.MinValue, float.MinValue)]
        [TestCase(float.MinValue, float.MaxValue)]
        [TestCase(float.MaxValue, float.MinValue)]
        public void DashPattertSetTest(float dashValue, float spaceValue)
        {
            _penSettings = new PenSettings(Color.Wheat, 1);

            Assert.DoesNotThrow(() => 
            {
                _penSettings.DashPattern = new float[] { dashValue, spaceValue };
            });
        }

        [Test]
        public void DashPattertGetTest()
        {
            _penSettings = new PenSettings(Color.Wheat, 1);

            Assert.DoesNotThrow(() =>
            {
                var pattern = _penSettings.DashPattern;
            });
        }


        [TestCase(0)]
        [TestCase(float.MinValue)]
        [TestCase(float.MaxValue)]
        public void WidthSetTest(float width)
        {
            _penSettings = new PenSettings(Color.Wheat, 1);

            Assert.DoesNotThrow(() =>
            {
                _penSettings.Width = width;
            });
        }

        [Test]
        public void WidthGetTest()
        {
            _penSettings = new PenSettings(Color.Wheat, 1);

            Assert.DoesNotThrow(() =>
            {
                var penWidth = _penSettings.Width;
            });
        }

        [Test]
        public void ColorSetTest()
        {
            _penSettings = new PenSettings(Color.Wheat, 1);

            Assert.DoesNotThrow(() =>
            {
                _penSettings.Color = Color.Green;
            });
        }

        [Test]
        public void ColorGetTest()
        {
            _penSettings = new PenSettings(Color.Wheat, 1);

            Assert.DoesNotThrow(() =>
            {
                var color = _penSettings.Color;
            });
        }
    }
}