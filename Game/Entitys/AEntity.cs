using Game.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entitys
{
    abstract class AEntity
    {
        internal Point Pos;
        internal Syze Syze;
        internal Boolean WasKilled;

        internal AEntity(Point pos, Syze syze)
        {
            this.Pos = pos;
            this.Syze = syze;
        }

        internal abstract List<AEntity> Interaction(AEntity interactionEntity);
    }
}
