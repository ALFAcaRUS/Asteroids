using System;
using System.Collections.Generic;

namespace Game.Entitys.Enemies
{
    class EnemiFarm:AEntity
    {

        internal override CoupleInt Pos
        {
            get
            {
                return base.Pos;
            }
            set
            {
                base.Pos = this.Pos;
            }
        }



        public EnemiFarm(CoupleInt pos, CoupleInt size, CoupleInt speed) : base(pos, size, speed)
        {
            this.Size = new CoupleInt(0, 0);
            this.Speed = new CoupleInt(0, 0);
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
