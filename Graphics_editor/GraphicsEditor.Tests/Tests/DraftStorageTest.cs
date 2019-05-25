using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftStorageTest
    {

        [Test]
        public void DraftList_Set()
        {
            var draftStorage = new DraftStorage();

            draftStorage.DraftList = new List<IDrawable>();
        }

        [Test]
        public void DraftList_SetNull()
        {
            var draftStorage = new DraftStorage();

            draftStorage.DraftList = null;
        }

        [Test]
        public void HightlightDrafts_Set()
        {
            var draftStorage = new DraftStorage();

            draftStorage.HighlightDraftsList = new List<IDrawable>();
        }

        [Test]
        public void HightlightDrafts_SetNull()
        {
            var draftStorage = new DraftStorage();

            draftStorage.DraftList = null;
        }

        [Test]
        public void DraftList_Get()
        {
            var draftStorage = new DraftStorage();

            Assert.DoesNotThrow(()=>
            {
                draftStorage.DraftList = new List<IDrawable>();
            });
        }

        [Test]
        public void HightlightDrafts_Get()
        {
            var draftStorage = new DraftStorage();

            Assert.DoesNotThrow(() =>
            {
                draftStorage.HighlightDraftsList = new List<IDrawable>();
            });
        }
    }
}