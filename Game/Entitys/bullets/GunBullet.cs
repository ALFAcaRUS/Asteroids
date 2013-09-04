using System;
using System.Collections.Generic;

namespace Game.Entitys.bullets
{
    class GunBullet:AEntity
    {
        public GunBullet(CoupleInt pos, CoupleInt size, CoupleInt speed)
            : base(pos, size, speed)
        {

        }

        internal override void ChengeState()
        {
            base.Pos.X = base.Pos.X - base.Speed.X;
            base.Pos.Y = base.Pos.Y - base.Speed.Y;
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (typeof (LaserBullet) != interactionEntity.GetType() && typeof(GunBullet) != interactionEntity.GetType())
            {
                base.WasKilled = true;
            }
            return null;
        }
    }
}
