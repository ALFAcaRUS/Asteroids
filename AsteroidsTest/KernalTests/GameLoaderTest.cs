using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using Game.Entitys;
using Game.Entitys.Enemies;
using Game.Entitys.PseudoEntitys;
using Game.Maine;
using Game.Ships;
using Game.Weapons;


namespace AsteroidsTest.KernalTests
{
    [TestClass]
    public class GameLoaderTest
    {
        [TestMethod]
        public void LoadTest()
        {
            CoupleDouble defaultSyze = new CoupleDouble(1, 1);
            CoupleDouble defaultSpeed = new CoupleDouble(1, 1);

            Ship playerShip = new Ship();
            List<IWeapon> weapons = new List<IWeapon>
            {
                new Gun(),
                new Laser()
            };

            List<AEntity> startEntitys = new List<AEntity>
            {
                new EnemiFarm(new CoupleDouble(0, 1), defaultSyze, defaultSpeed),
                new EnemyFarmPseudoEntity(new CoupleDouble(0, 1), defaultSyze, defaultSpeed)
            };

            MainClass expectedGame = new MainClass(startEntitys, playerShip, new CoupleDouble(100,100));

            Assert.AreEqual(expectedGame, GameLoaderInjector.GetGame());

        }
    }
}
