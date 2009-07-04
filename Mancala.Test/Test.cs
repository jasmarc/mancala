using System;
using System.Collections.Generic;
using System.Linq;
using Mancala.Entities;
using NUnit.Framework;
using Rhino.Mocks;

namespace Mancala.Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test1()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
            }
            using (mocks.Playback())
            {
                Assert.True(true);
            }
        }

        [Test]
        public void Test2()
        {
            IBoard b = new Board();
            Console.WriteLine(b);
            IReferree referree = new Referree
                                     {
                                         Board = b
                                     };
            Assert.Null(referree.Winner());
            ICup cup = b.Cups.ToArray()[10];
            for (LinkedListNode<ICup> nextNode = referree.Board.Cups.Find(cup).Next ?? referree.Board.Cups.First;
                 cup.Seeds > 0;
                 nextNode = nextNode.Next ?? referree.Board.Cups.First)
            {
                cup.Seeds--;
                ICup local1 = nextNode.Value;
                local1.Seeds++;
            }
            Console.WriteLine(b);
            Assert.AreEqual(new[] {5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1},
                            b.Cups.Select(x => x.Seeds).ToArray());
        }
    }
}