using System.Collections.Generic;
using Game.Entitys;
using Game.Entitys.Enemies;
using Game.Entitys.PseudoEntitys;
using Game.Maine;
using Game.Ships;
using Game.Weapons;

namespace Game
{
    class GameLoaderInjector
    {

        public static IGame GetGame()
        {
            CoupleInt defaultSyze = new CoupleInt(1, 1);
            CoupleInt defaultSpeed = new CoupleInt(1, 1);

            Ship playerShip = new Ship();
            List<IWeapon> weapons = new List<IWeapon>
            {
                new Gun(),
                new Laser()
            };

            List<AEntity> startEntitys = new List<AEntity>
            {
                new EnemiFarm(new CoupleInt(0, 1), defaultSyze, defaultSpeed),
                new EnemyFarmPseudoEntity(new CoupleInt(0, 1), defaultSyze, defaultSpeed)
            };

            MainClass newGame = new MainClass(startEntitys, playerShip);
            return newGame;
        }
    }
}
