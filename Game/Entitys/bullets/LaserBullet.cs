using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Support;

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
