using NUnit.Framework;
using SDK.Interfaces;
using Moq;
using GraphicsEditor.Core;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PenConverterTest
    {
        [TestCase(TestName ="Конвертирование пера с пыстым дашпаттерном")]
        public void ConvertToPen_WithPenSettingsDashPatternNone()
        {
            // Arrange
            var penConverter = new PenConventer();
            var penSettingMock = new Mock<IPenSettings>();
            penSettingMock.Setup(x => x.DashPattern).Returns(new float[] { });
            var _penSetting = penSettingMock.Object;

            // Act/Assert
            Assert.Throws(typeof(ArgumentException), () =>
            {
                var someValue = penConverter.ConvertToPen(_penSetting);
            });
        }


        [TestCase(TestName = "Конвертирование пера с непустым дашпаттерном")]
        public void ConvertToPen_WithPenSettingsDashPattern()
        {
            // Arrange
            var penConverter = new PenConventer();
            var penSettingMock = new Mock<IPenSettings>();
            penSettingMock.Setup(x => x.DashPattern).Returns(new float[] { 1, 1 });
            var _penSetting = penSettingMock.Object;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var someValue = penConverter.ConvertToPen(_penSetting);
            });
        }
    }
}