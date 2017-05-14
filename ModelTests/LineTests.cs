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
    public class LineTests
    {
        [TestMethod()]
        public void LineTest()
        {
            Line r = new Line(new Boundary(0, 0, 1, 1));
            Assert.AreEqual(1, r.secondPoint.X);
            Assert.AreEqual(1, r.secondPoint.Y);
        }

        [TestMethod()]
        public void LineTest1()
        {
            Line r = new Line();
            Assert.AreEqual(0, r.secondPoint.X);
            Assert.AreEqual(0, r.secondPoint.Y);
        }

        [TestMethod()]
        public void DrawTest()
        {
            Line r = new Line();
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            r.Draw(w);
            Assert.AreEqual(0, r.secondPoint.X);
            Assert.AreEqual(0, r.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void FillTest()
        {
            Line r = new Line();
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            r.Fill(w);
            Assert.AreEqual(0, r.secondPoint.X);
            Assert.AreEqual(0, r.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Line r = new Line(new Boundary(0, 0, 10, 10));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            r.firstPoint = new Point(2, 2);
            r.secondPoint = new Point(3, 3);
            Assert.IsTrue(r.IsSelect(new Point(1, 1)));
            Assert.IsFalse(r.IsSelect(new Point(20, 20)));
            Assert.IsFalse(r.IsSelect(new Point(0, 20)));
            Assert.IsFalse(r.IsSelect(new Point(0, 20)));

            Line rr = new Line(new Boundary(0, 0, 0, 0));
            rr.firstPoint = new Point(0, 0);
            rr.secondPoint = new Point(0, 0);
            Assert.IsFalse(rr.IsSelect(new Point(0, 0)));
        }

        [TestMethod()]
        public void MoveTest()
        {
            Line r = new Line(new Boundary(0, 0, 10, 10));
            r.firstPoint = new Point(2, 2);
            r.secondPoint = new Point(3, 3);
            r.Move(new Point(1, 1));
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MoveEndTest()
        {
            Line r = new Line(new Boundary(0, 0, 10, 10));
            r.firstPoint = new Point(2, 2);
            r.secondPoint = new Point(3, 3);
            r.Move(new Point(1, 1));
            r.MoveEnd();
            Assert.IsTrue(true);
        }
    }
}