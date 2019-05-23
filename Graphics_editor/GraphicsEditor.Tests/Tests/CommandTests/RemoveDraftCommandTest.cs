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
    public class RemoveDraftCommandTest
    {
        private RemoveDraftCommand _removeDraftCommand;

        [Test]
        public void DoTest_WithNotNulls()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _removeDraftCommand = new RemoveDraftCommand(draftList, draft);

            _removeDraftCommand.Do();

            Assert.IsEmpty(draftList);
        }

        [Test]
        public void UndoTest_WithNotNull()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _removeDraftCommand = new RemoveDraftCommand(draftList, draft);
            _removeDraftCommand.Do();

            _removeDraftCommand.Undo();

            Assert.Contains(draft, draftList);
        }

        [Test]
        public void DoTest_WithNullList()
        {
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            _removeDraftCommand = new RemoveDraftCommand(null, draft);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _removeDraftCommand.Do();
            });
        }

        [Test]
        public void UndoTest_WithNullList()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _removeDraftCommand = new RemoveDraftCommand(null, draft);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _removeDraftCommand.Undo();
            });
        }

        [Test]
        public void DoTest_WithNullDraft()
        {
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            _removeDraftCommand = new RemoveDraftCommand(draftList, null);

            Assert.DoesNotThrow(() =>
            {
                _removeDraftCommand.Do();
            });
        }

        [Test]
        public void UndoTest_WithNullDraft()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _removeDraftCommand = new RemoveDraftCommand(draftList, null);

            Assert.DoesNotThrow(() =>
            {
                _removeDraftCommand.Undo();
            });
        }
    }
}