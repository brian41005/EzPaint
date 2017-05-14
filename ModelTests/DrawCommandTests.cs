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
    public class DrawCommandTests
    {
        [TestMethod()]
        public void DrawCommandTest()
        {
            Model m = new Model();
            DrawCommand d = new DrawCommand(m, new Rectangle());
            Assert.AreEqual(0, 0);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Model m = new Model();
            DrawCommand d = new DrawCommand(m, new Rectangle());
            d.Execute();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Model m = new Model();
            DrawCommand d = new DrawCommand(m, new Rectangle());
            d.ReverseExecute();
            Assert.IsTrue(true);
        }
    }
}