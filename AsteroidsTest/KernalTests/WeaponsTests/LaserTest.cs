using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Game.Weapons;
using Game.Entitys;
using Game.Entitys.bullets;

namespace AsteroidsTest.KernalTests.WeaponsTests
{
    [TestClass]
    public class LaserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Laser testedLaser = new Laser();

            testedLaser.Charge = 5;
            testedLaser.Distance = 2;
            List<AEntity> shotExpected = new List<AEntity>
            {
                new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(0, 0)),
                new LaserBullet(new CoupleInt(1, 2), new CoupleInt(1, 1), new CoupleInt(0, 0))
            };

            for (int i = 4; i >= 0; i--)
            {
                List<AEntity> shotResult = testedLaser.Shot(new CoupleInt(1, 1));

                Assert.AreEqual(i, testedLaser.Charge);
                //Assert.AreEqual(shotExpected, shotResult);
            }

            List<AEntity> notHaveCharge = testedLaser.Shot(new CoupleInt(1, 1));

            Assert.AreEqual(null, notHaveCharge);
            Assert.AreEqual(0, testedLaser.Charge);
        }
    }
}
