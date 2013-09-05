using System.Collections.Generic;
using Game;
using Game.Entitys;
using Game.Ships;
using Game.Weapons;

namespace AsteroidsTest.KernalTests.Moks.Ship
{
    internal class MockShip : IShip
    {
        public CoupleDouble Pos { get; set; }
        public CoupleDouble Size { get; set; }
        public Degree Direction { get; set; }
        public List<IWeapon> Weapons { get; private set; }

        public void AddWeapon(IWeapon newWeapon)
        {
            throw new System.NotImplementedException();
        }
    }
}
