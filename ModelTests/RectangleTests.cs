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
    public class RectangleTests
    {
        [TestMethod()]
        public void RectangleTest()
        {
            Rectangle r = new Rectangle(new Boundary(0, 0, 1, 1));
            Assert.AreEqual(1, r.secondPoint.X);
            Assert.AreEqual(1, r.secondPoint.Y);
        }

        [TestMethod()]
        public void RectangleTest1()
        {
            Rectangle r = new Rectangle();
            Assert.AreEqual(0, r.secondPoint.X);
            Assert.AreEqual(0, r.secondPoint.Y);
        }

        [TestMethod()]
        public void RectangleFillTest()
        {
            Rectangle r = new Rectangle();
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            r.Fill(w);
            Assert.AreEqual(0, r.secondPoint.X);
            Assert.AreEqual(0, r.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void RectangleDrawTest()
        {
            Rectangle r = new Rectangle();
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            r.Draw(w);
            Assert.AreEqual(0, r.secondPoint.X);
            Assert.AreEqual(0, r.secondPoint.Y);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Rectangle r = new Rectangle(new Boundary(0, 0, 2, 2));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);   
            Assert.IsTrue(r.IsSelect(new Point(1, 1)));
        }
    }
}