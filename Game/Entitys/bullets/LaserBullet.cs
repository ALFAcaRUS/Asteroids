using System;
using System.Collections.Generic;

namespace Game.Entitys.bullets
{
    internal class LaserBullet:AEntity
    {
        public LaserBullet(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
            : base(pos, size, speed)
        {

        }

        public LaserBullet(CoupleDouble pos, CoupleDouble size, CoupleDouble speed, Degree angle)
            : base(pos, size, speed,angle)
        {

        }

        internal override void ChengeState(CoupleDouble maxPos)
        {
            WasKilled = true;
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            WasKilled = true;
            return null;
        }

        internal override EntityType GetEntityType()
        {
            return EntityType.Bullet;
        }

        public override string ToString()
        {
            return "LaserBulet";
        }
    }
}
