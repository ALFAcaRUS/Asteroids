using System;
using System.Collections.Generic;
using Game.Entitys.bullets;
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
            if (null != PlayerShip)
            {
                Pos.X = PlayerShip.Pos.X > Pos.X ? Pos.X + Speed.X : PlayerShip.Pos.X < Pos.X ? Pos.X - Speed.X : Pos.X;
                Pos.Y = Pos.Y - Speed.Y;
            }
            else
            {
                throw new NullReferenceException("Not ship");
            }
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (typeof(LaserBullet) == interactionEntity.GetType() || typeof(GunBullet) == interactionEntity.GetType())
            {
                base.WasKilled = true;
            }
            return null;
        }
    }
}
