using System;
using System.Collections.Generic;
using Game.Entitys.bullets;
using Game.Ships;

namespace Game.Entitys.Enemies
{
    internal class Ufo:AEntity
    {
        private IShip PlayerShip;

        public Ufo(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
            : base(pos, size, speed)
        {

        }


        public Ufo(CoupleDouble pos, CoupleDouble size, CoupleDouble speed, IShip ship)
            : base(pos, size,speed)
        {
            PlayerShip = ship;
        }

        internal override void ChengeState(CoupleDouble maxPos)
        {
            if (null != PlayerShip)
            {
                Pos.X = PlayerShip.Pos.X > Pos.X ? Pos.X + 0.5 : PlayerShip.Pos.X < Pos.X ? Pos.X - 0.5 : Pos.X;
                Pos.Y = PlayerShip.Pos.Y > Pos.Y ? Pos.Y + 0.5 : PlayerShip.Pos.Y < Pos.Y ? Pos.Y - 0.5 : Pos.Y;

                Pos.X = Math.Abs(Pos.X) > maxPos.X
                    ? -Pos.X
                    : Pos.X;
                Pos.Y = Math.Abs(Pos.Y) > maxPos.Y
                    ? -Pos.Y
                    : Pos.Y;
            }
            else
            {
                throw new NullReferenceException("No ship");
            }
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (EntityType.Bullet == interactionEntity.GetEntityType())
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
