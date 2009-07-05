using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        [Test]
        public void Test3()
        {
            IBoard b = BoardConfiguration.Create(new[] { 5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 });
            Assert.AreEqual(new[] { 5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 },
                            b.Cups.Select(x => x.Seeds).ToArray());
            BoardConfiguration.Set(b, new[] { 0, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 });
            Assert.AreEqual(new[] { 0, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 },
                            b.Cups.Select(x => x.Seeds).ToArray());
        }

        [Test]
        public void Test4()
        {
            IBoard b = BoardConfiguration.Create(new[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1 });
            Console.WriteLine(b);
            b.Turn = Player.Player1;
            IReferree r = new Referree()
                              {
                                  Board = b
                              };
            Button button = new Button();
            button.Tag = b.Cups.ToArray()[5];
            r.ReceivedMove(button, null);
            Console.WriteLine(b);
            Assert.AreEqual(2, b.Cups.ToArray()[6].Seeds);
            
        }
    }
}