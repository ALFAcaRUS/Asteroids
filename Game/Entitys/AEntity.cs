using System;
using System.Collections.Generic;

namespace Game.Entitys
{
    abstract internal class AEntity
    {
        internal CoupleInt Pos;
        internal CoupleInt Size;
        internal CoupleInt Speed;
        internal Boolean WasKilled;

        internal AEntity(CoupleInt pos, CoupleInt size, CoupleInt speed)
        {
            this.Pos = pos;
            this.Size = size;
            this.Speed = speed;
        }

        internal abstract void ChengeState();

        internal abstract List<AEntity> Interaction(AEntity interactionEntity);
    }
}
