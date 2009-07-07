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
        public void TestBoardConfiguration()
        {
            IBoard b = BoardConfiguration.Create(Player.Player1, new[] { 5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 });
            Assert.AreEqual(new[] { 5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 },
                            b.Cups.Select(x => x.Seeds).ToArray());
            BoardConfiguration.Set(b, Player.Player2, new[] { 0, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 });
            Assert.AreEqual(new[] { 0, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 },
                            b.Cups.Select(x => x.Seeds).ToArray());
        }

        [Test]
        public void TestPlayer1WinsByClaimingRemainingSeeds()
        {
            var configuration = new[] {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1};
            IBoard b = BoardConfiguration.Create(Player.Player1, configuration);
            var v = MockRepository.GenerateMock<IView>();
            IReferree r = new Referree
                              {
                                  RulesEngine = new RulesEngine1(),
                                  Board = b,
                                  View = v
                              };
            r.View.Expect(x => x.DisplayModalMessage("Player1 won!")).Constraints(Is.Equal("Player1 won!"));
            r.ReceiveMove(b.Cups.ToArray()[5]);
            Assert.AreEqual(new[] {0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1},
                            BoardConfiguration.GetConfiguration(b));
            v.VerifyAllExpectations();
        }

        [Test]
        public void TestTieGame()
        {
            int[] configuration = new[] {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 2};
            IBoard b = BoardConfiguration.Create(Player.Player1, configuration);            
            IView v = MockRepository.GenerateMock<IView>();
            IReferree r = new Referree
                              {
                                  RulesEngine = new RulesEngine1(),
                                  Board = b,
                                  View = v
                              };
            r.View.Expect(x => x.DisplayModalMessage("tie!")).Constraints(Is.Equal("tie!"));
            r.ReceiveMove(b.Cups.ToArray()[5]);
            Assert.AreEqual(new[] {0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2},
                            BoardConfiguration.GetConfiguration(b));
            v.VerifyAllExpectations();
        }

        [Test]
        public void TestCrossCup()
        {
            Board b = new Board();
            ICup[] cups = b.Cups.ToArray();
            Assert.AreEqual(cups[12], b.CrossCup(cups[0]));
            Assert.AreEqual(cups[11], b.CrossCup(cups[1]));
            Assert.AreEqual(cups[10], b.CrossCup(cups[2]));
            Assert.AreEqual(cups[9],  b.CrossCup(cups[3]));
            Assert.AreEqual(cups[8],  b.CrossCup(cups[4]));
            Assert.AreEqual(cups[7],  b.CrossCup(cups[5]));
            Assert.AreEqual(cups[5],  b.CrossCup(cups[7]));
            Assert.AreEqual(cups[4],  b.CrossCup(cups[8]));
            Assert.AreEqual(cups[3],  b.CrossCup(cups[9]));
            Assert.AreEqual(cups[2],  b.CrossCup(cups[10]));
            Assert.AreEqual(cups[1],  b.CrossCup(cups[11]));
            Assert.AreEqual(cups[0],  b.CrossCup(cups[12]));
        }
    }
}