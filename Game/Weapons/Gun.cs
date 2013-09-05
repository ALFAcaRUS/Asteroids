using System.Collections.Generic;
using Game.Entitys;
using Game.Entitys.bullets;

namespace Game.Weapons
{
    class Gun:IWeapon
    {
        public List<AEntity> Shot(CoupleDouble pos, Degree direction)
        {
            List<AEntity> output = new List<AEntity>
            {
                new GunBullet(pos, new CoupleDouble(1, 1),direction.GetProjections())
            };

            return output;
        }
    }
}
