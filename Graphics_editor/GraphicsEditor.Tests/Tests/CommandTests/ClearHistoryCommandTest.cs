using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine.UndoRedo.Commands;
using GraphicsEditor.Tests.Stubs;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class ClearHistoryCommandTest
    {
        private ClearStorageCommand _clearHistoryCommand;

        [Test]
        public void DoTest_WithNotNulls()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _clearHistoryCommand = new ClearStorageCommand(draftList);

            _clearHistoryCommand.Do();

            Assert.IsEmpty(_clearHistoryCommand.TargetStorage);
        }

        [Test]
        public void UndoTest_WithNotNulls()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _clearHistoryCommand = new ClearStorageCommand(draftList);
            _clearHistoryCommand.Do();

            _clearHistoryCommand.Undo();

            Assert.Contains(draft, _clearHistoryCommand.TargetStorage);
        }

        [Test]
        public void CreateCommandTest_WithNullStorage()
        {
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _clearHistoryCommand = new ClearStorageCommand(null);
            });
        }

    }
}
