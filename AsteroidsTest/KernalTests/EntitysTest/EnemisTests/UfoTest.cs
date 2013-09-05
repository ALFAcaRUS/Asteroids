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
            Ufo testedUfo = new Ufo(new CoupleDouble(5, 5), new CoupleDouble(1, 1), new CoupleDouble(1, 1))
            {
                PlayerShip = mockSip
            };

            mockSip.Pos = new CoupleDouble(0, 0);

            for (int i = 4; i >= 0; --i)
            {
                testedUfo.ChengeState(new CoupleDouble(100, 100));

                Assert.AreEqual(new CoupleDouble(i, i), testedUfo.Pos);
            }

            testedUfo.Pos = new CoupleDouble(5, 5);
            mockSip.Pos = new CoupleDouble(5, 0);

            for (int i = 4; i <= 0; i++)
            {
                testedUfo.ChengeState(new CoupleDouble(100, 100));

                Assert.AreEqual(new CoupleDouble(5, i ), testedUfo.Pos);
            }

            testedUfo.Pos = new CoupleDouble(5, 5);
            mockSip.Pos = new CoupleDouble(12, 0);

            for (int i = 6; i <= 10; i++)
            {
                testedUfo.ChengeState(new CoupleDouble(100, 100));

                Assert.AreEqual(new CoupleDouble(i, 10 - i), testedUfo.Pos);
            }

        }

        [TestMethod]
        public void EnamyInteractionTest()
        {
            //organization
            Ufo testedUfo = new Ufo(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            Asteroid someAsteroid = new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            Ufo someUfo = new Ufo(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));

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
            Ufo firstUfo = new Ufo(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            Ufo secondUfo = new Ufo(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            LaserBullet laserBullet = new LaserBullet(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));
            GunBullet gunBullet = new GunBullet(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(1, 1));

            List<AEntity> bigAsteroidIntResult = new List<AEntity>();
            bigAsteroidIntResult.Add(new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(2, 1), 1));
            bigAsteroidIntResult.Add(new Asteroid(new CoupleDouble(1, 1), new CoupleDouble(1, 1), new CoupleDouble(0, 1), 1));

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
