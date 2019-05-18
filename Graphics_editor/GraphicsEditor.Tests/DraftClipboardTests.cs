using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftClipboardTests
    {
        private DraftClipboard _draftClipBoard;
        private IDrawable _draft;
        private List<IDrawable> _draftList = new List<IDrawable>();
        private Mock<IDraftFactory> _draftFactoryMock;

        [SetUp]
        public void SetUp()
        {
            _draftFactoryMock = new Mock<IDraftFactory>();
            Mock<IDrawable> draft = new Mock<IDrawable>();
            _draft = draft.Object;
            _draftClipBoard = new DraftClipboard(_draftFactoryMock.Object, _draftList);
            //_draftFactoryMock
            //    .Setup(x => x.Clone(It.IsAny<IDrawable>()))
            //    .Returns<IDrawable>(null);
        }

        [Test]
        public void SetRange_Set3Drafts()
        {
            var draftList = new List<IDrawable>() { _draft, _draft, _draft };

            _draftClipBoard.SetRange(draftList);

            // Проверка: Вызвался ли метод Clone в точности 3 раза возвращая тип IDrawable
            _draftFactoryMock.Verify(x => x.Clone(It.IsAny<IDrawable>()), Times.Exactly(3));
        }

        [Test]
        public void SetRange_Set_Range_With_0_Drafts()
        {
            var draftList = new List<IDrawable>() { };

            _draftClipBoard.SetRange(draftList);

            // Проверка: Вызвался ли метод Clone в точности 0 раза возвращая тип IDrawable
            _draftFactoryMock.Verify(x => x.Clone(It.IsAny<IDrawable>()), Times.Exactly(0));
        }

        [Test]
        public void GetAllWith3Drafts()
        {
            _draftList.Add(_draft);
            _draftList.Add(_draft);
            _draftList.Add(_draft);

            var someDraftList = _draftClipBoard.GetAll();

            Assert.AreEqual(someDraftList.Count, 3);
        }

        [Test]
        public void GetAll_With_0_Drafts()
        {
            var draftList = new List<IDrawable>() {  };

            var someDraftList = _draftClipBoard.GetAll();

            Assert.IsEmpty(someDraftList);
        }
    }
}
