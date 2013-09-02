using System.Collections.Generic;
using Game.Entitys;
using Game.Entitys.Enemies;
using Game.Entitys.bullets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsteroidsTest.KernalTests.EntitysTest.EnemisTests
{
    [TestClass]
    public class AsteroidTest
    {
        

        [TestMethod]
        public void MovingTest()
        {
            //organization
            Asteroid asteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1),new CoupleInt(1,1));
            CoupleInt expPos = new CoupleInt
            {
                X = asteroid.Pos.X + asteroid.Speed.X,
                Y = asteroid.Pos.Y + asteroid.Speed.Y
            };

            //activity
            asteroid.ChengeState();

            //assertion
            Assert.AreEqual(asteroid.Pos, expPos);
        }

        [TestMethod]
        public void EnamyInteractionTest()
        {
            //organization
            Asteroid testedAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            Asteroid someAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            Ufo someUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));

            //activity
            List<AEntity> asteroidInteraction = testedAsteroid.Interaction(someAsteroid);
            List<AEntity> ufoInteraction = testedAsteroid.Interaction(someUfo);

            //assertion
            Assert.AreEqual(asteroidInteraction, null);
            Assert.AreEqual(ufoInteraction, null);
        }

        [TestMethod]
        public void BulletInteractionTest()
        {
            //organization
            Asteroid firstSmalAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1), 1);
            Asteroid secondSmalAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1), 1);
            Asteroid firstBigAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1), 2);
            Asteroid secondBigAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1), 2);
            LaserBullet laserBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            GunBullet gunBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));

            List<AEntity> bigAsteroidIntResult = new List<AEntity>();
            bigAsteroidIntResult.Add(new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(2, 1), 1));
            bigAsteroidIntResult.Add(new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(0, 1), 1));

            //activity
            List<AEntity> laserSmalInteraction = firstSmalAsteroid.Interaction(laserBullet);
            List<AEntity> gunSmalInteraction = secondSmalAsteroid.Interaction(gunBullet);
            List<AEntity> laserBigInteraction = firstBigAsteroid.Interaction(laserBullet);
            List<AEntity> gunBigInteraction = secondBigAsteroid.Interaction(gunBullet);

            //assertion

            
            Assert.AreEqual(laserSmalInteraction, null);
            Assert.AreEqual(gunSmalInteraction, null);
            Assert.AreEqual(laserBigInteraction, bigAsteroidIntResult);
            Assert.AreEqual(gunBigInteraction, bigAsteroidIntResult);

            Assert.IsTrue(firstSmalAsteroid.WasKilled);
            Assert.IsTrue(secondSmalAsteroid.WasKilled);
            Assert.IsTrue(firstBigAsteroid.WasKilled);
            Assert.IsTrue(secondBigAsteroid.WasKilled);
        }
    }
}
