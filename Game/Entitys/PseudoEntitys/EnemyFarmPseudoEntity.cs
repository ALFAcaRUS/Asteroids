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
        public EnemyFarmPseudoEntity(CoupleDouble pos, CoupleDouble size, CoupleDouble speed) : base(pos, size, speed)
        {
        }

        internal override void ChengeState(CoupleDouble maxPos)
        {

        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            return null;
        }

        internal override EntityType GetEntityType()
        {
            return EntityType.Service;
        }
    }
}
