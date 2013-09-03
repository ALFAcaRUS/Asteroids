using System.Collections.Generic;
using Game;
using Game.Entitys;

namespace AsteroidsTest.KernalTests.Moks.Entitys
{
    class MockEntity:AEntity
    {
        public MockEntity(CoupleInt pos, CoupleInt size, CoupleInt speed) : base(pos, size, speed)
        {

        }

        internal override void ChengeState()
        {
            throw new System.NotImplementedException();
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
