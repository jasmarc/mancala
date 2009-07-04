using System;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Mancala.Entities;

namespace TestProject
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test1()
        {
            MockRepository mocks = new MockRepository();
            using (mocks.Record())
            {
                ;
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
            IReferree referree = new Referree()
                                   {
                                       Board = b
                                   };
            referree.ApplyMove(b.Cups.ToArray()[10]);
            Console.WriteLine(b);
            Assert.AreEqual(new int[] { 5, 4, 4, 4, 4, 4, 0, 4, 4, 4, 0, 5, 5, 1 }, b.Cups.Select<ICup, int>(delegate (ICup x) {
                return x.Seeds;
            }).ToArray<int>());
        }
    }
}