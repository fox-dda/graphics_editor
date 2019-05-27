using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Interfaces;
using System.IO;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftSerealizerTest
    {
        [TestCase(TestName = "Сериализация с Stream=null")]
        public void Serealize_TestWithNullStream()
        {
            // Arrange
            var serealizer = new DraftSerealizer();
            var undoRedoStackMock = new Mock<IUndoRedoStack>();

            // Act/Assert
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                serealizer.Serialize(null, undoRedoStackMock.Object);
            });
        }

        [TestCase(TestName = "Десериализация с Stream=null")]
        public void Deserealize_TestWithNullStream()
        {
            // Arrange
            var serealizer = new DraftSerealizer();

            // Act/Assert
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                serealizer.Deserialize(null);
            });
        }
    }
}
