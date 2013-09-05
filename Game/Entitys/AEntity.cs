using System;
using System.Collections.Generic;

namespace Game.Entitys
{
    abstract internal class AEntity
    {
        internal virtual CoupleDouble Pos { get; set; }
        internal virtual CoupleDouble Size { get; set; }
        internal virtual CoupleDouble Speed { get; set; } 
        internal virtual Boolean WasKilled { get; set; }

        internal AEntity(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
        {
            this.Pos = pos;
            this.Size = size;
            this.Speed = speed;
            WasKilled = false;
        }

        internal abstract void ChengeState(CoupleDouble maxPos);

        internal abstract List<AEntity> Interaction(AEntity interactionEntity);

        internal abstract EntityType GetEntityType();
    }
}
