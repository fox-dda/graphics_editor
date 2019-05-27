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
        private DraftStorage DraftStorage
        {
            get
            {
                return new DraftStorage();
            }
        }


        [TestCase(TestName = "Запись в свойство DraftList")]
        public void DraftList_Set()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                DraftStorage.DraftList = new List<IDrawable>();
            });
        }

        [TestCase(TestName = "Запись null в свойство DraftList")]
        public void DraftList_SetNull()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                DraftStorage.DraftList = null;
            });
        }

        [TestCase(TestName = "Запись в свойство HightlightDraftsList")]
        public void HightlightDrafts_Set()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                DraftStorage.HighlightDraftsList = new List<IDrawable>();
            });           
        }

        [TestCase(TestName = "Запись null в свойство HightlightDraftsList")]
        public void HightlightDrafts_SetNull()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                DraftStorage.DraftList = null;
            });           
        }

        [TestCase(TestName = "Получение значения свойства DraftList")]
        public void DraftList_Get()
        {
            // Act/Assert
            Assert.DoesNotThrow(()=>
            {
                var draftList = DraftStorage.DraftList;
            });
        }

        [TestCase(TestName = "Получение значения свойства HighlightDraftsList")]
        public void HightlightDrafts_Get()
        {
            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var draftList = DraftStorage.HighlightDraftsList;
            });
        }
    }
}