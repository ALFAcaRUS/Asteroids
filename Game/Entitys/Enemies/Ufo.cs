using System;
using System.Collections.Generic;
using Game.Ships;

namespace Game.Entitys.Enemies
{
    internal class Ufo:AEntity
    {
        public IShip PlayerShip { get; set; }

        public Ufo(CoupleInt pos, CoupleInt size, CoupleInt speed)
            : base(pos, size,speed)
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
