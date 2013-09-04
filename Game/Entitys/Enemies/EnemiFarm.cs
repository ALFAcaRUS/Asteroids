using System;
using System.Collections.Generic;
using Game.Entitys.PseudoEntitys;

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
            
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (typeof (EnemyFarmPseudoEntity) == interactionEntity.GetType())
            {
                Random ran = new Random();

                List<AEntity> output = new List<AEntity>();

                if (ran.NextDouble() < 0.2)
                {
                    output.Add(new Ufo());
                }
            }
        }


    }
}
