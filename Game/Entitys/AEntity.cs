using Game.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entitys
{
    abstract internal class AEntity
    {
        internal CoupleInt Pos;
        internal CoupleInt Size;
        internal CoupleInt Spead;
        internal Boolean WasKilled;

        internal AEntity(CoupleInt pos, CoupleInt size, CoupleInt speed)
        {
            this.Pos = pos;
            this.Size = size;
            this.Spead = speed;
        }

        internal abstract void ChengeState();

        internal abstract List<AEntity> Interaction(AEntity interactionEntity);
    }
}
