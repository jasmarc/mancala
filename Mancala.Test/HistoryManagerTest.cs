using System;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;
using NUnit.Framework;

namespace Mancala.Test
{
    [TestFixture]
    public class HistoryManagerTest
    {
        [Test]
        public void Test1()
        {
            IHistoryManager<int> h = new HistoryManager<int>();
            h.Add(1);
            h.Add(2);
            h.Undo();
            h.Add(3);
            Assert.False(h.CanRedo());
        }

        [Test]
        public void Test2()
        {
            IHistoryManager<int> h = new HistoryManager<int>();
            Assert.False(h.CanUndo());
            Assert.False(h.CanRedo());
            h.Add(1);
            Assert.False(h.CanUndo());
            Assert.False(h.CanRedo());
        }

        [Test]
        public void Test3()
        {
            IHistoryManager<int> h = new HistoryManager<int>();
            Assert.Throws<ApplicationException>(delegate { h.Undo(); });
            Assert.Throws<ApplicationException>(delegate { h.Redo(); });
            h.Add(1);
            Assert.Throws<ApplicationException>(delegate { h.Undo(); });
            Assert.Throws<ApplicationException>(delegate { h.Redo(); });
        }

        [Test]
        public void Test4()
        {
            IHistoryManager<int> h = new HistoryManager<int>(1);
            h.Add(2);
            h.Undo();
            h.Add(3);
            Assert.False(h.CanRedo());
        }

        [Test]
        public void Test5()
        {
            IHistoryManager<int> h = new HistoryManager<int>(1);
            Assert.False(h.CanUndo());
            Assert.False(h.CanRedo());
        }

        [Test]
        public void Test6()
        {
            IHistoryManager<int> h = new HistoryManager<int>(1);
            Assert.Throws<ApplicationException>(delegate { h.Undo(); });
            Assert.Throws<ApplicationException>(delegate { h.Redo(); });
        }
    }
}
