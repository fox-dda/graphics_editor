using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Tests.Stubs;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftClipboardTests
    {
        private DraftClipboard DraftClipBoard
        {
            get
            {
                _draftFactoryMock = new Mock<IDraftFactory>();
                return new DraftClipboard(_draftFactoryMock.Object, _draftList);
            }
        }
        private List<IDrawable> _draftList = new List<IDrawable>();
        private Mock<IDraftFactory> _draftFactoryMock;

        [TestCase(TestName = "Запись в буфер списка из трех объектов")]
        public void SetRange_Set3Drafts()
        {
            Mock<IDrawable> draft = new Mock<IDrawable>();
            var draftList = new List<IDrawable>()
            {
                draft.Object, draft.Object, draft.Object
            };

            DraftClipBoard.SetRange(draftList);

            _draftFactoryMock.Verify(x => x.Clone(It.IsAny<IDrawable>()), Times.Exactly(3));
        }

        [TestCase(TestName = "Запись в буфер пустого списка")]
        public void SetRange_Set_Range_With_0_Drafts()
        {
            var draftList = new List<IDrawable>() { };

            DraftClipBoard.SetRange(draftList);

            _draftFactoryMock.Verify(x => x.Clone(It.IsAny<IDrawable>()), Times.Exactly(0));
        }

        [TestCase(TestName = "Получение содержимого буфера с тремя объектами")]
        public void GetAllWith3Drafts()
        {
            _draftList.Add(new TwoPointStub());
            _draftList.Add(new TwoPointStub());
            _draftList.Add(new TwoPointStub());

            var someDraftList = DraftClipBoard.GetAll();

            Assert.AreEqual(someDraftList.Count, 3);
        }

        [TestCase(TestName = "Получение содержимого содержимого пустого буфера")]
        public void GetAll_With_0_Drafts()
        {
            var draftList = new List<IDrawable>() {  };

            var someDraftList = DraftClipBoard.GetAll();

            Assert.IsEmpty(someDraftList);
        }
    }
}
