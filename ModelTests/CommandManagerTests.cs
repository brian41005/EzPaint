using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PaintModel.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Model m = new Model();
            DrawCommand d = new DrawCommand(m, new Rectangle());
            CommandManager cm = new CommandManager();
            Assert.IsFalse(cm.IsRedoEnabled);
            Assert.IsFalse(cm.IsUndoEnabled);
            cm.Execute(d);
            Assert.IsFalse(cm.IsRedoEnabled);
            Assert.IsTrue(cm.IsUndoEnabled);

        }

        [TestMethod()]
        public void UndoTest()
        {
            Model m = new Model();

            DrawCommand d = new DrawCommand(m, new Rectangle());
            CommandManager cm = new CommandManager();
            try
            {
                cm.Undo();
                
            }
            catch (Exception)
            {

            }
            try
            {
                cm.Redo();

            }
            catch (Exception)
            {

            }
            Assert.IsFalse(cm.IsRedoEnabled);
            Assert.IsFalse(cm.IsUndoEnabled);
            cm.Execute(d);
            Assert.IsFalse(cm.IsRedoEnabled);
            Assert.IsTrue(cm.IsUndoEnabled);
            cm.Undo();
            Assert.IsFalse(cm.IsUndoEnabled);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Model m = new Model();
            DrawCommand d = new DrawCommand(m, new Rectangle());
            CommandManager cm = new CommandManager();
            Assert.IsFalse(cm.IsRedoEnabled);
            Assert.IsFalse(cm.IsUndoEnabled);
            cm.Execute(d);
            Assert.IsFalse(cm.IsRedoEnabled);
            Assert.IsTrue(cm.IsUndoEnabled);
            cm.Undo();
            Assert.IsFalse(cm.IsUndoEnabled);
            cm.Redo();
            Assert.IsFalse(cm.IsRedoEnabled);
        }
    }
}