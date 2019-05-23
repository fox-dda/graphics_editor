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
        private PenConventer _penConverter;
        private Mock<IPenSettings> _penSettingMock;

        /// <summary>
        /// Инициализация сущностей для последующего тестирования
        /// </summary>
        public void SetUp()
        {
            _penConverter = new PenConventer();
            _penSettingMock = new Mock<IPenSettings>();
        }

        /// <summary>
        /// Тест конвертирвания пера с пустым дашпаттерном
        /// </summary>
        [Test]
        public void ConvertToPen_WithPenSettingsDashPatternNone()
        {
            SetUp();
            _penSettingMock.Setup(x => x.DashPattern).Returns(new float[] { });
            var _penSetting = _penSettingMock.Object;

            Assert.Throws(typeof(ArgumentException), () =>
            {
                var sameValue = _penConverter.ConvertToPen(_penSetting).DashPattern[0];
            });
        }

        /// <summary>
        /// Тест конвертирования пера с непустым дашпаттерном
        /// </summary>
        [Test]
        public void ConvertToPen_WithPenSettingsDashPattern()
        {
            SetUp();
            _penSettingMock.Setup(x => x.DashPattern).Returns(new float[] { 1, 1 });
            var _penSetting = _penSettingMock.Object;

            Assert.DoesNotThrow(() => 
            {
                var someValue = _penConverter.ConvertToPen(_penSetting).DashPattern[0];
            });
        }
    }
}