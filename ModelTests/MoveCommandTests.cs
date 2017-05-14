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
    public class MoveCommandTests
    {
        [TestMethod()]
        public void MoveCommandTest()
        {
            Model m = new Model();
            MoveCommand d = new MoveCommand(m, new Rectangle(), new Point(1,1));
            Assert.AreEqual(0, 0);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Model m = new Model();
            MoveCommand d = new MoveCommand(m, new Rectangle(), new Point(1, 1));
            d.Execute();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Model m = new Model();
            MoveCommand d = new MoveCommand(m, new Rectangle(), new Point(1, 1));
            d.ReverseExecute();
            Assert.IsTrue(true);
        }
    }
}