using System;
using System.Collections.Generic;

namespace Game.Entitys
{
    abstract internal class AEntity
    {
        internal virtual CoupleInt Pos { get; set; }
        internal virtual CoupleInt Size { get; set; }
        internal virtual CoupleInt Speed { get; set; }
        internal virtual Boolean WasKilled { get; set; }

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
