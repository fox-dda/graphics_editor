using NUnit.Framework;
using SDK;
using System.Drawing;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PenSettingsTest
    {
        [TestCase(float.MaxValue, float.MaxValue,
            TestName = "Запись в свойство DashPattern float.MaxValue, float.MaxValue")]
        [TestCase(float.MinValue, float.MinValue,
            TestName = "Запись в свойство DashPattern float.MinValue, float.MinValue")]
        [TestCase(float.MinValue, float.MaxValue,
            TestName = "Запись в свойство DashPattern MinValue, float.MaxValue")]
        [TestCase(float.MaxValue, float.MinValue,
            TestName = "Запись в свойство DashPattern float.MaxValue, float.MinValue")]
        public void DashPattertSetTest(float dashValue, float spaceValue)
        {
            // Arrange
            var penSettings = new PenSettings(Color.Wheat, 1);

            // Act/Assert
            Assert.DoesNotThrow(() => 
            {
                penSettings.DashPattern = new float[] { dashValue, spaceValue };
            });
        }

        [TestCase(TestName ="Считывание свойства DashPattern")]
        public void DashPattertGetTest()
        {
            // Arrange
            var penSettings = new PenSettings(Color.Wheat, 1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var pattern = penSettings.DashPattern;
            });
        }


        [TestCase(0, TestName = "Запись в свойство Width 0")]
        [TestCase(float.MinValue, TestName = "Запись в свойство Width float.MinValue")]
        [TestCase(float.MaxValue, TestName = "Запись в свойство Width float.MaxValue")]
        public void WidthSetTest(float width)
        {
            // Arrange
            var penSettings = new PenSettings(Color.Wheat, 1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                penSettings.Width = width;
            });
        }

        [TestCase(TestName = "Считывание свойства Width")]
        public void WidthGetTest()
        {
            // Arrange
            var penSettings = new PenSettings(Color.Wheat, 1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var penWidth = penSettings.Width;
            });
        }

        [TestCase(TestName = "Запись в свойство Color")]
        public void ColorSetTest()
        {
            // Arrange
            var penSettings = new PenSettings(Color.Wheat, 1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                penSettings.Color = Color.Green;
            });
        }

        [TestCase(TestName = "Считывание свойства Color")]
        public void ColorGetTest()
        {
            // Arrange
            var penSettings = new PenSettings(Color.Wheat, 1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var color = penSettings.Color;
            });
        }
    }
}