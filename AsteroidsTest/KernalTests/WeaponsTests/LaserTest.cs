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
                new LaserBullet(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(0, 0)),
                new LaserBullet(new CoupleDouble(1, 2), new CoupleDouble(1, 1), new CoupleDouble(0, 0))
            };

            for (int i = 4; i >= 0; i--)
            {
                List<AEntity> shotResult = testedLaser.Shot(new CoupleDouble(1, 1), new Degree(0));

                Assert.AreEqual(i, testedLaser.Charge);
                //Assert.AreEqual(shotExpected, shotResult);
            }

            List<AEntity> notHaveCharge = testedLaser.Shot(new CoupleDouble(1, 1), new Degree(0));

            Assert.AreEqual(null, notHaveCharge);
            Assert.AreEqual(0, testedLaser.Charge);
        }
    }
}
