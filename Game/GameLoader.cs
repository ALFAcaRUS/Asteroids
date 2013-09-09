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
            Ship playerShip = new Ship();
            playerShip.Direction.Angle = 0;
            playerShip.Size = new CoupleDouble(5,5);
            List<IWeapon> weapons = new List<IWeapon>
            {
                new Gun(),
                new Laser()
            };

            playerShip.Weapons = weapons;

            List<AEntity> startEntitys = new List<AEntity>
            {
                new EnemiFarm(new CoupleDouble(0, 1), new CoupleDouble(0.1,0.1), CoupleDouble.zero, playerShip),
                new EnemyFarmPseudoEntity(new CoupleDouble(0, 1), new CoupleDouble(0.1,0.1), CoupleDouble.zero)
            };

            MainClass newGame = new MainClass(startEntitys, playerShip,new CoupleDouble(100,100));
            return newGame;
        }
    }
}
