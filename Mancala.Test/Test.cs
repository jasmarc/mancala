using System;
using System.Collections.Generic;
using System.Linq;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;
using NUnit.Framework;
using Rhino.Mocks;
using Is=Rhino.Mocks.Constraints.Is;

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
            IBoard b = BoardConfiguration.Create(new[] {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1});
            Console.WriteLine(b);
            b.Turn = Player.Player1;
            IReferree r = new Referree
                              {
                                  Board = b,
                                  View = MockRepository.GenerateMock<IView>()
                              };
            r.View.Expect(x => x.DisplayModalMessage("Player1 won!")).Constraints(Is.Equal("Player1 won!"));
            r.ReceiveMove(b.Cups.ToArray()[5]);
            Assert.AreEqual(new[] {0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1},
                            b.Cups.Select(x => x.Seeds).ToArray());
            r.View.VerifyAllExpectations();
        }

        [Test]
        public void Test5()
        {
            IBoard b = BoardConfiguration.Create(new[] {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 2});
            Console.WriteLine(b);
            b.Turn = Player.Player1;
            IReferree r = new Referree
                              {
                                  Board = b,
                                  View = MockRepository.GenerateMock<IView>()
                              };
            r.View.Expect(x => x.DisplayModalMessage("tie!")).Constraints(Is.Equal("tie!"));
            r.ReceiveMove(b.Cups.ToArray()[5]);
            Assert.AreEqual(new[] {0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2},
                            b.Cups.Select(x => x.Seeds).ToArray());
            r.View.VerifyAllExpectations();
        }
    }
}