using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Game.Weapons;
using Game.Entitys;
using Game.Entitys.bullets;

namespace AsteroidsTest.KernalTests.WeaponsTests
{
    [TestClass]
    public class GunTest
    {
        [TestMethod]
        public void ShotTest()
        {
            Gun testedGun = new Gun();

            List<AEntity> shotResult = testedGun.Shot(new CoupleInt(1,1));
            List<AEntity> shotExpected = new List<AEntity>
            {
                new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1))
            };

            Assert.AreEqual(shotExpected, shotResult);

        }
    }
}
