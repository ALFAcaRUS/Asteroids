using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entitys.PseudoEntitys
{
    // Necessary for permanent interaction with enemy farm
    // Don't interaction with any entitys
    class EnemyFarmPseudoEntity:AEntity
    {
        public EnemyFarmPseudoEntity(CoupleInt pos, CoupleInt size, CoupleInt speed) : base(pos, size, speed)
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
