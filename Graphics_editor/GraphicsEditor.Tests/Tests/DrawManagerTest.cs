﻿using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using System;
using System.Drawing;
using GraphicsEditor.Enums;
using GraphicsEditor.Engine;
using StructureMap;
using GraphicsEditor.Tests.Stubs;
using GraphicsEditor.Interfaces;
using System.IO;
using System.Windows.Forms;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DrawManagerTest
    {
        private Mock<IDraftPainter> _draftPainterMock;
        private Mock<IStorageManager> _storageManagerMock;
        private Mock<IPainterState> _painterStateMock;
        private Mock<ISelector> _selectorMock;
        private Mock<IUndoRedoStack> _undoRedoStackMock;
        private Mock<IDraftSerealizer> _draftSerealizerMock;
        private DrawManager DrawManager
        {
            get
            {
                _draftPainterMock = new Mock<IDraftPainter>();
                _storageManagerMock = new Mock<IStorageManager>();
                _painterStateMock = new Mock<IPainterState>();
                _selectorMock = new Mock<ISelector>();
                _undoRedoStackMock = new Mock<IUndoRedoStack>();
                _draftSerealizerMock = new Mock<IDraftSerealizer>();

                return new DrawManager(
                    null,
                    _draftPainterMock.Object,
                    _storageManagerMock.Object,
                    _painterStateMock.Object,
                    _selectorMock.Object,
                    _undoRedoStackMock.Object,
                    _draftSerealizerMock.Object);
            }
        }

        [TestCase(TestName = "Изменение цвета канваса")]
        public void EditCanvas_WithSomeColor()
        {
            Color color = Color.AliceBlue;

            DrawManager.EditCanvasColor(color);

            _storageManagerMock.Verify(x => x.EditCanvasColor(
                It.IsAny<IPaintingParameters>(),
                It.IsAny<Color>()), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Перемещение двуточечной фигуры")]
        public void BiasObject_WithTwoPointInput()
        {
            var draftMock = new Mock<IDrawable>();
            var bais = new Point(2, 3);

            DrawManager.BiasObject(draftMock.Object, bais);
            draftMock.VerifySet(x => x.StartPoint = It.IsAny<Point>(), Times.Exactly(1));
            draftMock.VerifySet(x => x.EndPoint = It.IsAny<Point>(), Times.Exactly(1));
        }

        [TestCase(TestName = "Перемещение многоточесной фигуры")]
        public void BiasObject_WithMultiPointInput()
        {
            var multipointStub = new MultipointStub()
            {
                DotList = new List<Point>() {new Point(0, 0),
                    new Point(1, 1)}
            };
            var bais = new Point(2, 3);

            DrawManager.BiasObject(multipointStub, bais);

            Assert.IsFalse(multipointStub.DotList[0].X == 0 &&
                multipointStub.DotList[0].Y == 0);
        }

        [TestCase(TestName = "Перемещение точки в двуточечной фигуре")]
        public void DragDotInDraft_TwopointStub()
        {
            var dragDropingDot = new Point(1, 1);
            var newPoint = new Point(2, 2);
            var draftStub = new TwoPointStub() { StartPoint = dragDropingDot };

            DrawManager.DragDotInDraft(draftStub, dragDropingDot, newPoint);

            Assert.IsTrue(draftStub.StartPoint.X == 2
                && draftStub.StartPoint.Y == 2);
        }

        [TestCase(TestName = "Перемещение точки в многоточечной фигуре")]
        public void DragDotInDraft_WithMultipointInput()
        {
            var dragDropingDot = new Point(1, 1);
            var newPoint = new Point(2, 2);
            var multipointStub = new MultipointStub()
            {
                DotList = new List<Point>() {
                    dragDropingDot,
                    new Point(3, 3),
                    new Point(4, 4)}
            };
            var bais = new Point(2, 3);

            DrawManager.BiasObject(multipointStub, bais);

            Assert.IsFalse(multipointStub.DotList[0].X == 2 &&
                multipointStub.DotList[0].Y == 2);
        }

        [TestCase(TestName = "Сериализация Stream=null")]
        public void Sereailize_TestWithNullStream()
        {
            DrawManager.Serealize(null);

            _draftSerealizerMock.Verify(x => x.Serialize(It.IsAny<Stream>(),
                It.IsAny<IUndoRedoStack>()), Times.Exactly(1));
        }

        [TestCase(TestName = "Десериализация Stream=null")]
        public void Desereailize_TestWithNullStream()
        {
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                DrawManager.Deserialize(null);
            });


            _draftSerealizerMock.Verify(x => x.Deserialize(It.IsAny<Stream>()),
                Times.Exactly(1));
        }

        [TestCase(TestName = "Возрат отмененного действия (Шаг вперед)")]
        public void Redo_Test()
        {
            DrawManager.Redo();

            _storageManagerMock.Verify(x => x.DiscardAll(), Times.Exactly(1));
            _storageManagerMock.Verify(x => x.RedoCommand(), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Отмена последнего действия (Шаг назад)")]
        public void Undo_Test()
        {
            DrawManager.Undo();

            _storageManagerMock.Verify(x => x.DiscardAll(), Times.Exactly(1));
            _storageManagerMock.Verify(x => x.UndoCommand(), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Вырезание объекта с канвы")]
        public void Cut_Test()
        {
            var bufferMock = new Mock<IDraftClipboard>();

            DrawManager.Cut(bufferMock.Object);

            bufferMock.Verify(x => x.SetRange(It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _storageManagerMock.Verify(x => x.RemoveRangeHighlightDrafts(), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Копирование объекта на канве")]
        public void Copy_Test()
        {
            var bufferMock = new Mock<IDraftClipboard>();

            DrawManager.Copy(bufferMock.Object);

            bufferMock.Verify(x => x.SetRange(It.IsAny<List<IDrawable>>()), Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Вставка объекта на канву")]
        public void Paste_Test()
        {
            var bufferMock = new Mock<IDraftClipboard>();

            DrawManager.Paste(bufferMock.Object);

            _storageManagerMock.Verify(x => x.AddRangeDrafts(It.IsAny<List<IDrawable>>()),
                Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
            bufferMock.Verify(x => x.GetAll(), Times.Exactly(1));
        }

        [TestCase(TestName = "Удаление объекта с канвы")]
        public void Remove_Test()
        {
            DrawManager.Remove();

            _storageManagerMock.Verify(x => x.RemoveRangeHighlightDrafts(),
                Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Создание нового проекта")]
        public void CreateNewProject_Test()
        {
            DrawManager.CreateNewProject();

            _storageManagerMock.Verify(x => x.ClearHistory(),
                Times.Exactly(1));
            _draftPainterMock.Verify(x => x.RefreshCanvas(), Times.Exactly(1));
        }

        [TestCase(TestName = "Записть в свойство CommandStack")]
        public void CommandStack_Get()
        {
            Assert.DoesNotThrow(() =>
            {
                var stack = DrawManager.CommandStack;
            });
        }

        [TestCase((char)3, TestName = "Обработка нажатия сочетания <Ctrl+С>")]
        [TestCase((char)22, TestName = "Обработка нажатия сочетания <Ctrl+V>")]
        [TestCase((char)4, TestName = "Обработка нажатия сочетания <Ctrl+D>")]
        [TestCase((char)24, TestName = "Обработка нажатия сочетания <Ctrl+X>")]
        [TestCase((char)26, TestName = "Обработка нажатия сочетания <Ctrl+Z>")]
        [TestCase((char)25, TestName = "Обработка нажатия сочетания <Ctrl+Y>")]
        public void KeyProcessTest_PressAny(char buttonCode)
        {
            var arg = new KeyPressEventArgs(buttonCode);
            var clipBoardMock = new Mock<IDraftClipboard>();

            Assert.DoesNotThrow(() =>
            {
                DrawManager.KeyProcess(arg, clipBoardMock.Object);
            });
        }


        [TestCase(MouseAction.Down, TestName = "Обработка нажатия мыши многоточечной стратегией")]
        public void MouseProcessTest_WithMultipointStrategy_NotException(MouseAction mouseAction)
        {
            var manager = DrawManager;
            _painterStateMock.Setup(x => x.DrawingStrategy)
                .Returns(Strategy.Multipoint);
            var mouseArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            Assert.DoesNotThrow( () =>
            {
                manager.MouseProcess(mouseArgs, mouseAction);
            });
        }

        [TestCase(MouseAction.Move, TestName = "Обработка перемещения мыши многоточечной стратегией")]
        [TestCase(MouseAction.Up, TestName = "Обработка отжатия мыши многоточечной стратегией")]
        public void MouseProcessTest_WithMultipointStrategy_Exception(MouseAction mouseAction)
        {
            var manager = DrawManager;
            _painterStateMock.Setup(x => x.DrawingStrategy)
                .Returns(Strategy.Multipoint);
            var mouseArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                manager.MouseProcess(mouseArgs, mouseAction);
            });
        }

        [TestCase(MouseAction.Down, TestName = "Обработка нажатия мыши стратегией выделения")]
        [TestCase(MouseAction.Move, TestName = "Обработка перемещения мыши стратегией выделения")]
        [TestCase(MouseAction.Up, TestName = "Обработка отжатия мыши стратегией выделения")]
        public void MouseProcessTest_WithSelectiontStrategy(MouseAction mouseAction)
        {
            var manager = DrawManager;
            _painterStateMock.Setup(x => x.DrawingStrategy)
                .Returns(Strategy.Selection);
            var mouseArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                manager.MouseProcess(mouseArgs, mouseAction);
            });
        }
        
        [TestCase(MouseAction.Down, TestName = "Обработка нажатия мыши стратегией DragAndDrop")]
        [TestCase(MouseAction.Move, TestName = "Обработка перемещения мыши стратегией DragAndDrop")]
        [TestCase(MouseAction.Up, TestName = "Обработка отжатия мыши стратегией DragAndDrop")]
        public void MouseProcessTest_WithDragAndDropStrategy(MouseAction mouseAction)
        {
            var manager = DrawManager;
            _painterStateMock.Setup(x => x.DrawingStrategy)
                .Returns(Strategy.DragAndDrop);
            var mouseArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            Assert.DoesNotThrow( () =>
            {
                manager.MouseProcess(mouseArgs, mouseAction);
            });
        }

        [TestCase(MouseAction.Down, TestName = "Обработка нажатия мыши двуточечной стратегией")]
        [TestCase(MouseAction.Move, TestName = "Обработка перемещения мыши двуточечной стратегией")]
        [TestCase(MouseAction.Up, TestName = "Обработка отжатия мыши двуточечной стратегией")]
        public void MouseProcessTest_WithTwoPointStrategy(MouseAction mouseAction)
        {
            var manager = DrawManager;
            _painterStateMock.Setup(x => x.DrawingStrategy)
                .Returns(Strategy.TwoPoint);
            var mouseArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                manager.MouseProcess(mouseArgs, mouseAction);
            });      
        }
    }
}
