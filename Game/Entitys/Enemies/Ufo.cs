using System;
using System.Collections.Generic;
using Game.Entitys.bullets;
using Game.Ships;

namespace Game.Entitys.Enemies
{
    internal class Ufo:AEntity
    {
        public IShip PlayerShip { get; set; }

        public Ufo(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
            : base(pos, size,speed)
        {

        }

        internal override void ChengeState(CoupleDouble maxPos)
        {
            if (null != PlayerShip)
            {
                Pos.X = PlayerShip.Pos.X > Pos.X ? Pos.X + Speed.X : PlayerShip.Pos.X < Pos.X ? Pos.X - Speed.X : Pos.X;
                Pos.Y = PlayerShip.Pos.Y > Pos.Y ? Pos.X + Speed.Y : PlayerShip.Pos.Y < Pos.Y ? Pos.Y - Speed.Y : Pos.Y; 

                Pos = Pos + Speed;
                Pos.X = Math.Abs(Pos.X) > maxPos.X
                    ? Math.Sign(Pos.X) * (maxPos.X - Math.Abs(Pos.X))
                    : Pos.X;
                Pos.Y = Math.Abs(Pos.Y) > maxPos.Y
                    ? Math.Sign(Pos.Y) * (maxPos.Y - Math.Abs(Pos.Y))
                    : Pos.Y;
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

        internal override EntityType GetEntityType()
        {
            return EntityType.Enemy;
        }

        public override string ToString()
        {
            return "Ufo";
        }
    }
}
