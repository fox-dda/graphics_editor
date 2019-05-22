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
    public class AddRangeDraftsCommandTest
    {
        private AddRangeDraftCommand _addDraftCommand;

        [Test]
        public void DoTest_WithNotNulls()
        {
            var draftList = new List<IDrawable>();
            var addebleList = new List<IDrawable>() { new TwoPointStub() };
            _addDraftCommand = new AddRangeDraftCommand(draftList, addebleList);

            _addDraftCommand.Do();

            Assert.IsNotEmpty(_addDraftCommand.TargetStorage);
        }

        [Test]
        public void UndoTest_WithNotNull()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addebleList = new List<IDrawable>() { draft };
            _addDraftCommand = new AddRangeDraftCommand(draftList, addebleList);

            _addDraftCommand.Undo();

            Assert.IsEmpty(_addDraftCommand.TargetStorage);
        }

        [Test]
        public void DoTest_WithNullAddList()
        {
            var draftList = new List<IDrawable>();
            
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _addDraftCommand = new AddRangeDraftCommand(draftList, null);
                _addDraftCommand.Do();
            });
        }

        [Test]
        public void UndoTest_WithNullAddList()
        {
            var draftList = new List<IDrawable>();          

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _addDraftCommand = new AddRangeDraftCommand(draftList, null);
                _addDraftCommand.Undo();
            });
        }

        [Test]
        public void DoTest_WithNullDraft()
        {
            var draft = new TwoPointStub();
            var addebleList = new List<IDrawable>() { draft };
            _addDraftCommand = new AddRangeDraftCommand(null, addebleList);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _addDraftCommand.Do();
            });
        }

        [Test]
        public void UndoTest_WithNullDraft()
        {
            var draft = new TwoPointStub();
            var addebleList = new List<IDrawable>() { draft };
            _addDraftCommand = new AddRangeDraftCommand(null, addebleList);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _addDraftCommand.Undo();
            });
        }
    }
}