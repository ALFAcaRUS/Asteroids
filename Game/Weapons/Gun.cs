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
                new GunBullet(pos + direction.GetProjections(), new CoupleDouble(1, 1),direction.GetProjections() * 3,direction)
            };

            return output;
        }

        public void Update()
        {
           
        }
    }
}
