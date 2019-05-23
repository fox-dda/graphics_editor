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
        private DraftFactory _draftFactory;

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

        [Test]
        public void CheckUniformityTest_NullDraftList_ExpectNull()
        {
            var container = new ContainerStub();
            _draftFactory = new DraftFactory(container);

            var result = _draftFactory.CheckUniformity(null);

            Assert.IsNull(result);
        }

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
