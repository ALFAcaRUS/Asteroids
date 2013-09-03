using System.Collections.Generic;
using Game;
using Game.Entitys;
using Game.Weapons;
using AsteroidsTest.KernalTests.Moks.Entitys;

namespace AsteroidsTest.KernalTests.Moks.Weapons
{
    class MockWeapon:IWeapon
    {
        public List<AEntity> Shot(CoupleInt pos)
        {
            return new List<AEntity>
            {
                new MockEntity(pos, new CoupleInt(1, 1), new CoupleInt(0, 0))
            };
        }
    }
}
