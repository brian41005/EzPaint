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
    public class BoundaryTests
    {
        [TestMethod()]
        public void BoundaryTest()
        {
            Boundary boundary = new Boundary();
            boundary.Height = 1;
            boundary.Width = 1;
            Assert.AreEqual(0, boundary.X);
            Assert.AreEqual(0, boundary.Y);
            Assert.AreEqual(1, boundary.Width);
            Assert.AreEqual(1, boundary.Height);

            
        }

        [TestMethod()]
        public void BoundaryTest1()
        {
            Boundary boundary2 = new Boundary(1, 1, 1, 1);
            Assert.AreEqual(1, boundary2.X);
            Assert.AreEqual(1, boundary2.Y);
            Assert.AreEqual(1, boundary2.Width);
            Assert.AreEqual(1, boundary2.Height);
        }
    }
}