using System;
using System.Collections.Generic;
using Game.Entitys.PseudoEntitys;

namespace Game.Entitys.Enemies
{
    class EnemiFarm:AEntity
    {

        private readonly int _maxX = 100;
        private readonly int _maxY = 100;

        internal override CoupleDouble Pos
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



        public EnemiFarm(CoupleDouble pos, CoupleDouble size, CoupleDouble speed) : base(pos, size, speed)
        {
            this.Size = new CoupleDouble(0, 0);
            this.Speed = new CoupleDouble(0, 0);
        }

        public EnemiFarm(CoupleDouble pos, CoupleDouble size, CoupleDouble speed, int maxX, int maxY)
            : base(pos, size, speed)
        {
            this.Size = new CoupleDouble(0, 0);
            this.Speed = new CoupleDouble(0, 0);
            this._maxX = maxX;
            this._maxY = maxY;
        }

        internal override void ChengeState(CoupleDouble maxPos)
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
                    output.Add(new Ufo(new CoupleDouble(ran.Next(_maxX),_maxY),new CoupleDouble(1,1),new Degree(ran.Next(360)).GetProjections()));
                }

                if (ran.NextDouble() < 0.3)
                {
                    output.Add(new Asteroid(new CoupleDouble(ran.Next(_maxX), _maxY), new CoupleDouble(2, 2), new Degree(ran.Next(360)).GetProjections(), 2));
                }

                return output;
            }

            return null;
        }

        internal override EntityType GetEntityType()
        {
            return EntityType.Service;
        }
    }
}
