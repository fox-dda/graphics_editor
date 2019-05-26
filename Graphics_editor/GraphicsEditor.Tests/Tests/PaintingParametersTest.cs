using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Enums;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PaintingParametersTest
    {
        private Mock<IPenSettings> _penSettingsMock;
        private PaintingParameters PaintingsParameters
        {
            get
            {
                _penSettingsMock = new Mock<IPenSettings>();
                return new PaintingParameters(_penSettingsMock.Object);
            }
        }

        [TestCase(new float[] { float.MaxValue, float.MaxValue }, 
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new float[] { float.MaxValue, float.MinValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new float[] { float.MinValue, float.MaxValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new float[] { float.MinValue, float.MinValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new float[] { 0, 0 })]
        public void DashPatternProperty_SetAny(float[] inputPattern)
        {
            Assert.DoesNotThrow(() =>
            {
                PaintingsParameters.DashPattern = inputPattern;
            });
        }

        [TestCase(TestName = "Считывание свойства DashPattern")]
        public void DashPatternProperty_GetWhenPropertyIsZero_ExpectNullInCaches()
        {
            var parameters = PaintingsParameters;

            parameters.DashPattern = new float[] {0, 100};

            Assert.IsNull(parameters.DashPattern);
        }


        [TestCase(TestName = "Запись в свойство BrushColor")]
        public void BrushColorTestSet()
        {
            var parameters = PaintingsParameters;

            parameters.BrushColor = System.Drawing.Color.AliceBlue;

            Assert.IsNotNull(parameters.BrushColor);
        }

        [TestCase(TestName = "Запись в свойство CanvasColor")]
        public void CanvasColorTestSet()
        {
            var parameters = PaintingsParameters;

            parameters.CanvasColor = System.Drawing.Color.AliceBlue;

            Assert.IsNotNull(parameters.CanvasColor);
        }

        [TestCase(TestName = "Считывание из свойства BrushColor")]
        public void BrushColorTestGet()
        {
            var parameters = PaintingsParameters;

            parameters.BrushColor = System.Drawing.Color.AliceBlue;

            Assert.DoesNotThrow(() =>
            {
                var color = parameters.BrushColor;
            });
        }

        [TestCase(TestName = "Считывание из свойства CanvasColor")]
        public void CanvasColorTestGet()
        {
            var parameters = PaintingsParameters;

            parameters.CanvasColor = System.Drawing.Color.AliceBlue;

            Assert.DoesNotThrow(() =>
            {
                var color = parameters.CanvasColor;
            });
        }
    }
}