using System.Collections.Generic;
using Game.Entitys;
using Game.Entitys.Enemies;
using Game.Entitys.PseudoEntitys;
using Game.Maine;
using Game.Ships;
using Game.Weapons;

namespace Game
{
    public class GameLoaderInjector
    {

        public static IGame GetGame()
        {
            CoupleDouble defaultSyze = new CoupleDouble(1, 1);
            CoupleDouble defaultSpeed = new CoupleDouble(1, 1);

            Ship playerShip = new Ship();
            playerShip.Direction.Angle = 0;
            playerShip.Size = CoupleDouble.ones;
            List<IWeapon> weapons = new List<IWeapon>
            {
                new Gun(),
                new Laser()
            };

            playerShip.Weapons = weapons;

            List<AEntity> startEntitys = new List<AEntity>
            {
                new EnemiFarm(new CoupleDouble(0, 1), defaultSyze, defaultSpeed, playerShip),
                new EnemyFarmPseudoEntity(new CoupleDouble(0, 1), defaultSyze, defaultSpeed)
            };

            MainClass newGame = new MainClass(startEntitys, playerShip,new CoupleDouble(100,100));
            return newGame;
        }
    }
}
