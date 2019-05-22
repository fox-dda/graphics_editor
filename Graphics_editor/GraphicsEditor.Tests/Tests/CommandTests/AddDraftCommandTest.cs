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
    public class AddDraftCommandTest
    {
        private AddDraftCommand _addDraftCommand;

        [Test]
        public void DoTest_WithNotNulls()
        {
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            _addDraftCommand = new AddDraftCommand(draftList, draft);

            _addDraftCommand.Do();

            Assert.Contains(draft, draftList);
        }

        [Test]
        public void UndoTest_WithNotNull()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _addDraftCommand = new AddDraftCommand(draftList, draft);

            _addDraftCommand.Undo();

            Assert.IsFalse( draftList.Contains(draft));
        }

        [Test]
        public void DoTest_WithNullList()
        {
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            _addDraftCommand = new AddDraftCommand(null, draft);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _addDraftCommand.Do();
            });          
        }

        [Test]
        public void UndoTest_WithNullList()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _addDraftCommand = new AddDraftCommand(null, draft);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _addDraftCommand.Undo();
            });
        }

        [Test]
        public void DoTest_WithNullDraft()
        {
            var draftList = new List<IDrawable>();
            var draft = new TwoPointStub();
            _addDraftCommand = new AddDraftCommand(draftList, null);

            Assert.DoesNotThrow( () =>
            {
                _addDraftCommand.Do();
            });
        }

        [Test]
        public void UndoTest_WithNullDraft()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            _addDraftCommand = new AddDraftCommand(draftList, null);

            Assert.DoesNotThrow( () =>
            {
                _addDraftCommand.Undo();
            });
        }
    }
}