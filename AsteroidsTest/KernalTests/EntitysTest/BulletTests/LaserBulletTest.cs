using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Game.Entitys;
using Game.Entitys.bullets;
using Game.Entitys.Enemies;

namespace AsteroidsTest.KernalTests.EntitysTest.BulletTests
{
    [TestClass]
    public class LaserBulletTest
    {
        [TestMethod]
        public void StateUpdateTest()
        {
            LaserBullet testedBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));

            testedBullet.ChengeState();

            Assert.IsTrue(testedBullet.WasKilled);
        }

        [TestMethod]
        public void EnemyInteractionTest()
        {
            LaserBullet firstTestedLaserBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));
            LaserBullet secondTestedLaserBullet = new LaserBullet(new CoupleInt(2, 2), new CoupleInt(2, 2), new CoupleInt(-1, -1));

            Ufo someUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));
            Asteroid someAsteroid = new Asteroid(new CoupleInt(2, 2), new CoupleInt(2, 2), new CoupleInt(-1, -1));

            List<AEntity> interUfoResult = firstTestedLaserBullet.Interaction(someUfo);
            List<AEntity> interaAsterResult = secondTestedLaserBullet.Interaction(someAsteroid);

            Assert.AreEqual(null, interUfoResult);
            Assert.AreEqual(null, interaAsterResult);

            Assert.IsTrue(firstTestedLaserBullet.WasKilled);
            Assert.IsTrue(secondTestedLaserBullet.WasKilled);

        }

        public void BulletInteractionTest()
        {
            LaserBullet testedBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));

            GunBullet someGunBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));
            LaserBullet someLaserBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(-1, -1));

            List<AEntity> gunBullIntRes = testedBullet.Interaction(someGunBullet);
            List<AEntity> laserBullIntRes = testedBullet.Interaction(someLaserBullet);


            Assert.AreEqual(null, gunBullIntRes);
            Assert.AreEqual(null, laserBullIntRes);

            Assert.IsTrue(testedBullet.WasKilled);
        }

    }
}
