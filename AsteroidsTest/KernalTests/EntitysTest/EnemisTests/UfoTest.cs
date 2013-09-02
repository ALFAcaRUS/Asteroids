using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Game.Entitys;
using Game.Entitys.Enemies;
using Game.Ships;
using AsteroidsTest.KernalTests.Moks.Ship;

namespace AsteroidsTest.KernalTests.EntitysTest.EnemisTests
{
    [TestClass]
    public class UfoTest
    {
        [TestMethod]
        public void MoveTest()
        {
            IShip mockSip = new MockShip();
            Ufo testedUfo = new Ufo(new CoupleInt(5, 5), new CoupleInt(1, 1), new CoupleInt(0, 0))
            {
                PlayerShip = mockSip
            };

            mockSip.Pos.X = 0;
            mockSip.Pos.Y = 0;

            for (int i = 5; i >= 0; --i)
            {
                testedUfo.ChengeState();

                Assert.AreEqual(new CoupleInt(i, i), testedUfo.Pos);
            }

            testedUfo.Pos = new CoupleInt(5, 5);
            mockSip.Pos = new CoupleInt(0, 5);


        }
    }
}
