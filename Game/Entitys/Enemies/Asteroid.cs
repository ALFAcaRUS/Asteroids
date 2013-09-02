using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Support;

namespace Game.Entitys.Enemies
{
    class Asteroid:AEntity
    {
        public Asteroid(Point pos, Syze syze) : base(pos, syze)
        {
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            throw new NotImplementedException();
        }
    }
}
