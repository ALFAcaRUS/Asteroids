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
        internal Point Pos;
        internal Size Size;
        internal Boolean WasKilled;

        internal AEntity(Point pos, Size size)
        {
            this.Pos = pos;
            this.Size = size;
        }

        internal abstract void ChengeState();

        internal abstract List<AEntity> Interaction(AEntity interactionEntity);
    }
}
