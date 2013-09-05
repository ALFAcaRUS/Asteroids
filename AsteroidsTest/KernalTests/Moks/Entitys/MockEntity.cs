using System.Collections.Generic;
using Game;
using Game.Entitys;

namespace AsteroidsTest.KernalTests.Moks.Entitys
{
    class MockEntity:AEntity
    {
        public MockEntity(CoupleDouble pos, CoupleDouble size, CoupleDouble speed) : base(pos, size, speed)
        {

        }

        internal override void ChengeState(CoupleDouble maxPos)
        {
            throw new System.NotImplementedException();
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            throw new System.NotImplementedException();
        }

        internal override EntityType GetEntityType()
        {
            return EntityType.Service;
        }
    }
}
