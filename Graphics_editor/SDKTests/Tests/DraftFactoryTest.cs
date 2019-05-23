using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using System;
using StructureMap;
using SDKTests.Stubs;
using GraphicsEditor.Tests.Stubs;
using SDKTests.Exceptions;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftFactoryTest
    {
        /// <summary>
        /// Экзмепляр тестируемого класса
        /// </summary>
        private DraftFactory _draftFactory;

        /// <summary>
        /// Тест метода Clone с ненулевым параметром
        /// </summary>
        [Test]
        public void CloneTest_WithClonableStub()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);

            Assert.DoesNotThrow(() =>
            {
                _draftFactory.Clone(new CloneableDraftStub());
            });
        }

        /// <summary>
        /// Тест метода Clone с нулевым параметром
        /// </summary>
        [Test]
        public void CloneTest_WithNull()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                _draftFactory.Clone(null);
            });
        }

        /// <summary>
        /// Тест метода проверки однородности фигур
        /// Ожидается нулевой результат
        /// </summary>
        [Test]
        public void CheckUniformityTest_WithDraftList_ExpectNull()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);
            var draftList = new List<IDrawable>()
            {
                new TwoPointStub(),
                new MultipointStub()
            };

            var result = _draftFactory.CheckUniformity(draftList);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Тест метода проверки однородности, ожидая ненулевой результат
        /// </summary>
        [Test]
        public void CheckUniformityTest_WithDraftList_ExpectNotNull()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);
            var draftList = new List<IDrawable>()
            {
                new TwoPointStub()
            };

            var result = _draftFactory.CheckUniformity(draftList);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Тест метода проверки однородности параметром null
        /// </summary>
        [Test]
        public void CheckUniformityTest_NullDraftList_ExpectNull()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);

            var result = _draftFactory.CheckUniformity(null);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Тест метода создания фигур, ожидая вызов метода контейнера
        /// </summary>
        [Test]
        public void CreateDraftTest_CheckContainerCall_ExpectExeption()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);

            Assert.Throws(typeof(GetInstanceExeption), () =>
            {
                _draftFactory.CreateDraft(null, null, null, System.Drawing.Color.AliceBlue);
            });

        }
    }
}
