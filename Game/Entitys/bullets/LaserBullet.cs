﻿using System;
using System.Collections.Generic;

namespace Game.Entitys.bullets
{
    internal class LaserBullet:AEntity
    {
        public LaserBullet(CoupleInt pos, CoupleInt size, CoupleInt speed)
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
