using System.Collections.Generic;

namespace Game.Entitys.bullets
{
    class GunBullet:AEntity
    {
        public GunBullet(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
            : base(pos, size, speed)
        {

        }

        internal override void ChengeState(CoupleDouble maxPos)
        {
            Pos.X = Pos.X - Speed.X;
            Pos.Y = Pos.Y - Speed.Y;
            if ((Pos.X > maxPos.X) || (Pos.Y > maxPos.Y)) WasKilled = true;
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (typeof (LaserBullet) != interactionEntity.GetType() && typeof(GunBullet) != interactionEntity.GetType())
            {
                base.WasKilled = true;
            }
            return null;
        }

        internal override EntityType GetEntityType()
        {
            return EntityType.Bullet;
        }

        public override string ToString()
        {
            return "GunBullet";
        }
    }
}
