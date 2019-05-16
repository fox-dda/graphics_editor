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
        private PaintingParameters _paintingsParameters;
        Mock<IPenSettings> _penSettingsMock;

        [SetUp]
        public void SetUp()
        {
            _penSettingsMock = new Mock<IPenSettings>();
            _paintingsParameters = new PaintingParameters(_penSettingsMock.Object);
        }

        [Test]
        public void DashPatternProperty_SetAny_ExpectNullInCaches(
            [Values(new float[]{float.MaxValue, float.MaxValue},
                    new float[]{float.MaxValue, float.MinValue},
                    new float[]{float.MinValue, float.MaxValue},
                    new float[]{float.MinValue, float.MinValue},
                    new float[]{0, 0})]
             float[] inputPattern)
        {
            _paintingsParameters.DashPattern = inputPattern;
        }

        [Test]
        public void DashPatternProperty_GetWhenPropertyIsZiro_ExpectNullInCaches()
        {
            _paintingsParameters.DashPattern = new float[] {0, 100};

            Assert.IsNull(_paintingsParameters.DashPattern);
        }
    }
}