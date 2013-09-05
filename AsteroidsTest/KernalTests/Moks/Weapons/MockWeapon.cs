using System.Collections.Generic;
using Game;
using Game.Entitys;
using Game.Weapons;
using AsteroidsTest.KernalTests.Moks.Entitys;

namespace AsteroidsTest.KernalTests.Moks.Weapons
{
    class MockWeapon:IWeapon
    {
        public List<AEntity> Shot(CoupleDouble pos, Degree direction)
        {
            return new List<AEntity>
            {
                new MockEntity(pos, new CoupleDouble(1, 1), new CoupleDouble(0, 0))
            };
        }
    }
}
