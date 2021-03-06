﻿using System.Collections.Generic;
using Game;
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
            Asteroid asteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1),new CoupleDouble(1,1));
            CoupleDouble expPos = new CoupleDouble
            {
                X = asteroid.Pos.X + asteroid.Speed.X,
                Y = asteroid.Pos.Y + asteroid.Speed.Y
            };

            //activity
            asteroid.ChengeState(new CoupleDouble(100, 100));

            //assertion
            Assert.AreEqual(asteroid.Pos, expPos);
        }

        [TestMethod]
        public void EnamyInteractionTest()
        {
            //organization
            Asteroid testedAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            Asteroid someAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            Ufo someUfo = new Ufo(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));

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
            Asteroid firstSmalAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1), 1);
            Asteroid secondSmalAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1), 1);
            Asteroid firstBigAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1), 2);
            Asteroid secondBigAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1), 2);
            AEntity laserBullet = new LaserBullet(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            GunBullet gunBullet = new GunBullet(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));

            List<AEntity> bigAsteroidIntResult = new List<AEntity>();
            bigAsteroidIntResult.Add(new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(2, 1), 1));
            bigAsteroidIntResult.Add(new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(0, 1), 1));

            //activity
            List<AEntity> laserSmalInteraction = firstSmalAsteroid.Interaction(laserBullet);
            List<AEntity> gunSmalInteraction = secondSmalAsteroid.Interaction(gunBullet);
            List<AEntity> laserBigInteraction = firstBigAsteroid.Interaction(laserBullet);
            List<AEntity> gunBigInteraction = secondBigAsteroid.Interaction(gunBullet);

            //assertion

            
            Assert.AreEqual(laserSmalInteraction, null);
            Assert.AreEqual(gunSmalInteraction, null);
            //Assert.AreEqual(laserBigInteraction, bigAsteroidIntResult);
            //Assert.AreEqual(gunBigInteraction, bigAsteroidIntResult);

            Assert.IsTrue(firstSmalAsteroid.WasKilled);
            Assert.IsTrue(secondSmalAsteroid.WasKilled);
            Assert.IsTrue(firstBigAsteroid.WasKilled);
            Assert.IsTrue(secondBigAsteroid.WasKilled);
        }
    }
}
