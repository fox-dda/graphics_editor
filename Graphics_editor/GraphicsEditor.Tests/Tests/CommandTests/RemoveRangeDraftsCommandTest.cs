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
    public class RemoveRangeDraftsCommandTest
    {
        private RemoveRangeDraftsCommand _removeRangeDraftsCommand;

        [Test]
        public void DoTest_WithNotNulls()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addebleList = new List<IDrawable>() { draft };
            _removeRangeDraftsCommand = new RemoveRangeDraftsCommand(
                draftList, addebleList);

            _removeRangeDraftsCommand.Do();

            Assert.IsEmpty(_removeRangeDraftsCommand.TargetStorage);
        }

        [Test]
        public void UndoTest_WithNotNull()
        {
            var draft = new TwoPointStub();
            var draftList = new List<IDrawable>() { draft };
            var addebleList = new List<IDrawable>() { draft };
            _removeRangeDraftsCommand = new RemoveRangeDraftsCommand(
                draftList, addebleList);
            _removeRangeDraftsCommand.Do();
            _removeRangeDraftsCommand.Undo();

            Assert.Contains(draft,
                _removeRangeDraftsCommand.TargetStorage);
        }

        [Test]
        public void Create_WithNullRemoveList()
        {
            var draftList = new List<IDrawable>();

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _removeRangeDraftsCommand = 
                    new RemoveRangeDraftsCommand(draftList, null);
            });
        }

        [Test]
        public void Create_WithNullTargetList()
        {
            var draftList = new List<IDrawable>();

            Assert.DoesNotThrow( () =>
            {
                _removeRangeDraftsCommand =
                    new RemoveRangeDraftsCommand(null, draftList);
            });
        }
    }
}