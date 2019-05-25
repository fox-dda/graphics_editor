using NUnit.Framework;
using SDK.Interfaces;
using Moq;
using GraphicsEditor.Engine;
using System.Collections.Generic;
using System;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PenConverterTest
    {
        private PenConventer _penConverter;
        private Mock<IPenSettings> _penSettingMock;

        public void SetUp()
        {
            _penConverter = new PenConventer();
            _penSettingMock = new Mock<IPenSettings>();
        }

        [Test]
        public void ConvertToPen_WithPenSettingsDashPatternNone()
        {
            SetUp();
            _penSettingMock.Setup(x => x.DashPattern).Returns(new float[] { });
            var _penSetting = _penSettingMock.Object;

            Assert.Throws(typeof(ArgumentException), () =>
            {
                var someValue = _penConverter.ConvertToPen(_penSetting);
            });
        }


        [Test]
        public void ConvertToPen_WithPenSettingsDashPattern()
        {
            SetUp();
            _penSettingMock.Setup(x => x.DashPattern).Returns(new float[] { 1, 1 });
            var _penSetting = _penSettingMock.Object;

            try
            {
                var someValue = _penConverter.ConvertToPen(_penSetting);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}