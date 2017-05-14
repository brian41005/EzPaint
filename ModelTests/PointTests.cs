using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintModel.Tests
{
    [TestClass()]
    public class PointTests
    {
        [TestMethod()]
        public void PointTest()
        {
            Point p = new Point();
            Assert.AreEqual(0,p.X);
            Assert.AreEqual(0, p.Y);

        }

        [TestMethod()]
        public void PointTest1()
        {
            Point p = new Point(1, 1);
            Point f = new Point(2, 2);
            Assert.AreEqual(1, p.X);
            Assert.AreEqual(1, p.Y);
            p.X = 2;
            p.Y = 2;
            Assert.AreEqual(2, p.X);
            Assert.AreEqual(2, p.Y);
            p = p + f;
            p.GetLength();
        }
    }
}