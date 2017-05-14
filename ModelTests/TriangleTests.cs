using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using EzPrintForm;

namespace PaintModel.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void TriangleTest()
        {
            Triangle t = new Triangle(new Boundary(0, 0, 1, 1));
            Assert.AreEqual(0, t.firstPoint.X);
            Assert.AreEqual(0, t.firstPoint.Y);
            Triangle t2 = new Triangle();
        }

        [TestMethod()]
        public void TriangleTest1()
        {
            Triangle t = new Triangle(new Boundary(0, 0, 1, 1));
            Assert.AreEqual(1, t.secondPoint.X);
            Assert.AreEqual(1, t.secondPoint.Y);
        }

        [TestMethod()]
        public void TriangleDrawTest()
        {
            Triangle t = new Triangle(new Boundary(0, 0, 0, 0));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            t.Draw(w);
            Assert.AreEqual(0, t.secondPoint.X);
            Assert.AreEqual(0, t.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void TriangleFillTest()
        {
            Triangle t = new Triangle(new Boundary(0, 0, 0, 0));
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
            Triangle r = new Triangle(new Boundary(0, 0, 10, 10));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            Assert.IsTrue(r.IsSelect(new Point(5, 5)));
            Assert.IsFalse(r.IsSelect(new Point(15, 15)));
            Assert.IsFalse(r.IsSelect(new Point(1, 0)));
            Assert.IsFalse(r.IsSelect(new Point(6, 0)));
        }
    }
}