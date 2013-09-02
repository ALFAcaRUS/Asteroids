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
            throw new NotImplementedException();
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            throw new NotImplementedException();
        }
    }
}
