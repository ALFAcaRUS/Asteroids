using System.Collections.Generic;
using Game.Entitys.bullets;
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

            for (int i = 4; i >= 0; --i)
            {
                testedUfo.ChengeState();

                Assert.AreEqual(new CoupleInt(i, i), testedUfo.Pos);
            }

            testedUfo.Pos = new CoupleInt(5, 5);
            mockSip.Pos = new CoupleInt(5, 0);

            for (int i = 4; i <= 0; i++)
            {
                testedUfo.ChengeState();

                Assert.AreEqual(new CoupleInt(5, i ), testedUfo.Pos);
            }

            testedUfo.Pos = new CoupleInt(5, 5);
            mockSip.Pos = new CoupleInt(12, 0);

            for (int i = 6; i <= 10; i++)
            {
                testedUfo.ChengeState();

                Assert.AreEqual(new CoupleInt(i, 10 - i), testedUfo.Pos);
            }

        }

        [TestMethod]
        public void EnamyInteractionTest()
        {
            //organization
            Ufo testedUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            Asteroid someAsteroid = new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            Ufo someUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));

            //activity
            List<AEntity> asteroidInteraction = testedUfo.Interaction(someAsteroid);
            List<AEntity> ufoInteraction = testedUfo.Interaction(someUfo);

            //assertion
            Assert.AreEqual(asteroidInteraction, null);
            Assert.AreEqual(ufoInteraction, null);
        }

        [TestMethod]
        public void BulletInteractionTest()
        {
            //organization
            Ufo firstUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            Ufo secondUfo = new Ufo(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            LaserBullet laserBullet = new LaserBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));
            GunBullet gunBullet = new GunBullet(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(1, 1));

            List<AEntity> bigAsteroidIntResult = new List<AEntity>();
            bigAsteroidIntResult.Add(new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(2, 1), 1));
            bigAsteroidIntResult.Add(new Asteroid(new CoupleInt(1, 1), new CoupleInt(1, 1), new CoupleInt(0, 1), 1));

            //activity
            List<AEntity> laserSmalInteraction = firstUfo.Interaction(laserBullet);
            List<AEntity> gunSmalInteraction = secondUfo.Interaction(gunBullet);

            //assertion


            Assert.AreEqual(laserSmalInteraction, null);
            Assert.AreEqual(gunSmalInteraction, null);

            Assert.IsTrue(firstUfo.WasKilled);
            Assert.IsTrue(secondUfo.WasKilled);
        }
    }
}
