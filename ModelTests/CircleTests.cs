using Microsoft.VisualStudio.TestTools.UnitTesting;
using EzPrintForm;
using System.Drawing;

namespace PaintModel.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void CircleTest()
        {
            Circle c = new Circle(new Boundary(0,0,1,1));
            Assert.AreEqual(1,c.secondPoint.X);
            Assert.AreEqual(1, c.secondPoint.Y);
        }

        [TestMethod()]
        public void CircleTest1()
        {
            Circle c = new Circle();
            Assert.AreEqual(0, c.secondPoint.X);
            Assert.AreEqual(0, c.secondPoint.Y);
        }

        [TestMethod()]
        public void CircleDrawTest()
        {
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            Circle c = new Circle();
            c.Draw(w);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CircleFillTest()
        {
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            Circle c = new Circle();
            c.Fill(w);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Circle r = new Circle(new Boundary(0, 0, 10, 10));
            Graphics g = (new DoubleBufferedPanel()).CreateGraphics();
            WindowsFormsGraphicsAdaptor w = new WindowsFormsGraphicsAdaptor(g);
            Assert.IsTrue(r.IsSelect(new Point(5, 5)));
        }

    }
}