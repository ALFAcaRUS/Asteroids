using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Game.Entitys;
using Game.Entitys.bullets;
using Game.Entitys.Enemies;

namespace AsteroidsTest.KernalTests.EntitysTest.BulletTests
{
    [TestClass]
    public class GunBulletTest
    {
        [TestMethod]
        public void MoutionTest()
        {
            GunBullet testedGunBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));

            for (int i = 2; i <= 5; i++)
            {
                testedGunBullet.ChengeState();

                Assert.AreEqual(new CoupleInt(i, i), testedGunBullet.Pos);
            }

        }

        [TestMethod]
        public void EnemyInteractionTest()
        {
            GunBullet firstTestedGunBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));
            GunBullet secondTestedGunBullet = new GunBullet(new CoupleInt(2, 2), new CoupleInt(2, 2), new CoupleInt(-1, -1));

            Ufo someUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));
            Asteroid someAsteroid = new Asteroid(new CoupleInt(2, 2), new CoupleInt(2, 2), new CoupleInt(-1, -1));

            List<AEntity> interUfoResult = firstTestedGunBullet.Interaction(someUfo);
            List<AEntity> interaAsterResult = secondTestedGunBullet.Interaction(someAsteroid);

            Assert.AreEqual(null, interUfoResult);
            Assert.AreEqual(null, interaAsterResult);

            Assert.IsTrue(firstTestedGunBullet.WasKilled);
            Assert.IsTrue(secondTestedGunBullet.WasKilled);

        }

        [TestMethod]
        public void BulletInteractionTest()
        {
            GunBullet testedBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));

            GunBullet someGunBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));
            LaserBullet someLaserBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));

            List<AEntity> gunBullIntRes = testedBullet.Interaction(someGunBullet);
            List<AEntity> laserBullIntRes = testedBullet.Interaction(someLaserBullet);


            Assert.AreEqual(null, gunBullIntRes);
            Assert.AreEqual(null, laserBullIntRes);

            Assert.IsFalse(testedBullet.WasKilled);
        }

    }
}
