using EzPrintForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel.Tests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod()]
        public void ModelTest()
        {
            Model m = new Model();
            Assert.IsTrue(true);
        }

        //[TestMethod()]
        //public void DrawTest()
        //{
        //    不測
        //}

        [TestMethod()]
        public void MouseDownTest()
        {
            Model m = new Model();
            m.MouseDown(new Point(2, 2));
            m.MouseMove(new Point(1, 1));
            m.MouseUp();
            Assert.IsTrue(m.IsUndoEnabled);
            Assert.IsFalse(m.IsRedoEnabled);
            m.MouseDown(new Point(0, 0));
            m.MouseMove(new Point(10,10));
            m.MouseUp();
            m.MouseDown(new Point(5, 5));
            m.MouseMove(new Point(6, 6));
            m.MouseUp();
        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            Model m = new Model();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 21));
            m.MouseUp();
            Assert.IsTrue(m.IsUndoEnabled);
            Assert.IsFalse(m.IsRedoEnabled);
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            Model m = new Model();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            Assert.IsTrue(m.IsUndoEnabled);
            Assert.IsFalse(m.IsRedoEnabled);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            Model m = new Model();
            m.DrawShape(new Shape());
            Assert.IsFalse(m.IsRedoEnabled);
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            Model m = new Model();
            m.DeleteShape();
            Assert.IsFalse(m.IsRedoEnabled);
        }

        [TestMethod()]
        public void SetShapeTest()
        {
            Model m = new Model();
            m._modelChange += func;
            m.SetShape(-1);
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.SetShape(0);
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.SetShape(1);
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.SetShape(2);
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.SetShape(3);
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.MouseDown(new Point(0, 0));

            m.SetShape(4);
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.MouseDown(new Point(0, 0));
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void SaveTest()
        {
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor((new DoubleBufferedPanel()).CreateGraphics());
            Model m = new Model();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.Save(w);
        }

        [TestMethod()]
        public void DrawTest()
        {
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor((new DoubleBufferedPanel()).CreateGraphics());
            Model m = new Model();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.Draw(w);
        }

        [TestMethod()]
        public void UndoTest()
        {
            Model m = new Model();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            Assert.IsTrue(m.IsUndoEnabled);
            m.Undo();
            Assert.IsFalse(m.IsUndoEnabled);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Model m = new Model();
            m.MouseDown(new Point(1, 1));
            m.MouseMove(new Point(2, 2));
            m.MouseUp();
            Assert.IsTrue(m.IsUndoEnabled);
            m.Undo();
            Assert.IsFalse(m.IsUndoEnabled);
            m.Redo();
            Assert.IsFalse(m.IsRedoEnabled);
        }

        private void func()
        {
            
        }
    }
}