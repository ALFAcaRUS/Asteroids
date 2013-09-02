using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Support;

namespace Game.Entitys.bullets
{
    class GunBullet:AEntity
    {
        public GunBullet(Point pos, Size size) : base(pos, size)
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
