using System;
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
            Assert.False(b.GameIsOver());
            IReferree referree = new Referree
                                     {
                                         Board = b
                                     };
            referree.ApplyMove(b.Cups.ToArray()[10]);
            Console.WriteLine(b);
            Assert.AreEqual(new[] {5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1},
                            b.Cups.Select(x => x.Seeds).ToArray());
        }
    }
}