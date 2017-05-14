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
    public class ShapeTests
    {
        [TestMethod()]
        public void ShapeTest()
        {
            Shape shape = new Shape();
            Assert.AreEqual(0, shape.firstPoint.X);
            Assert.AreEqual(0, shape.firstPoint.Y);
        }

        [TestMethod()]
        public void ShapeTest1()
        {
            Shape shape = new Shape(new Boundary(0, 0, 1, 1));
            Assert.AreEqual(0, shape.firstPoint.X);
            Assert.AreEqual(0, shape.firstPoint.Y);
            Point p = new Point(1, 1);
            shape.firstPoint = p;
            Assert.AreEqual(1, shape.firstPoint.X);
            Assert.AreEqual(1, shape.firstPoint.Y);
            Point p2 = new Point(2, 2);
            shape.secondPoint = p2;
            Assert.AreEqual(2, shape.secondPoint.X);
            Assert.AreEqual(2, shape.secondPoint.Y);
        }

        [TestMethod()]
        public void ShapeDrawTest()
        {
            Shape t = new Shape(new Boundary(0, 0, 0, 0));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            t.Draw(w);
            Assert.AreEqual(0, t.secondPoint.X);
            Assert.AreEqual(0, t.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ShapeFillTest()
        {
            Shape t = new Shape(new Boundary(0, 0, 0, 0));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            t.Fill(w);
            Assert.AreEqual(0, t.secondPoint.X);
            Assert.AreEqual(0, t.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Shape t = new Shape(new Boundary(0, 0, 10, 10));
            t.firstPoint = new Point(2, 2);
            t.secondPoint = new Point(3, 3);
            Assert.IsFalse(t.IsSelect(new Point(1,1)));
        }

        [TestMethod()]
        public void MoveTest()
        {
            Shape t = new Shape(new Boundary(0, 0, 10, 10));
            t.firstPoint = new Point(2, 2);
            t.secondPoint = new Point(3, 3);
            t.Move(new Point(1,1));
            Assert.IsFalse(t.IsSelect(new Point(1, 1)));
        }

        [TestMethod()]
        public void MoveEndTest()
        {
            Shape t = new Shape(new Boundary(0, 0, 10, 10));
            t.firstPoint = new Point(2, 2);
            t.secondPoint = new Point(3, 3);
            t.Move(new Point(1, 1));
            t.MoveEnd();
            Assert.IsFalse(t.IsSelect(new Point(1, 1)));
        }
    }
}