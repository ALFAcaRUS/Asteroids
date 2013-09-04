using System.Collections.Generic;
using Game.Entitys;
using Game.Entitys.bullets;

namespace Game.Weapons
{
    class Gun:IWeapon
    {
        public List<AEntity> Shot(CoupleInt pos)
        {
            List<AEntity> output = new List<AEntity>
            {
                new GunBullet(pos, new CoupleInt(1, 1), new CoupleInt(0, 1))
            };

            return output;
        }
    }
}
