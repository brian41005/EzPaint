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
    public class ShapeFactoryTests
    {
        [TestMethod()]
        public void GetShapeTest()
        {

            ShapeFactory sf = new ShapeFactory();
            int state = 0;
            Assert.AreEqual("PaintModel.Rectangle", sf.GetShape(state).GetType().ToString());
            state = -1;
            Assert.AreEqual("PaintModel.Shape", sf.GetShape(state).GetType().ToString());
            state = 1;
            Assert.AreEqual("PaintModel.Triangle", sf.GetShape(state).GetType().ToString());
            state = 2;
            Assert.AreEqual("PaintModel.Circle", sf.GetShape(state).GetType().ToString());
            state = 3;
            Assert.AreEqual("PaintModel.Line", sf.GetShape(state).GetType().ToString());

        }
    }
}