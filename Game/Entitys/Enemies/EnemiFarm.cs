using System;
using System.Collections.Generic;
using Game.Entitys.PseudoEntitys;
using Game.Ships;

namespace Game.Entitys.Enemies
{
    class EnemiFarm:AEntity
    {

        private readonly int _maxX = 100;
        private readonly int _maxY = 100;

        private IShip playerShip;

        private CoupleDouble position;

        internal override CoupleDouble Pos
        {
            get
            {
                return position;
            }
            set
            {
                position = Pos;
            }
        }



        public EnemiFarm(CoupleDouble pos, CoupleDouble size, CoupleDouble speed, IShip ship) :base(pos,size,speed)
        {       
            Size = new CoupleDouble(0, 0);
            Speed = new CoupleDouble(0, 0);
            position = pos;
            playerShip = ship;
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

                CoupleDouble speed = new CoupleDouble(0.1, 0.1)*new Degree(ran.Next(360)).GetProjections();
                int ranX = ran.Next(2 * _maxX);
                int ranY = ran.Next(2 * _maxY);

                CoupleDouble ranPos = new CoupleDouble(ranX - _maxX, ranY - _maxY);

                if (ran.NextDouble() < 0.02)
                {
                    output.Add(new Ufo(ranPos, new CoupleDouble(5, 5), speed, playerShip));
                }

                if (ran.NextDouble() < 0.06)
                {
                    output.Add(new Asteroid(ranPos, new CoupleDouble(6, 6), speed, 2));
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
