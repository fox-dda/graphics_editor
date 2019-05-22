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

        [Test]
        public void Serealize_TestWithNullStream()
        {
            var serealizer = new DraftSerealizer();
            var undoRedoStackMock = new Mock<IUndoRedoStack>();

            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                serealizer.Serialize(null, undoRedoStackMock.Object);
            });
        }

        [Test]
        public void Deserealize_TestWithNullStream()
        {
            var serealizer = new DraftSerealizer();

            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                serealizer.Deserialize(null);
            });
        }
    }
}
