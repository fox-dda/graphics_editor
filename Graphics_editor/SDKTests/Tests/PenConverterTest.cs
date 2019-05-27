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
    public class PenConverterTest
    {
        [TestCase(TestName = "Конвертирование пера с пустым дашпаттрном")]
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
                var sameValue = penConverter.ConvertToPen(_penSetting).DashPattern[0];
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
                var someValue = penConverter.ConvertToPen(_penSetting).DashPattern[0];
            });
        }
    }
}